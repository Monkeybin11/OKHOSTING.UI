using OKHOSTING.UI.Controls;
using System;
using System.Drawing;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class WebView: System.Windows.Controls.Panel, IWebView
	{
		protected readonly System.Windows.Controls.WebBrowser Browser;

		public WebView()
		{
			Browser = new System.Windows.Controls.WebBrowser();
			Browser.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
			Browser.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;

			base.Children.Add(Browser);
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
			get;
			set;
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
			get;
			set;
		}

		Thickness IControl.BorderWidth
		{
			get;
			set;
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
		/// Control that contains this control, like a grid, or stack
		/// </summary>
		IControl IControl.Parent
		{
			get
			{
				return (IControl) base.Parent;
			}
		}

		/// <summary>
		/// Gets or sets a list of classes that define a control's style. 
		/// Exactly the same concept as in CSS. 
		/// </summary>
		string IControl.CssClass { get; set; }

		#endregion

		object ICloneable.Clone()
		{
			return MemberwiseClone();
		}

		void IDisposable.Dispose()
		{
		}

		public Uri Source
		{
			get
			{
				return Browser.Source;
			}
			set
			{
				Browser.Source  = value;
			}
		}
	}
}