

using FlavorFiesta.BusinessLogic;
using System.Windows.Input;

namespace FlavorFiesta.Pages;

public partial class SignUpPage : ContentPage
{
    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    AccountsManager _manager = new AccountsManager();
    public SignUpPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

    public User CaptureUserInput()
    {
        string firstName = FirstNameEntry.Text;
        string lastName = LastNameEntry.Text;
        string email = EmailEntry.Text;
        DateTime dateOfBirth = DatePicker.Date;
        string password = PasswordEntry.Text;
            
        string fullName = firstName + " " + lastName;
     
        return new User(fullName, email, password, dateOfBirth); 


    }
    void OnSignUpButton(object sender, EventArgs e)
    {
        DisplayAlert("Congratulations", "You have successfully created an account", "Ok");
        // Implementation for what should happen when the button is clicked
        _manager.AddUser(CaptureUserInput());
    }

    private void OnSignInAgain(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SignInPage());
    }
}