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

			Platform platform = new Platform();
			platform.Page = new Page();
			((Page) platform.Page).Show();

			new IndexController().Start();
		}
	}
}
