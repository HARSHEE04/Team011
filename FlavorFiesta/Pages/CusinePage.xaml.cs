namespace FlavorFiesta.Pages;

public partial class CusinePage : ContentPage
{
	public CusinePage()
	{
		InitializeComponent();
	}

    private void OnCuisineTypeChanged(object sender, CheckedChangedEventArgs e)
    {
        var radioButton = sender as RadioButton;
        if (e.Value)
        {
            // TODO: Handle the logic when a cuisine type is selected.
            string selectedCuisineType = radioButton.Content.ToString();
        }
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
    }
}