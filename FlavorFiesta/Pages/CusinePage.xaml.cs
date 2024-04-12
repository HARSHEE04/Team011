using FlavorFiesta.BusinessLogic;
using System;

namespace FlavorFiesta.Pages
{
    public partial class CusinePage : ContentPage
    {
        private string _cuisineType;
        private string _dietType;
        //private BusinessLogic.Preferences _prefs; // Declare _prefs as an instance variable of type Preferences

        public CusinePage(string DietType) // Accept Preferences as an instance parameter
        {
            InitializeComponent();
            _dietType = DietType;
            
            //_prefs = prefs; // Assign the parameter to the instance variable
        }


     
        private async void OnCuisineTypeChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (e.Value == true)
            {
                // Set the selected cuisine type to preferences
                string selectedCuisineType = radioButton.Content.ToString();

                //_prefs.CuisineType = selectedCuisineType;
                _cuisineType = selectedCuisineType;
                await DisplayAlert("Cuisine Type Selected", $"You have selected: {_cuisineType} ", "OK");
            }
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            // Navigate to the next page with the preferences
            await Navigation.PushAsync(new RecipeType(_dietType, _cuisineType));
        }
    }
}
