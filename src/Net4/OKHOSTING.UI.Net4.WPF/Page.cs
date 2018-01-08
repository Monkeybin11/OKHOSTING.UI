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
            Scroller.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto;
            Scroller.VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Visible;
            //base.Width = Double.NaN;
            //base.Height = Double.NaN;
            base.SizeToContent = System.Windows.SizeToContent.Manual;

            base.Content = Scroller;
		}

		private void Page_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
		{
			Platform.Current?.Controller?.Resize();
		}

		public new IControl Content
		{
			get
			{
				return (IControl) Scroller.Content;
			}
			set
			{
                if (value != null)
                {
                    value.HorizontalAlignment = UI.HorizontalAlignment.Fill;
                    value.VerticalAlignment = UI.VerticalAlignment.Fill;
                }
                
				Scroller.Content = value;
			}
		}

		//void IDisposable.Dispose()
		//{
		//	Content.Dispose();
		//}
	}
}
