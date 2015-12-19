using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using OKHOSTING.UI.Net4.WPF.Controls;
using OKHOSTING.UI.Net4.WPF.Controls.Layout;

namespace OKHOSTING.UI.Net4.WPF
{
	/// <summary>
	/// Interaction logic for Page.xaml
	/// </summary>
	public partial class Page : System.Windows.Window, IPage
	{
		public Page()
		{
			InitializeComponent();
			base.SizeChanged += Page_SizeChanged;

			App.Current.SetPage(this);
			App.Current.Controller.Start();
        }

		private void Page_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
		{
			App.Current.Controller.Resize();
		}

		public new IControl Content
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
