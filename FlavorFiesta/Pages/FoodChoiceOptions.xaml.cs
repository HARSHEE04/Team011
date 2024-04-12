using System;
using System.Collections.Generic;
using FlavorFiesta.BusinessLogic;

namespace FlavorFiesta.Pages
{
    public partial class FoodChoiceOptions : ContentPage
    {
        private FlavorFiesta.BusinessLogic.Preferences _prefs; // Fully qualified the Preferences class with its namespace

        public FoodChoiceOptions(FlavorFiesta.BusinessLogic.Preferences prefs)
        {
            InitializeComponent();
            _prefs = prefs ?? new FlavorFiesta.BusinessLogic.Preferences(
                dietType: "",    // Provide a default value for dietType
                cusineType: "",  // Provide a default value for cusineType
                mealType: "",    // Provide a default value for mealType
                caloriesRange: 0, // Provide a default value for caloriesRange
                protenRange: 0,  // Provide a default value for protenRange
                sugarRange: 0,   // Provide a default value for sugarRange
                serveingsRange: 0, // Provide a default value for serveingsRange
                prepTimeRange: TimeSpan.Zero, // Provide a default value for prepTimeRange
                dietaryRestrictions: new List<string>() // Provide an empty list for dietaryRestrictions
            );
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
            await Navigation.PushAsync(new CusinePage(_prefs));
        }
    }
}
