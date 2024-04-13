using System;
using System.Collections.Generic;

using FlavorFiesta.BusinessLogic;
using FlavorFiesta.DataPersistance;

namespace FlavorFiesta.Pages
{
    public partial class FoodChoiceOptions : ContentPage
    {
        private string _dietType;

        public FoodChoiceOptions(string dietType, string cusineType, string mealType, int caloriesRange, int proteinRange, int sugarRange, int servingsRange, TimeSpan prepTimeRange, List<string> dietaryRestrictions)
        {
            InitializeComponent();
        }

        private async void OnFoodChoiceChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (e.Value)
            {
                _dietType = radioButton.Content.ToString();
                await DisplayAlert("Food choice Option", $"You have selected {_dietType}", "Ok");
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
