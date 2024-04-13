using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using FlavorFiesta.BusinessLogic;
using FlavorFiesta.DataPersistance;
using Microsoft.Maui.Controls;

namespace FlavorFiesta.Pages
{
    public partial class NutritionalPreferencesPage : ContentPage
    {
        private string _dietType;
        private string _cuisineType;
        private string _recipeType;
        private string _caloriesRange;
        private string _proteinRange;
        private string _sugarRange;
        private string _servingsRange;
        private string _prepTimeRange;
        private List<string> _dietaryRestrictions;
        private BusinessLogic.Preferences _preferences;
        private PrefManagerDataPersistence _prefManager;


        public NutritionalPreferencesPage(string dietType, string cuisineType, string recipeType)
        {
            InitializeComponent();
            _dietType = dietType;
            _cuisineType = cuisineType;
            _recipeType = recipeType;
            _dietaryRestrictions = new List<string>();
            _prefManager = new PrefManagerDataPersistence($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}/preferences.json");
        }

        // Event handler for when the Submit button is clicked
        private async void OnSubmit(object sender, EventArgs e)
        {
            try
            {
                if (AreAllPreferencesSelected())
                            {
                                MakeUserPreference();
                                _prefManager.AddPreferences(_preferences);
                                await Navigation.PushAsync(new ChooseRecipe(_preferences));
                            }
                            else
                            {
                                await DisplayAlert("Selection Missing", "Please complete all selections before proceeding.", "OK");
                            }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
            
        }

        private bool AreAllPreferencesSelected()
        {
            // Check that all required selections have been made
            return !string.IsNullOrEmpty(_caloriesRange) &&
                   !string.IsNullOrEmpty(_proteinRange) &&
                   !string.IsNullOrEmpty(_sugarRange) &&
                   !string.IsNullOrEmpty(_servingsRange) &&
                   !string.IsNullOrEmpty(_prepTimeRange) &&
                   _dietaryRestrictions.Count > 0;
        }
        //Make the user preferences object to send to next page
        public FlavorFiesta.BusinessLogic.Preferences MakeUserPreference()
        {
            //make a new instance of preferences class
            FlavorFiesta.BusinessLogic.Preferences preference1 = new FlavorFiesta.BusinessLogic.Preferences(
                _dietType, _cuisineType, _recipeType, _caloriesRange, _proteinRange, _sugarRange, _servingsRange, _prepTimeRange, _dietaryRestrictions);

            _preferences = preference1;
            return _preferences;

        }

        // Sugar
        private async void OnSugarRangeChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (e.Value == true)
            {
                string selectedSugarRange = radioButton.Content.ToString();
                _sugarRange = selectedSugarRange;
            }
            await Task.CompletedTask;
        }

        // Calories
        private async void OnCaloriesRangeChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (e.Value == true)
            {
                string selectedCaloriesRange = radioButton.Content.ToString();
                _caloriesRange = selectedCaloriesRange;
            }
            await Task.CompletedTask;
        }
        // Protein
        private async void OnProtienRangeChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (e.Value == true)
            {
                string selectedProtienType = radioButton.Content.ToString();
                _proteinRange = selectedProtienType;
            }
            await Task.CompletedTask;
        }

        // Number of servings
        private async void OnNumberofServingsChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (e.Value == true)
            {
                string selectedServings = radioButton.Content.ToString();
                _servingsRange = selectedServings;
            }
            await Task.CompletedTask;
        }
        // Prep time
        private async void OnPrepTimeRangeChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (e.Value == true)
            {
                string selectedPrepTime = radioButton.Content.ToString();
                _prepTimeRange = selectedPrepTime;
            }
            await Task.CompletedTask;
        }

        private void OnDietaryRestrictionChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            string restriction = checkBox.ClassId;

            if (e.Value)
            {
                if (!_dietaryRestrictions.Contains(restriction))
                {
                    _dietaryRestrictions.Add(restriction);
                }
            }
            else
            {
                _dietaryRestrictions.Remove(restriction);
            }
        }

        void OnDietaryRestrictionsChanged(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
        {
                var checkBox = sender as CheckBox;
                string restriction = checkBox.ClassId;

                if (e.Value)
                {
                    if (!_dietaryRestrictions.Contains(restriction))
                    {
                        _dietaryRestrictions.Add(restriction);
                    }
                }
                else
                {
                    _dietaryRestrictions.Remove(restriction);
                }
        }
    }
}
