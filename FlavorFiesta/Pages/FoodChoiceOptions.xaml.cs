using System;
using System.Collections.Generic;
using FlavorFiesta.BusinessLogic;

namespace FlavorFiesta.Pages
{
    public partial class FoodChoiceOptions : ContentPage
    {
        private FlavorFiesta.BusinessLogic.Preferences _prefs;

        public FoodChoiceOptions()
        {
            InitializeComponent();
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
        }

        private void OnFoodChoiceChanged(object sender, CheckedChangedEventArgs e)
        {
            // Handle food choice selection
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            // Navigate to the next page with the preferences
            await Navigation.PushAsync(new CusinePage(_prefs));
        }
    }
}
