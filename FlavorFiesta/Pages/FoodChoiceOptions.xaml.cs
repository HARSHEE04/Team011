using System;
using System.Collections.Generic;
using FlavorFiesta.BusinessLogic;
using FlavorFiesta.DataPersistance;

namespace FlavorFiesta.Pages
{
    public partial class FoodChoiceOptions : ContentPage
    {
        private FlavorFiesta.BusinessLogic.Preferences _prefs;
        private PrefManagerDataPersistence _prefManager;


        public FoodChoiceOptions()
        {
            InitializeComponent();
            _prefManager = new PrefManagerDataPersistence(Path.Combine(FileSystem.AppDataDirectory, "preferences.json"));

        }

        public FoodChoiceOptions(string dietType, string cusineType, string mealType, int caloriesRange, int proteinRange, int sugarRange, int servingsRange, TimeSpan prepTimeRange, List<string> dietaryRestrictions)
        {
            InitializeComponent();
            _prefs = new FlavorFiesta.BusinessLogic.Preferences(
                dietType: dietType,
                cusineType: cusineType,
                mealType: mealType,
                caloriesRange: caloriesRange,
                protenRange: proteinRange,
                sugarRange: sugarRange,
                serveingsRange: servingsRange,
                prepTimeRange: prepTimeRange,
                dietaryRestrictions: dietaryRestrictions
            );
            _prefManager = new PrefManagerDataPersistence(Path.Combine(FileSystem.AppDataDirectory, "preferences.json"));

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
            try
            {
                // Save the preferences
                _prefManager.AddPreferences(_prefs);

                // Navigate to the next page with the preferences
                await Navigation.PushAsync(new CusinePage(_prefs));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "An unexpected error occurred.", "OK");
            }
        }
    }
}
