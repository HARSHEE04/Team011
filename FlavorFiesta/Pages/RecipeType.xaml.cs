﻿using FlavorFiesta.BusinessLogic;

namespace FlavorFiesta.Pages
{
    public partial class RecipeType : ContentPage
    {
        //private BusinessLogic.Preferences _prefs; // Fully qualified the Preferences class with its namespace
        private string _recipeType;
        private string _dietType;
        private string _cuisineType;

        public RecipeType(string dietType, string cuisineType) //recieves the cuisine type
        {
            InitializeComponent();
            //_prefs = prefs;

            _dietType = dietType;
            _cuisineType = cuisineType;
        }
        //example

        private void OnMealTimeChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (e.Value)
            {
                // Set the selected meal time to preferences
                string selectedMealTime = radioButton.Content.ToString();
                _recipeType = selectedMealTime;
                DisplayAlert("Recipe Type", $"You have selected : {_recipeType}", "Ok");
            }
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_recipeType))
            {
                await Navigation.PushAsync(new NutritionalPreferencesPage(_dietType, _cuisineType, _recipeType));
            }
            else
            {
                await DisplayAlert("Selection Missing", "Please select a recipe type.", "OK");
            }
        }
    }
}