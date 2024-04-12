using System;
using System.Collections.Generic;
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


        }

        //make an object of preferences and send it to the on submit
        // Event handler for when the Submit button is clicked
        private void OnSubmit(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new ChooseRecipe(_preferences));
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

            _preferences= preference1;
            return preference1;

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


       //// other restrictions(example: no-nuts)
       // private void onnonutscheckedchanged(object sender, checkedchangedeventargs e)
       // {
       //     if (e.value)
       //     {
       //         _preferences.adddietaryrestriction("no-nuts");
       //     }
       //     else
       //     {
       //         _preferences.removedietaryrestriction("no-nuts");
       //     }
       // }









        //    // Helper methods to get ranges from radio buttons
        //    private int GetSugarRangeFromRadioButton(RadioButton radioButton)
        //    {
        //        switch (radioButton.Content.ToString())
        //        {
        //            case "0-5":
        //                return 0;
        //            case "5-20":
        //                return 1;
        //            case "20+":
        //                return 2;
        //            default:
        //                return -1; // Handle error case
        //        }
        //    }

        //    private int GetServingsRangeFromRadioButton(RadioButton radioButton)
        //    {
        //        switch (radioButton.Content.ToString())
        //        {
        //            case "0-2":
        //                return 0;
        //            case "2-10":
        //                return 1;
        //            case "12+":
        //                return 2;
        //            default:
        //                return -1; // Handle error case
        //        }
        //    }

        //    private TimeSpan GetPrepTimeRangeFromRadioButton(RadioButton radioButton)
        //    {
        //        switch (radioButton.Content.ToString())
        //        {
        //            case "15-30":
        //                return TimeSpan.FromMinutes(15);
        //            case "30-60":
        //                return TimeSpan.FromMinutes(30);
        //            case "60+":
        //                return TimeSpan.FromMinutes(60);
        //            default:
        //                return TimeSpan.Zero; // Handle error case
        //        }
        //    }
        //}
    }
}
