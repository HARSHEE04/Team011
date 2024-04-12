using FlavorFiesta.BusinessLogic;

namespace FlavorFiesta.Pages
{
    public partial class RecipeType : ContentPage
    {
        private BusinessLogic.Preferences _prefs; // Fully qualified the Preferences class with its namespace

        public RecipeType(BusinessLogic.Preferences prefs) // Fully qualified the Preferences class with its namespace
        {
            InitializeComponent();
            _prefs = prefs;
        }
        //example

        private void OnMealTimeChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (e.Value)
            {
                // Set the selected meal time to preferences
                string selectedMealTime = radioButton.Content.ToString();
                _prefs.MealType = selectedMealTime;
            }
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            // Navigate to the next page with the preferences
            await Navigation.PushAsync(new NutritionalPreferencesPage(_prefs));
        }
    }
}