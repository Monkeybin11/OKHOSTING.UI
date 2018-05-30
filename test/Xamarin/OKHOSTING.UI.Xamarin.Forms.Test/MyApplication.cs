using OKHOSTING.UI.Xamarin.Forms;
using System;

namespace OKHOSTING.UI.Xamarin.Forms.Test
{
	public class MyApplication : global::Xamarin.Forms.Application
	{
		public MyApplication ()
		{
			var app = new App();
			app.Page = new Page();
			MainPage = (global::Xamarin.Forms.Page) app.Page;
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