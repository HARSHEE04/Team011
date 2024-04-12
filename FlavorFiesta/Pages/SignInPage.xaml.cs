
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

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Please enter both email and password.", "OK");
                return;
            }

            // Authenticate the user
            bool isAuthenticated = _accountsManager.AuthenticateUser(email, password);

            if (isAuthenticated)
            {
                // Assuming you want to pass the user's email and default preferences for now
                var preferences = new BusinessLogic.Preferences(
                    dietType: "Standard",
                    cusineType: "Any",
                    mealType: "Any",
                    caloriesRange: 2000, // Example value
                    protenRange: 50, // Example value
                    sugarRange: 30, // Example value
                    serveingsRange: 3, // Example value
                    prepTimeRange: TimeSpan.FromMinutes(30), // Example value
                    dietaryRestrictions: new List<string>() // No restrictions by default
                );

                // Navigate to the FoodChoiceOptions page with the preferences
                await Navigation.PushAsync(new FoodChoiceOptions(preferences));
            }
            else
            {
                await DisplayAlert("Error", "The email or password is incorrect.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "An unexpected error occurred.", "OK");
        }
    }
}