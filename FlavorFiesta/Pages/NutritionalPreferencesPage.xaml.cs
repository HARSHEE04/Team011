using System.Windows.Input;

namespace FlavorFiesta.Pages;

public partial class NutritionalPreferencesPage : ContentPage
{
    public NutritionalPreferencesPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public ICommand SubmitCommand => new Command(OnSubmit);

    private void OnSubmit()
    {
        // still have to handle the submit action
    }
}