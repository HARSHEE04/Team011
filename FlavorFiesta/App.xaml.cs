﻿using FlavorFiesta.Pages;

namespace FlavorFiesta;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
    }
}

