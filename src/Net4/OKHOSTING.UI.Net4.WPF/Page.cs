using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF
{
	/// <summary>
	/// Interaction logic for Page.xaml
	/// </summary>
	public partial class Page : System.Windows.Window, IPage
	{
		protected readonly System.Windows.Controls.ScrollViewer Scroller;

		public Page()
		{
			base.SizeChanged += Page_SizeChanged;

			//allows for automatic vertical scrolling
			Scroller = new System.Windows.Controls.ScrollViewer();
			base.Content = Scroller;
		}

		private void Page_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
		{
			Platform.Current.Controller.Resize();
		}

		public new IControl Content
		{
			get
			{
				return (IControl) Scroller.Content;
			}
			set
			{
				Scroller.Content = value;
			}
		}

		//void IDisposable.Dispose()
		//{
		//	Content.Dispose();
		//}
	}
}
