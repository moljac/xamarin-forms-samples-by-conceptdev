﻿using System;
using Xamarin.Forms;
using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;

namespace EmployeeDirectory
{
	public partial class LoginXaml : ContentPage
	{
		LoginViewModel viewModel;

		public LoginXaml ()
		{
			InitializeComponent ();	
			viewModel = new LoginViewModel (App.Service);

			BindingContext = viewModel;

		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

		}
		void OnLoginClicked (object sender, EventArgs e)
		{
			if (viewModel.CanLogin ()) {
				viewModel
				.LoginAsync (System.Threading.CancellationToken.None)
				.ContinueWith (_ => {
					App.LastUseTime = System.DateTime.UtcNow;

						Navigation.PopModalAsync ();
				});

				Navigation.PopModalAsync ();
			} else {
				DisplayAlert ("Error", viewModel.ValidationErrors, "OK", null);
			}
		}

		void OnHelpClicked (object sender, EventArgs e)
		{
			DisplayAlert ("Help", "Enter any username and password", "OK", null);
		}
	}
}

