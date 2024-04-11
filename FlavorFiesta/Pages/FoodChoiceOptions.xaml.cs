namespace FlavorFiesta.Pages;

public partial class FoodChoiceOptions : ContentPage
{
    public FoodChoiceOptions()
    {
        InitializeComponent();
    }

    private void OnFoodChoiceChanged(object sender, CheckedChangedEventArgs e)
    {
        var radioButton = sender as RadioButton;
        if (e.Value)
        {
            string selectedFoodChoice = radioButton.Content.ToString();
            DisplayAlert("Food Choice Selected", $"You have selected: {selectedFoodChoice}", "OK");

            //for the future: 
            // set a property to the selected value.
            // ex: viewModel.SelectedFoodChoice = selectedFoodChoice;

            // navigate to another page based on the selection, you could do that here.

            // saving the choice to persistent storage
            // ex: Preferences.Set("foodChoice", selectedFoodChoice);
        }
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        // Navigate to the RecipeType page
        await Navigation.PushAsync(new RecipeType());
    }
}