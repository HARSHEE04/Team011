using FlavorFiesta.BusinessLogic;
using FlavorFiesta.Data_Persistance;
using System;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;

namespace FlavorFiesta.Pages;

public partial class SignUpPage : ContentPage
{
    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    AccountsManager _manager = new AccountsManager();

    // You'll need to provide the file path for the data file
    private readonly string _dataFilePath = Path.Combine(FileSystem.AppDataDirectory, "users.json");
    private readonly AccountManagerDataPersistance _dataPersistance;

    public SignUpPage()
    {
        InitializeComponent();
        BindingContext = this;
        _dataPersistance = new AccountManagerDataPersistance(_dataFilePath);

        // Attempt to load existing users
        try
        {
            var users = _dataPersistance.ReadPersonObjects();
            _manager.SetUsers(users);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not read users: {ex.Message}");
            // Handle the error appropriately
        }
    }

    public User CaptureUserInput()
    {
        // Assume all the entries are already validated
        string firstName = FirstNameEntry.Text;
        string lastName = LastNameEntry.Text;
        string email = EmailEntry.Text;
        DateTime dateOfBirth = BirthDatePicker.Date;
        string password = PasswordEntry.Text;

        string fullName = $"{firstName} {lastName}";

        // You need to return a User object here
        return new User(fullName, email, password, dateOfBirth);
    }
    async void OnSignUpButton(object sender, EventArgs e)
    {
        // First, check if the terms checkbox is checked
        if (!AcceptTermsCheckbox.IsChecked)
        {
            await DisplayAlert("Error", "You must accept the terms to sign up.", "OK");
            return;
        }

        try
        {
            User newUser = CaptureUserInput();

            // Add more validation as needed, for example:
            if (string.IsNullOrWhiteSpace(newUser.Email) || string.IsNullOrWhiteSpace(newUser.Password))
            {
                await DisplayAlert("Error", "Email and password cannot be empty.", "OK");
                return;
            }

            _manager.AddUser(newUser);
            _dataPersistance.SavePersonObjects(_manager.Users); // Save to file

            await DisplayAlert("Congratulations", "You have successfully created an account", "Ok");
            await Navigation.PushAsync(new SignInPage()); // Navigate to the sign-in page
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void OnSignInAgain(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignInPage()); // This should go back to the SignInPage
    }
}
