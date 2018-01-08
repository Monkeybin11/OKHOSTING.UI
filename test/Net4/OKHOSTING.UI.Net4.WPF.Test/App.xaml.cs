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

			Platform.Current.Page = new OKHOSTING.UI.Net4.WPF.Page();

			new IndexController().Start();

			((Page)Platform.Current.Page).Show();
		}
	}
}
