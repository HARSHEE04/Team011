using FlavorFiesta.BusinessLogic;
using System;

namespace FlavorFiesta.Pages
{
    /// <summary>
    /// Represents a page for selecting cuisine preferences.
    /// </summary>
    public partial class CusinePage : ContentPage
    {
        private string _cuisineType;
        private string _dietType;

        /// <summary>
        /// Initializes a new instance of the <see cref="CusinePage"/> class.
        /// </summary>
        /// <param name="DietType">The type of diet from user preferences.</param>
        public CusinePage(string DietType) // Accept Preferences as an instance parameter
        {
            InitializeComponent();
            _dietType = DietType;
        }

        /// <summary>
        /// Event handler for when a cuisine type is changed.
        /// </summary>
        private async void OnCuisineTypeChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (e.Value == true)
            {
                // Set the selected cuisine type to preferences
                string selectedCuisineType = radioButton.Content.ToString();
                _cuisineType = selectedCuisineType;
                await DisplayAlert("Cuisine Type Selected", $"You have selected: {_cuisineType} ", "OK");
            }
        }

        /// <summary>
        /// Event handler for when the submit button is clicked.
        /// </summary>
        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_cuisineType))
            {
                await Navigation.PushAsync(new RecipeType(_dietType, _cuisineType));
            }
            else
            {
                await DisplayAlert("Selection Missing", "Please select a cuisine type.", "OK");
            }
        }
    }
}
