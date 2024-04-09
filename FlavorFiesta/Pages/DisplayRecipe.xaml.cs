namespace FlavorFiesta.Pages;

public partial class DisplayRecipe : ContentPage
{
	public DisplayRecipe()
	{
		InitializeComponent();
	}

    private void OnExit(object sender, EventArgs e)
    {
        System.Environment.Exit(0); // to exit the application upon exit button being clicked
        //source: https://stackoverflow.com/questions/692323/when-should-one-use-environment-exit-to-terminate-a-console-application
    }
}