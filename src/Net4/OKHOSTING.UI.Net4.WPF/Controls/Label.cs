using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class Label : System.Windows.Controls.Label, ILabel
	{
		public string Text
		{
			get
			{
				return (string) base.Content;
			}

			set
			{
				base.Content = value;
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
				return App.Parse(base.Margin);
			}
			set
			{
				base.Margin = App.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return App.Parse(((System.Windows.Media.SolidColorBrush)base.Background).Color);
			}
			set
			{
				base.Background = new System.Windows.Media.SolidColorBrush(App.Parse(value));
			}
		}

		Color IControl.BorderColor
		{
			get
			{
				return App.Parse(((System.Windows.Media.SolidColorBrush)base.BorderBrush).Color);
			}
			set
			{
				base.BorderBrush = new System.Windows.Media.SolidColorBrush(App.Parse(value));
			}
		}

		Thickness IControl.BorderWidth
		{
			get
			{
				return App.Parse(base.BorderThickness);
			}
			set
			{
				base.BorderThickness = App.Parse(value);
			}
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return App.Parse(base.HorizontalAlignment);
			}
			set
			{
				base.HorizontalAlignment = App.Parse(value);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return App.Parse(base.VerticalAlignment);
			}
			set
			{
				base.VerticalAlignment = App.Parse(value);
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
				return App.Parse(((System.Windows.Media.SolidColorBrush)base.Foreground).Color);
			}
			set
			{
				base.Foreground = new System.Windows.Media.SolidColorBrush(App.Parse(value));
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
				throw new NotImplementedException();
			}
		}

		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{
			get
			{
				return App.Parse(base.HorizontalContentAlignment);
			}
			set
			{
				base.HorizontalContentAlignment = App.Parse(value);
			}
		}

		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get
			{
				return App.Parse(base.VerticalContentAlignment);
			}
			set
			{
				base.VerticalContentAlignment = App.Parse(value);
			}
		}

		Thickness ITextControl.TextPadding
		{
			get
			{
				return App.Parse(base.Padding);
			}
			set
			{
				base.Padding = App.Parse(value);
			}
		}

		#endregion
	}
}