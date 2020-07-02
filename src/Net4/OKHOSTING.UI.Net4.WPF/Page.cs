using System;
using System.Windows;

namespace OKHOSTING.UI.Net4.WPF
{
	/// <summary>
	/// Interaction logic for Page.xaml
	/// </summary>
	public partial class Page : Window, IPage
	{
		protected readonly System.Windows.Controls.ScrollViewer Scroller;

		public Page()
		{
			//allows for automatic vertical scrolling
			Scroller = new System.Windows.Controls.ScrollViewer();
			Scroller.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto;
			Scroller.VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto;
			
			SizeToContent = SizeToContent.Manual;

			base.Content = Scroller;
		}

		string IPage.Title
		{
			get 
			{
				return base.Title;
			}
			set
			{
				base.Title = value ?? string.Empty;
			}
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
				Scroller.Content = value;
			}
		}

		double? IPage.Width
		{
			get
			{
				if (this.WindowState == WindowState.Maximized)
				{
					return SystemParameters.WorkArea.Width;
				}
				else
				{
					return base.Width;
				}
			}
		}

		double? IPage.Height
		{
			get
			{
				if (this.WindowState == WindowState.Maximized)
				{
					return SystemParameters.WorkArea.Height;
				}
				else
				{
					return base.Height;
				}
			}
		}

		public void InvokeOnMainThread(Action action)
		{
			Application.Current.Dispatcher.Invoke(action);
		}

		protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
		{
			App?[this]?.Controller?.Refresh();
		}
	}
}