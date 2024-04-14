using FlavorFiesta.BusinessLogic;
namespace FlavorFiesta.Pages;


public partial class DisplayRecipe : ContentPage
{
    private Recipe chosenRecipe;
	public DisplayRecipe(Recipe selectedRecipe)
	{
        
		InitializeComponent();
        chosenRecipe = selectedRecipe;
        RecipeName.Text = selectedRecipe.Name;
        RecipeURL.Text = selectedRecipe.RecipeURL;
        ChosenRecipeImage.Source=chosenRecipe.RecipeImage;
    }

    private void OnExit(object sender, EventArgs e)
    {
        System.Environment.Exit(0); // to exit the application upon exit button being clicked
        //source: https://stackoverflow.com/questions/692323/when-should-one-use-environment-exit-to-terminate-a-console-application
    }
}