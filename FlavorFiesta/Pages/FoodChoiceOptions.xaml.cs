using System;
using System.Collections.Generic;

using FlavorFiesta.BusinessLogic;
using FlavorFiesta.DataPersistance;

namespace FlavorFiesta.Pages
{
    public partial class FoodChoiceOptions : ContentPage
    {
        private string _dietType;
        // private BusinessLogic.Preferences _preferences;
        // private BusinessLogic.PreferencesManager _preferencesManager;


        public FoodChoiceOptions()
        {
            InitializeComponent();
            //_prefManager = new PrefManagerDataPersistence(Path.Combine(FileSystem.AppDataDirectory, "preferences.json"));

        }

        public FoodChoiceOptions(string dietType, string cusineType, string mealType, int caloriesRange, int proteinRange, int sugarRange, int servingsRange, TimeSpan prepTimeRange, List<string> dietaryRestrictions)
        {
            InitializeComponent();
            //_prefs = new FlavorFiesta.BusinessLogic.Preferences(
            //    dietType: dietType,
            //    cusineType: cusineType,
            //    mealType: mealType,
            //    caloriesRange: caloriesRange,
            //    protenRange: proteinRange,
            //    sugarRange: sugarRange,
            //    serveingsRange: servingsRange,
            //    prepTimeRange: prepTimeRange,
            //    dietaryRestrictions: dietaryRestrictions
            //);
            //_prefManager = new PrefManagerDataPersistence(Path.Combine(FileSystem.AppDataDirectory, "preferences.json"));

        }

        private async void OnFoodChoiceChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (e.Value)
            {
                _dietType = radioButton.Content.ToString();
            }
            await Task.CompletedTask;
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_dietType))
            {
                await Navigation.PushAsync(new CusinePage(_dietType));
            }
            else
            {
                await DisplayAlert("Selection Missing", "Please select a diet type.", "OK");
            }
        }
    }
}
