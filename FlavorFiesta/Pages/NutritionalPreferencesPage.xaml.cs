using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using FlavorFiesta.BusinessLogic;

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
        private FlavorFiesta.BusinessLogic.Preferences _preferences;


        public NutritionalPreferencesPage(string dietType, string cuisineType, string recipeType)
        {
            InitializeComponent();
            //BindingContext = this;
            _dietType = dietType;
            _cuisineType = cuisineType;
            _recipeType = recipeType;
            _dietaryRestrictions = new List<string>();
        }

        // Event handler for when the Submit button is clicked
        private async void OnSubmit(object sender, EventArgs e)
        {
            Debug.WriteLine("Current navigation stack count: " + Navigation.NavigationStack.Count);
            MakeUserPreference();
            await Navigation.PushAsync(new ChooseRecipe(_preferences));
        }

        //Make the user preferences object to send to next page
        public FlavorFiesta.BusinessLogic.Preferences MakeUserPreference()
        {
            List<string> dietaryRestrictions = new List<string>
            {
                "No-Nuts",
                "No-Eggs"
            };

            //make a new instance of preferences class
            FlavorFiesta.BusinessLogic.Preferences preference1 = new FlavorFiesta.BusinessLogic.Preferences(
                _dietType, _cuisineType, _recipeType, _caloriesRange, _proteinRange, _sugarRange, _servingsRange, _prepTimeRange, dietaryRestrictions);

            _preferences = preference1;
            return preference1;

        }

        private void OnDietaryRestrictionChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            string restriction = checkBox.ClassId; // Assuming ClassId is used to identify the restriction type

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

        // Sugar
        private async void OnSugarRangeChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (e.Value == true)
            {
                string selectedSugarRange = radioButton.Content.ToString();
                _sugarRange = selectedSugarRange;

            }
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
        }

        void OnDietaryRestrictionsChanged(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
        {
                var checkBox = sender as CheckBox;
                string restriction = checkBox.ClassId; // Assuming ClassId is used to identify the restriction type

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
