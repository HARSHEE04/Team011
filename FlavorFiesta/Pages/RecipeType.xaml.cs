using FlavorFiesta.BusinessLogic;

namespace FlavorFiesta.Pages
{
    public partial class RecipeType : ContentPage
    {
        private BusinessLogic.Preferences _prefs; // Fully qualified the Preferences class with its namespace

        public RecipeType(string dietType, string cuisineType) // Fully qualified the Preferences class with its namespace
        {
            InitializeComponent();
            //_prefs = prefs;
        }
        //example

        private void OnMealTimeChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (e.Value)
            {
                _prefs.MealType = radioButton.Content.ToString();
            }
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            if (_prefs.MealType != null)
            {
                await Navigation.PushAsync(new NutritionalPreferencesPage(_prefs));
            }
            else
            {
                await DisplayAlert("Selection Missing", "Please select a meal type.", "OK");
            }
        }
    }
}