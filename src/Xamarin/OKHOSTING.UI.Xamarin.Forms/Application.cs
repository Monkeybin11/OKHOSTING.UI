using System;

namespace OKHOSTING.UI.Xamarin.Forms
{
	public class Application : global::Xamarin.Forms.Application
	{
		public Application ()
		{
			Platform.Current.Page = new Page();
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