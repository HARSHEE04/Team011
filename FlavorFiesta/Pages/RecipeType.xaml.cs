using FlavorFiesta.BusinessLogic;

namespace FlavorFiesta.Pages;

public partial class RecipeType : ContentPage
{
    private BusinessLogic.Preferences _prefs;

    public RecipeType(BusinessLogic.Preferences _prefs)
	{
		InitializeComponent();
       // _prefs = prefs;

    }


    private void OnMealTimeChanged(object sender, CheckedChangedEventArgs e)
    {
        var radioButton = sender as RadioButton;
        if (e.Value)
        {
            // TODO: handle the logic when a meal time is selected.
            string selectedMealTime = radioButton.Content.ToString();
        }
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new NutritionalPreferencesPage(_prefs));
    }
}
