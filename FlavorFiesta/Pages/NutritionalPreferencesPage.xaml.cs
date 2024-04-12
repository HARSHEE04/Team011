using System.Windows.Input;

namespace FlavorFiesta.Pages;

public partial class NutritionalPreferencesPage : ContentPage
{
    private FlavorFiesta.BusinessLogic.Preferences _prefs;

    public NutritionalPreferencesPage(FlavorFiesta.BusinessLogic.Preferences prefs)
    {
        InitializeComponent();
        BindingContext = this;
        _prefs = prefs;

    }

    public ICommand SubmitCommand => new Command(OnSubmit);

    private void OnSubmit()
    {
        Navigation.PushAsync(new DisplayRecipe());
    }
}