
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
        try
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            bool searchUserResult = _accountsManager.SearchUser(email);

            if (searchUserResult == true)
            {
                bool isAuthenticated = _accountsManager.SearchPassword(password);

                if (isAuthenticated == true)
                {
                    // Navigate to the FoodChoiceOptions page without preferences
                    await Navigation.PushAsync(new FoodChoiceOptions());
                }
                else
                {
                    await DisplayAlert("Error", "The password is incorrect.", "OK");
                }

            }
            else
            {
                DisplayAlert("Please create an account", "Sign up", "Ok");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "An unexpected error occurred.", "OK");
        }
    }
}