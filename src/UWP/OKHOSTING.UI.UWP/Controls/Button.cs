using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.UWP.Controls
{
	public class Button : Windows.UI.Xaml.Controls.Button, IButton
	{
		public Button()
		{
			base.Click += Button_Click;
		}

		private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			if (Click != null)
			{
				Click(sender, new EventArgs());
			}
		}

		public new event EventHandler Click;

		string IButton.Text
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
				return base.Visibility == Windows.UI.Xaml.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = Windows.UI.Xaml.Visibility.Visible;
				}
				else
				{
					base.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
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
				return Platform.Current.Parse(base.Margin);
			}
			set
			{
				base.Margin = Platform.Current.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return Platform.Current.Parse(((Windows.UI.Xaml.Media.SolidColorBrush)base.Background).Color);
			}
			set
			{
				base.Background = new Windows.UI.Xaml.Media.SolidColorBrush(Platform.Current.Parse(value));
			}
		}

		Color IControl.BorderColor
		{
			get
			{
				return Platform.Current.Parse(((Windows.UI.Xaml.Media.SolidColorBrush)base.BorderBrush).Color);
			}
			set
			{
				base.BorderBrush = new Windows.UI.Xaml.Media.SolidColorBrush(Platform.Current.Parse(value));
			}
		}

		Thickness IControl.BorderWidth
		{
			get
			{
				return Platform.Current.Parse(base.BorderThickness);
			}
			set
			{
				base.BorderThickness = Platform.Current.Parse(value);
			}
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Platform.Current.Parse(base.HorizontalAlignment);
			}
			set
			{
				base.HorizontalAlignment = Platform.Current.Parse(value);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Platform.Current.Parse(base.VerticalAlignment);
			}
			set
			{
				base.VerticalAlignment = Platform.Current.Parse(value);
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
				base.FontFamily = new Windows.UI.Xaml.Media.FontFamily(value);
			}
		}

		Color ITextControl.FontColor
		{
			get
			{
				return Platform.Current.Parse(((Windows.UI.Xaml.Media.SolidColorBrush) base.Foreground).Color);
			}
			set
			{
				base.Foreground = new Windows.UI.Xaml.Media.SolidColorBrush(Platform.Current.Parse(value));
			}
		}

		bool ITextControl.Bold
		{
			get
			{
				return base.FontWeight.Weight == Windows.UI.Text.FontWeights.Bold.Weight;
			}
			set
			{
				if (value)
				{
					base.FontWeight = Windows.UI.Text.FontWeights.Bold;
				}
				else
				{
					base.FontWeight = Windows.UI.Text.FontWeights.Normal;
				}
			}
		}

		bool ITextControl.Italic
		{
			get
			{
				return base.FontStyle == Windows.UI.Text.FontStyle.Italic;
			}
			set
			{
				if (value)
				{
					base.FontStyle = Windows.UI.Text.FontStyle.Italic;
				}
				else
				{
					base.FontStyle = Windows.UI.Text.FontStyle.Normal;
				}
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
				//do nothing
			}
		}

		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{
			get
			{
				return Platform.Current.Parse(base.HorizontalContentAlignment);
			}
			set
			{
				base.HorizontalContentAlignment = Platform.Current.Parse(value);
			}
		}

		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get
			{
				return Platform.Current.Parse(base.VerticalContentAlignment);
			}
			set
			{
				base.VerticalContentAlignment = Platform.Current.Parse(value);
			}
		}

		Thickness ITextControl.TextPadding
		{
			get
			{
				return Platform.Current.Parse(base.Padding);
			}
			set
			{
				base.Padding = Platform.Current.Parse(value);
			}
		}

		#endregion
	}
}
