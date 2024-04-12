using FlavorFiesta.BusinessLogic;
using FlavorFiesta.DataPersistance;
namespace FlavorFiesta.Pages;

public partial class ChooseRecipe : ContentPage
{
    private RecipeManager _recipeManager;
    private RecipeManagerDataPersistance
    public ChooseRecipe(BusinessLogic.Preferences prefs)
	{
		InitializeComponent();
        BindingContext = this;
        _recipeManager.SearchRecipe(prefs,)

    }

    //The At this point, two recipes are presented, the page before this sets the two presented recipes as variables so we can pass that specific recipe to each method. When recipe two is chosen, it passes that recipe to the next page
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