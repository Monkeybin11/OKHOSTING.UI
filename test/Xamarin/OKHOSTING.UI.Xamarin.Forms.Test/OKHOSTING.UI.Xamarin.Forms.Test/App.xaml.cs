namespace OKHOSTING.UI.Xamarin.Forms.Test
{
	public partial class App : global::Xamarin.Forms.Application
	{
		public App()
		{
			InitializeComponent();

			var page = new Page();
			MainPage = page;

			new UI.Test.IndexController(page).Start();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
