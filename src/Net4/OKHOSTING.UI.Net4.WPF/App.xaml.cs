using System;
using System.Windows;

namespace OKHOSTING.UI.Net4.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class NativeApp : Application
	{
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			Page wnd = new Page();
			wnd.Show();
		}
	}
}