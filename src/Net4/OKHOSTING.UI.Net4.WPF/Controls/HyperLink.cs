using System;
using System.Drawing;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class HyperLink : System.Windows.Controls.TextBlock, IHyperLink
	{
		protected readonly System.Windows.Documents.Run Run;
		protected readonly System.Windows.Documents.Hyperlink InnerLink;

		public HyperLink()
		{
			Run = new System.Windows.Documents.Run();
			InnerLink = new System.Windows.Documents.Hyperlink(Run);
			InnerLink.RequestNavigate += InnerLink_RequestNavigate;

			base.Inlines.Clear();
			base.Inlines.Add(Run);
		}

		private void InnerLink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
		{
			System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(e.Uri.AbsoluteUri));
			e.Handled = true;
		}

		public Uri Uri
		{
			get
			{
				return InnerLink.NavigateUri;
			}
			set
			{
				InnerLink.NavigateUri = value;
			}
		}

		string IHyperLink.Text
		{
			get
			{
				return Run.Text;
			}
			set
			{
				Run.Text = value;
			}
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
				return Platform.Parse(((System.Windows.Media.SolidColorBrush) base.Background).Color);
			}
			set
			{
				base.Background = new System.Windows.Media.SolidColorBrush(Platform.Parse(value));
			}
		}

		Color IControl.BorderColor
		{
			get; set;
		}

		Thickness IControl.BorderWidth
		{
			get; set;
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
				return (IControl)base.Parent;
			}
		}

		#endregion

		#region ITextControl

		string ITextControl.FontFamily
		{
			get
			{
				return base.FontFamily.Source;
			}
			set
			{
				base.FontFamily = new System.Windows.Media.FontFamily(value);
			}
		}

		Color ITextControl.FontColor
		{
			get
			{
				return Platform.Parse(((System.Windows.Media.SolidColorBrush)base.Foreground).Color);
			}
			set
			{
				base.Foreground = new System.Windows.Media.SolidColorBrush(Platform.Parse(value));
			}
		}

		bool ITextControl.Bold
		{
			get
			{
				return base.FontWeight == System.Windows.FontWeights.Bold;
			}
			set
			{
				base.FontWeight = System.Windows.FontWeights.Bold;
			}
		}

		bool ITextControl.Italic
		{
			get
			{
				return base.FontStyle == System.Windows.FontStyles.Italic;
			}
			set
			{
				base.FontStyle = System.Windows.FontStyles.Italic;
			}
		}

		bool ITextControl.Underline
		{
			get
			{
				return false;
			}
			set
			{
				//throw new NotImplementedException();
			}
		}

		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{
			get
			{
				return Platform.Parse(base.TextAlignment);
			}
			set
			{
				base.TextAlignment = Platform.ParseTextAlignment(value);
			}
		}

		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get
			{
				return UI.VerticalAlignment.Top;
			}
			set
			{
				//do nothing
			}
		}

		Thickness ITextControl.TextPadding
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

		#endregion
	}
}