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
        BindingContext = this;

        _recipeManager = new RecipeManager();
        _csvRecipes = new RecipeManagerDataPersistance();

        allMatchingRecipes = _recipeManager.SearchRecipe(prefs, _csvRecipes);

        Recipe1Name.Text = allMatchingRecipes[0].Name;
        Recipe1Image.Source = allMatchingRecipes[0].RecipeImage;
        Recipe1PrepTme.Text = allMatchingRecipes[0].RecipePreferences.PrepTimeRange.ToString();

        Recipe2Name.Text = allMatchingRecipes[1].Name;
        Recipe2Image.Source = allMatchingRecipes[1].RecipeImage;
        Recipe2PrepTme.Text = allMatchingRecipes[1].RecipePreferences.PrepTimeRange.ToString();


        public ChooseRecipe(BusinessLogic.Preferences prefs)
        {
            InitializeComponent();
            BindingContext = this;
            _recipeManager = new RecipeManager(); // Initialize the _recipeManager instance
            _recipeManager.SearchRecipe(prefs);
        }


        //when either button is chosen, send the appropriate info about the recipe
        private void OnRecipe1Chosen(object sender, EventArgs e)
        {
            Recipe selectedRecipe = allMatchingRecipes[0];

            Navigation.PushAsync(new DisplayRecipe(selectedRecipe));


        }

        private void OnRecipe2Chosen(object sender, EventArgs e)
        {
            Recipe selectedRecipe = allMatchingRecipes[1];

            Navigation.PushAsync(new DisplayRecipe(selectedRecipe));
        }
    }
}