using System;

using Xamarin.Forms;

namespace OKHOSTING.UI.Xamarin.Forms.Test
{
	public class App : Application
	{
		public App ()
		{
			OKHOSTING.UI.Xamarin.Forms.Platform.Current.Page = new OKHOSTING.UI.Xamarin.Forms.Page();
			MainPage = (global::Xamarin.Forms.Page) OKHOSTING.UI.Xamarin.Forms.Platform.Current.Page;
			new OKHOSTING.UI.Test.IndexController().Start();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}