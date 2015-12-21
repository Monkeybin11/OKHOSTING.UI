using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF
{
	/// <summary>
	/// Interaction logic for Page.xaml
	/// </summary>
	public partial class Page : System.Windows.Window, IPage
	{
		public Page()
		{
			base.SizeChanged += Page_SizeChanged;
        }

		private void Page_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
		{
			Platform.Current.Controller.Resize();
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
