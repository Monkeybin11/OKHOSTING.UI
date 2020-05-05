using System;
using System.Drawing;
using System.Windows;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class UserControl : System.Windows.Controls.UserControl, IUserControl
	{
		protected readonly System.Windows.Controls.ScrollViewer Scroller;

		public UserControl()
		{
			//allows for automatic vertical scrolling
			Scroller = new System.Windows.Controls.ScrollViewer();
			Scroller.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto;
			Scroller.VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto;

			base.Content = Scroller;
		}

		void IDisposable.Dispose()
		{
		}

		#region IControl

		bool IControl.Visible
		{
			get
			{
				return base.Visibility == System.Windows.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = System.Windows.Visibility.Visible;
				}
				else
				{
					base.Visibility = System.Windows.Visibility.Hidden;
				}
			}
		}

		bool IControl.Enabled
		{
			get
			{
				return base.IsEnabled;
			}
			set
			{
				base.IsEnabled = value;
			}
		}

		double? IControl.Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				if (value.HasValue)
				{
					base.Width = value.Value;
				}
			}
		}

		double? IControl.Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				if (value.HasValue)
				{
					base.Height = value.Value;
				}
			}
		}

		Thickness IControl.Margin
		{
			get
			{
				return Platform.Parse(base.Margin);
			}
			set
			{
				base.Margin = Platform.Parse(value);
			}
		}

		/// <summary>
		/// Space that this control will set between its content and its border
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre su contenido y su borde
		/// </para>
		/// </summary>
		Thickness IControl.Padding
		{
			get
			{
				return Platform.Parse(base.Padding);
			}
			set
			{
				base.Padding = Platform.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return Platform.Parse(((System.Windows.Media.SolidColorBrush)base.Background).Color);
			}
			set
			{
				base.Background = new System.Windows.Media.SolidColorBrush(Platform.Parse(value));
			}
		}

		Color IControl.BorderColor
		{
			get
			{
				return Platform.Parse(((System.Windows.Media.SolidColorBrush)base.BorderBrush).Color);
			}
			set
			{
				base.BorderBrush = new System.Windows.Media.SolidColorBrush(Platform.Parse(value));
			}
		}

		Thickness IControl.BorderWidth
		{
			get
			{
				return Platform.Parse(base.BorderThickness);
			}
			set
			{
				base.BorderThickness = Platform.Parse(value);
			}
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Platform.Parse(base.HorizontalAlignment);
			}
			set
			{
				base.HorizontalAlignment = Platform.Parse(value);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Platform.Parse(base.VerticalAlignment);
			}
			set
			{
				base.VerticalAlignment = Platform.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets a list of classes that define a control's style. 
		/// Exactly the same concept as in CSS. 
		/// </summary>
		string IControl.CssClass { get; set; }

		/// <summary>
		/// Control that contains this control, like a grid, or stack
		/// </summary>
		IControl IControl.Parent
		{
			get
			{
				return (IControl) base.Parent;
			}
		}

		object ICloneable.Clone()
		{
			return MemberwiseClone();
		}

		#endregion

		#region IPage

		/// <summary>
		/// Each Page only contains one main view, which can optionally be a container and contain more views
		/// <para xml:lang="es">
		/// Cada ventana solo contiene una vista principal, que puede ser opcionalmente un contenedor y contener mas vistas.
		/// </para>
		/// </summary>
		IControl IPage.Content
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
				return base.Width - 30;
			}
		}

		double? IPage.Height
		{
			get
			{
				return base.Height;
			}
		}

		/// <summary>
		/// App that is running on this page
		/// </summary>
		public App App { get; set; }

		/// <summary>
		/// Title for this page
		/// <para xml:lang="es">
		/// El titulo para esta pagina.
		/// </para>
		/// </summary>
		public string Title
		{
			get
			{
				return base.ToolTip?.ToString();
			}
			set
			{
				base.ToolTip = value;
			}
		}

		public void InvokeOnMainThread(Action action)
		{
			System.Windows.Application.Current.Dispatcher.Invoke(action);
		}

		/// <summary>
		/// Raises the Resized event
		/// </summary>
		protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
		{
			base.OnRenderSizeChanged(sizeInfo);
			App?[this]?.Controller?.Refresh();
		}

		#endregion
	}
}