using OKHOSTING.UI;
using OKHOSTING.UI.Test;

namespace OKHOSTING.UI.Xamarin.Forms.Test.Droid
{
	public class App : global::Xamarin.Forms.Application
	{
		public App ()
		{
			Platform.Current.Page = new OKHOSTING.UI.Xamarin.Forms.Page();
			MainPage = (global::Xamarin.Forms.Page) Platform.Current.Page;
			
            new IndexController().Start();
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