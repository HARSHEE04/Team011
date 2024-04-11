
using FlavorFiesta.BusinessLogic;

namespace FlavorFiesta.Pages;

public partial class SignInPage : ContentPage
{
	AccountsManager _accountsManager;
	public SignInPage()
	{
		InitializeComponent();
	}

    private void OnSignIn(object sender, EventArgs e)
    {
		bool searchUserResult = _accountsManager.SearchUser(EmailEntry.Text);
		if (searchUserResult == true)
		{
			bool searchPasswordResult = _accountsManager.SearchPassword(PasswordEntry.Text);
			if (searchPasswordResult == true)
			{
				Navigation.PushAsync(new FoodChoiceOptions());
			}
			else
				DisplayAlert("Incorrect Password", "Try Again", "Ok");			
		}
		else
		{
			DisplayAlert("Please sign up first.", "Create an Account", "Ok");
			Navigation.PushAsync(new SignUpPage());
		}
    }
}