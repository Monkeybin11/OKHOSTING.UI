using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF
{
	/// <summary>
	/// Interaction logic for Page.xaml
	/// </summary>
	public partial class Page : System.Windows.Window, IPage
	{
		/// <summary>
		/// Raised when the page is resized
		/// </summary>
		public event EventHandler Resized;

		protected readonly System.Windows.Controls.ScrollViewer Scroller;

		public Page()
		{
			base.SizeChanged += Page_SizeChanged;

			//allows for automatic vertical scrolling
			Scroller = new System.Windows.Controls.ScrollViewer();
			Scroller.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto;
			Scroller.VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Visible;
			SizeToContent = System.Windows.SizeToContent.Manual;

			base.Content = Scroller;
		}

		/// <summary>
		/// App that is running on this page
		/// </summary>
		public App App { get; set; }

		/// <summary>
		/// Each Page only contains one main view, which can optionally be a container and contain more views
		/// <para xml:lang="es">
		/// Cada ventana solo contiene una vista principal, que puede ser opcionalmente un contenedor y contener mas vistas.
		/// </para>
		/// </summary>
		public new IControl Content
		{
			get
			{
				return (IControl) Scroller.Content;
			}
			set
			{
				//if (value != null)
				//{
				//	value.HorizontalAlignment = UI.HorizontalAlignment.Fill;
				//	value.VerticalAlignment = UI.VerticalAlignment.Fill;
				//}
				
				Scroller.Content = value;
			}
		}

		double? IPage.Width
		{
			get
			{
				return Width;
			}
		}

		double? IPage.Height
		{
			get
			{
				return Height;
			}
		}

		/// <summary>
		/// Raises the Resized event
		/// </summary>
		private void Page_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
		{
			Resized?.Invoke(this, null);
		}
	}
}