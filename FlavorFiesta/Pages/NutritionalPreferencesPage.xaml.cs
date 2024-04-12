using System;
using System.Collections.Generic;
using System.Windows.Input;
using FlavorFiesta.BusinessLogic;

namespace FlavorFiesta.Pages
{
    public partial class NutritionalPreferencesPage : ContentPage
    {
        private BusinessLogic.Preferences _prefs;

        public NutritionalPreferencesPage(BusinessLogic.Preferences prefs)
        {
            InitializeComponent();
            BindingContext = this;
            _prefs = prefs;
        }

        // Event handler for when the Submit button is clicked
        private void OnSubmit(object sender, EventArgs e)
        {
            try
            {
                // Navigate to the ChooseRecipe page and pass the _prefs object
                Navigation.PushAsync(new ChooseRecipe(_prefs));
            }
            catch (Exception ex)
            {
                // Log any exceptions
                Console.WriteLine($"Navigation error: {ex.Message}");
            }
        }
        // Sugar
        private void OnSugarSelectionChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                _prefs.SugarRange = GetSugarRangeFromRadioButton(sender as RadioButton);
            }
        }

        // Servings
        private void OnServingsSelectionChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                _prefs.ServingsRange = GetServingsRangeFromRadioButton(sender as RadioButton);
            }
        }

        // Prep Time
        private void OnPrepTimeSelectionChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                _prefs.PrepTimeRange = GetPrepTimeRangeFromRadioButton(sender as RadioButton);
            }
        }

        // Other Restrictions (example: No-Nuts)
        private void OnNoNutsCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                _prefs.AddDietaryRestriction("No-Nuts");
            }
            else
            {
                _prefs.RemoveDietaryRestriction("No-Nuts");
            }
        }

        // Helper methods to get ranges from radio buttons
        private int GetSugarRangeFromRadioButton(RadioButton radioButton)
        {
            switch (radioButton.Content.ToString())
            {
                case "0-5":
                    return 0;
                case "5-20":
                    return 1;
                case "20+":
                    return 2;
                default:
                    return -1; // Handle error case
            }
        }

        private int GetServingsRangeFromRadioButton(RadioButton radioButton)
        {
            switch (radioButton.Content.ToString())
            {
                case "0-2":
                    return 0;
                case "2-10":
                    return 1;
                case "12+":
                    return 2;
                default:
                    return -1; // Handle error case
            }
        }

        private TimeSpan GetPrepTimeRangeFromRadioButton(RadioButton radioButton)
        {
            switch (radioButton.Content.ToString())
            {
                case "15-30":
                    return TimeSpan.FromMinutes(15);
                case "30-60":
                    return TimeSpan.FromMinutes(30);
                case "60+":
                    return TimeSpan.FromMinutes(60);
                default:
                    return TimeSpan.Zero; // Handle error case
            }
        }
    }
}
