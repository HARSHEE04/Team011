using System.Diagnostics;
using FlavorFiesta.BusinessLogic;
using FlavorFiesta.DataPersistance;
namespace FlavorFiesta.Pages;

public partial class ChooseRecipe : ContentPage
{
    private RecipeManager _recipeManager;
    private RecipeManagerDataPersistance _csvRecipes;

    private List<Recipe> allMatchingRecipes;
    public ChooseRecipe(BusinessLogic.Preferences prefs)
    {
        InitializeComponent();
        Debug.WriteLine($"Using preferences to search recipes: DietType={prefs.DietType}"); //explained in report - Maryam

        _recipeManager = new RecipeManager();
        _csvRecipes = new RecipeManagerDataPersistance();

        Debug.WriteLine($"Received preferences: DietType={prefs.DietType}, CuisineType={prefs.CuisineType}, RecipeType={prefs.MealType}");

        try
        {
            allMatchingRecipes = _recipeManager.SearchRecipe(prefs, _csvRecipes);
            Debug.WriteLine($"Found {allMatchingRecipes.Count} matching recipes.");

            if (allMatchingRecipes.Count >= 2)
            {
                // Assuming there are at least two recipes to display
                Recipe1Name.Text = allMatchingRecipes[0].Name;
                Recipe1Image.Source = allMatchingRecipes[0].RecipeImage;
                Recipe1PrepTme.Text = allMatchingRecipes[0].RecipePreferences.PrepTimeRange.ToString();

                Recipe2Name.Text = allMatchingRecipes[1].Name;
                Recipe2Image.Source = allMatchingRecipes[1].RecipeImage;
                Recipe2PrepTme.Text = allMatchingRecipes[1].RecipePreferences.PrepTimeRange.ToString();
            }
            else
            {
                // Handle the scenario where fewer than two recipes are found
                Debug.WriteLine("Not enough recipes found to display.");
                DisplayAlert("Notice", "Not enough recipes found based on your preferences.", "OK");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error searching recipes: {ex.Message}");
            DisplayAlert("Error", "Failed to retrieve recipes.", "OK");
        }
    }

    private async void OnRecipe1Chosen(object sender, EventArgs e)
    {
        if (allMatchingRecipes.Count > 0)
        {
            Recipe selectedRecipe = allMatchingRecipes[0];
            await Navigation.PushAsync(new DisplayRecipe(selectedRecipe));
        }
    }

    private async void OnRecipe2Chosen(object sender, EventArgs e)
    {
        if (allMatchingRecipes.Count > 1)
        {
            Recipe selectedRecipe = allMatchingRecipes[1];
            await Navigation.PushAsync(new DisplayRecipe(selectedRecipe));
        }
    }
}