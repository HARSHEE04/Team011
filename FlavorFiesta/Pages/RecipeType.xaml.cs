namespace FlavorFiesta.Pages;

public partial class RecipeType : ContentPage
{
	public RecipeType()
	{
		InitializeComponent();
	}


    private void OnMealTimeChanged(object sender, CheckedChangedEventArgs e)
    {
        var radioButton = sender as RadioButton;
        if (e.Value)
        {
            // TODO: handle the logic when a meal time is selected.
            string selectedMealTime = radioButton.Content.ToString();
        }
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        // TODO: implement what happens when the submit button is clicked
    }
}
