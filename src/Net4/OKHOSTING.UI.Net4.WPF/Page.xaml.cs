using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF
{
	/// <summary>
	/// Interaction logic for Page.xaml
	/// </summary>
	public partial class Page : Window, IPage
	{
		public Page()
		{
			base.Loaded += Page_Loaded;
			InitializeComponent();
		}

		public new event EventHandler Loaded;

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			if (Loaded != null)
			{
				Loaded(sender, new EventArgs());
			}
		}

		IControl IPage.Content
		{
			get
			{
				return (IControl) base.Content;
			}
			set
			{
				base.Content = value;
			}
		}
	}
}
