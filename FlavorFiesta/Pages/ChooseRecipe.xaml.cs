namespace FlavorFiesta.Pages;

public partial class ChooseRecipe : ContentPage
{
	public ChooseRecipe()
	{
		InitializeComponent();
	}


    private void OnRecipe1Chosen(object sender, EventArgs e)
    {

    }

    private void OnRecipe2Chosen(object sender, EventArgs e)
    {

    }

    private void OnOpenRecipeInfo(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DisplayRecipe()); //ensure you send correct info to the DisplayRecipe page
    }
}