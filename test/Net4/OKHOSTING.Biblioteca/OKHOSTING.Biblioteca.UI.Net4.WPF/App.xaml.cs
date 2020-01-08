using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OKHOSTING.Biblioteca.UI.Net4.WPF
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
			page.App = new Biblioteca.App();
			page.App.MainPage = page;
			((Biblioteca.App)page.App).Start();

			page.Show();
		}
	}
}
