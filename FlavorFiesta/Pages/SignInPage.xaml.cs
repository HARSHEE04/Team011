
using FlavorFiesta.BusinessLogic;
using FlavorFiesta.DataPersistance;
using System;

namespace FlavorFiesta.Pages;

public partial class SignInPage : ContentPage
{
	AccountsManager _accountsManager;
    public SignInPage()
    {
        InitializeComponent();
        _accountsManager = new AccountsManager();

        // Load users from persistent storage
        var dataPersistance = new AccountManagerDataPersistance(Path.Combine(FileSystem.AppDataDirectory, "users.json"));
        try
        {
            var users = dataPersistance.ReadPersonObjects();
            _accountsManager.SetUsers(users);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not read users: {ex.Message}");
        }
    }

    private async void OnSignIn(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        // Check if the email and password are not empty
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Email and password cannot be empty.", "OK");
            return;
        }

        // Search for user and password
        bool userExists = _accountsManager.SearchUser(email);
        bool passwordMatches = _accountsManager.SearchPassword(password);

        if (userExists && passwordMatches)
        {
            // If user is found and password matches, navigate to the next page
            var prefs = new FlavorFiesta.BusinessLogic.Preferences(
                email, "", "", 0, 0, 0, 0, TimeSpan.Zero, new List<string>()); // Placeholder values
            await Navigation.PushAsync(new FoodChoiceOptions(prefs));
        }
        else
        {
            // If credentials do not match, display an error
            await DisplayAlert("Error", "Incorrect email or password.", "OK");
        }
    }
}