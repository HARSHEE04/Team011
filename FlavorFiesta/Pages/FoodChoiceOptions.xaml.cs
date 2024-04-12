using FlavorFiesta.BusinessLogic;
using FlavorFiesta.DataPersistance;
namespace FlavorFiesta.Pages;

public partial class FoodChoiceOptions : ContentPage
{
    private FlavorFiesta.BusinessLogic.Preferences _prefs;


    public FoodChoiceOptions(FlavorFiesta.BusinessLogic.Preferences prefs)
    {
        InitializeComponent();
        _prefs = prefs ?? new Preferences();
    }

    private void OnFoodChoiceChanged(object sender, CheckedChangedEventArgs e)
    {
        var radioButton = sender as RadioButton;
        if (e.Value)
        {
            string selectedFoodChoice = radioButton.Content.ToString();
            DisplayAlert("Food Choice Selected", $"You have selected: {selectedFoodChoice}", "OK");

            // Set the selected diet type to preferences
            _prefs.DietType = selectedFoodChoice;
        }
    }
    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        // Navigate to the next page with the preferences
        await Navigation.PushAsync(new RecipeType(_prefs));
    }
}