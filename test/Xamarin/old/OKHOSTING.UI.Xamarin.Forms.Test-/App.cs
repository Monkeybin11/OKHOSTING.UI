using OKHOSTING.UI.Xamarin.Forms;
using System;

namespace OKHOSTING.UI.Xamarin.Forms.Test
{
	public class App : global::Xamarin.Forms.Application
	{
		public App ()
		{
			Platform platform = new Platform();
			platform.Page = new Page();
			MainPage = (global::Xamarin.Forms.Page) platform.Page;

			new UI.Test.IndexController().Start();
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