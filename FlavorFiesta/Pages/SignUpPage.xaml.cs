using System.Windows.Input;

namespace FlavorFiesta.Pages;

public partial class SignUpPage : ContentPage
{
    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public SignUpPage()
	{
		InitializeComponent();
		BindingContext = this;
	}
}