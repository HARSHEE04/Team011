namespace FlavorFiesta.Pages;

public partial class WelcomePage : ContentPage
{
    public WelcomePage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async void OnSignInClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignInPage());
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        // Navigate to the Sign-Up Page
        await Navigation.PushAsync(new SignUpPage());

    }
}
