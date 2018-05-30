using OKHOSTING.UI.Test;
using System.Windows;

namespace OKHOSTING.UI.Net4.WPF.Test
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class MyApp : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			App app = new App();
			app.Page = new Page();

			new IndexController().Start();

			((Page) app.Page).Show();
		}
	}
}
