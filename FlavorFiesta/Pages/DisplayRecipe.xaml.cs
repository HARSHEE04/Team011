using FlavorFiesta.BusinessLogic;
namespace FlavorFiesta.Pages;


public partial class DisplayRecipe : ContentPage
{
    private Recipe chosenRecipe;
    //THIS FILE WAS MADE AND EDITED BY HARSHETA SHARMA
    public DisplayRecipe(Recipe selectedRecipe)
    {
        try
        {
            InitializeComponent();
            chosenRecipe = selectedRecipe;
            RecipeName.Text = selectedRecipe.Name;
            RecipeURL.Text = selectedRecipe.RecipeURL;
            ChosenRecipeImage.Source = chosenRecipe.RecipeImage;
        }
        catch (Exception ex)
        {
            // Handle the exception
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    private void OnExit(object sender, EventArgs e)
    {
        System.Environment.Exit(0); // to exit the application upon exit button being clicked
        //source: https://stackoverflow.com/questions/692323/when-should-one-use-environment-exit-to-terminate-a-console-application
    }
}