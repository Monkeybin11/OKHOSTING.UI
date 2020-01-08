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

			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.Layout.IStack), typeof(Controls.Layout.Stack));

			var page = new Page();
			page.App = new UI.App();
			new IndexController() { Page = page }.Start();

			page.Show();
		}
	}
}
