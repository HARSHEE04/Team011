using System.Diagnostics;
using FlavorFiesta.BusinessLogic;
using FlavorFiesta.DataPersistance;
namespace FlavorFiesta.Pages;

public partial class ChooseRecipe : ContentPage
{
    private RecipeManager _recipeManager;
    private RecipeManagerDataPersistance _csvRecipes;

    private Recipe allMatchingRecipes;
    public ChooseRecipe(BusinessLogic.Preferences prefs)
    {
        
        InitializeComponent();
        Debug.WriteLine($"Using preferences to search recipes: DietType={prefs.DietType}"); //explained in report - Maryam

        _recipeManager = new RecipeManager();
        _csvRecipes = new RecipeManagerDataPersistance();
        BindingContext = allMatchingRecipes;

        Debug.WriteLine($"Received preferences: DietType={prefs.DietType}, CuisineType={prefs.CuisineType}, RecipeType={prefs.MealType}");

        try
        {
            allMatchingRecipes = _recipeManager.SearchRecipe(prefs, _csvRecipes);
            Recipe1Name.Text = allMatchingRecipes.Name;
            RecipeImage.Source = allMatchingRecipes.RecipeImage;
            Recipe1PrepTme.Text = $"The Prep time for this is: {allMatchingRecipes.RecipePreferences.PrepTimeRange.ToString()} minutes";

           
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error searching recipes: {ex.Message}");
            DisplayAlert("Error", "Failed to retrieve recipes.", "OK");
        }
    }

    private void OnMoreInfo(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DisplayRecipe(allMatchingRecipes));
    }
}