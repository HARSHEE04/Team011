using FlavorFiesta.BusinessLogic;
using Microsoft.Maui.Controls;
using System;

namespace FlavorFiesta.Pages;

public partial class NutritionalPreferencesSelectionPage : ContentPage
{
    private PreferencesManager _preferencesManager;

    public NutritionalPreferencesSelectionPage(PreferencesManager preferencesManager)
    {
        InitializeComponent();
        _preferencesManager = preferencesManager;
        PreferencesListView.ItemsSource = _preferencesManager.GetUserPreferences();
    }

    private void OnCreateNewPreferencesClicked(object sender, EventArgs e)
    {
        // Navigate to the NutritionalPreferencesPage for creating new preferences
        //Navigation.PushAsync(new NutritionalPreferencesPage());
    }
}