using FlavorFiesta.BusinessLogic;
using System;

namespace FlavorFiesta.Pages
{
    public partial class CuisinePage : ContentPage
    {
        private string _selectedCuisine;

        public CuisinePage()
        {
            InitializeComponent();
        }

        private void OnCuisineTypeChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (e.Value) // Check if the radio button is checked
            {
                _selectedCuisine = radioButton.Content.ToString();
                Console.WriteLine($"Cuisine selected: {_selectedCuisine}");
            }
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_selectedCuisine))
            {
                await DisplayAlert("Cuisine Selected", $"You have selected: {_selectedCuisine}", "OK");
            }
            else
            {
                await DisplayAlert("Selection Missing", "Please select a cuisine type.", "OK");
            }
        }
    }
}
