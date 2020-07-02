using OKHOSTING.UI.Test;
using System.Windows;

namespace OKHOSTING.UI.Net4.WPF.Test
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var page = new Page();
			page.App = new UI.App();
			new IndexController(page).Start();

			page.Show();
			//new Window1().Show();
		}
	}
}