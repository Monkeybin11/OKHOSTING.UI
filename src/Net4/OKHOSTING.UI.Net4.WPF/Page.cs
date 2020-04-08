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
			base.StateChanged += Page_StateChanged;

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
				return base.Width;
			}
		}

		double? IPage.Height
		{
			get
			{
				return base.Height;
			}
		}

		public void InvokeOnMainThread(Action action)
		{
			System.Windows.Application.Current.Dispatcher.Invoke(action);
		}

		/// <summary>
		/// Raises the Resized event
		/// </summary>
		private void Page_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
		{
			App?[this]?.Controller?.Refresh();
		}

		/// <summary>
		/// For some reason, when maximized, base.Width and base.Height do not update on time, 
		/// so we need to do it here manually
		/// </summary>
		private void Page_StateChanged(object sender, EventArgs e)
		{
			if (this.WindowState == System.Windows.WindowState.Maximized)
			{
				Width = System.Windows.SystemParameters.WorkArea.Width;
				Height = System.Windows.SystemParameters.WorkArea.Height;
			}
		}
	}
}