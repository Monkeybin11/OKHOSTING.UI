using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OKHOSTING.Cine.UI.Net4.WPF
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var page = new OKHOSTING.UI.Net4.WPF.Page();
			page.App = new Cine.App();
			page.App.MainPage = page;
			((Cine.App)page.App).Start();

			page.Show();
		}
	}
}
