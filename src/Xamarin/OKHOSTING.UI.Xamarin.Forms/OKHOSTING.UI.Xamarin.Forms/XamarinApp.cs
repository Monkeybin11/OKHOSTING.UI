using Xamarin.Forms;

namespace OKHOSTING.UI.Xamarin.Forms
{
	public class XamarinApp : Application
	{
		public XamarinApp()
		{
			// The root page of your application
			MainPage = new NavigationPage((Page) App.Current.Page);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
