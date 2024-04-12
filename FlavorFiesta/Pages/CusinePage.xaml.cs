using FlavorFiesta.BusinessLogic;
using System;

namespace FlavorFiesta.Pages
{
    public partial class CusinePage : ContentPage
    {
        private BusinessLogic.Preferences _prefs; // Declare _prefs as an instance variable of type Preferences

        public CusinePage(BusinessLogic.Preferences prefs) // Accept Preferences as an instance parameter
        {
            InitializeComponent();
            _prefs = prefs; // Assign the parameter to the instance variable
        }

        private void OnCuisineTypeChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (e.Value)
            {
                // Set the selected cuisine type to preferences
                string selectedCuisineType = radioButton.Content.ToString();
                _prefs.CuisineType = selectedCuisineType;
            }
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            // Navigate to the next page with the preferences
            await Navigation.PushAsync(new RecipeType(_prefs));
        }
    }
}
