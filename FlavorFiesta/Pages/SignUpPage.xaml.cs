

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
        string confirmPassword = ConfirmPasswordEntry.Text;
        //if (methodConfirmPassword(password, confirmPassword) == false)
        //{
        //    DisplayAlert("Incorrect Password", "This password doesn't match with the original password", "Ok");
         

        //}

        string fullName = firstName + " " + lastName;
        User user1 = new User(fullName, email, password, dateOfBirth);
        return user1; 


    }
    void OnSignUpButton(object sender, EventArgs e)
    {
        // Implementation for what should happen when the button is clicked
    }

    void OnViewUsers(System.Object sender, System.EventArgs e)
    {
    }

}