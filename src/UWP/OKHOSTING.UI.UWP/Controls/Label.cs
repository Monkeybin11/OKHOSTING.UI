using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.UWP.Controls
{
	public class Label : Windows.UI.Xaml.Controls.RelativePanel, ILabel
	{
		protected readonly Windows.UI.Xaml.Controls.TextBlock InnerLabel = new Windows.UI.Xaml.Controls.TextBlock();

		public Label()
		{
			base.Children.Add(InnerLabel);
		}

		string ILabel.Text
		{
			get
			{
				return InnerLabel.Text;
			}
			set
			{
				InnerLabel.Text = value;
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
				return true;
			}
			set
			{
				//do nothing
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
				//do nothing
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
				return App.Current.Parse(base.Margin);
			}
			set
			{
				base.Margin = App.Current.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return App.Current.Parse(((Windows.UI.Xaml.Media.SolidColorBrush)base.Background).Color);
			}
			set
			{
				base.Background = new Windows.UI.Xaml.Media.SolidColorBrush(App.Current.Parse(value));
			}
		}

		Color IControl.BorderColor
		{
			get
			{
				return App.Current.Parse(((Windows.UI.Xaml.Media.SolidColorBrush)base.BorderBrush).Color);
			}
			set
			{
				base.BorderBrush = new Windows.UI.Xaml.Media.SolidColorBrush(App.Current.Parse(value));
			}
		}

		Thickness IControl.BorderWidth
		{
			get
			{
				return App.Current.Parse(base.BorderThickness);
			}
			set
			{
				base.BorderThickness = App.Current.Parse(value);
			}
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return App.Current.Parse(base.HorizontalAlignment);
			}
			set
			{
				base.HorizontalAlignment = App.Current.Parse(value);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return App.Current.Parse(base.VerticalAlignment);
			}
			set
			{
				base.VerticalAlignment = App.Current.Parse(value);
			}
		}

		#endregion

		#region ITextControl

		string ITextControl.FontFamily
		{
			get
			{
				return InnerLabel.FontFamily.Source;
			}
			set
			{
				InnerLabel.FontFamily = new Windows.UI.Xaml.Media.FontFamily(value);
			}
		}

		Color ITextControl.FontColor
		{
			get
			{
				return App.Current.Parse(((Windows.UI.Xaml.Media.SolidColorBrush) InnerLabel.Foreground).Color);
			}
			set
			{
				InnerLabel.Foreground = new Windows.UI.Xaml.Media.SolidColorBrush(App.Current.Parse(value));
			}
		}

		bool ITextControl.Bold
		{
			get
			{
				return InnerLabel.FontWeight.Weight == Windows.UI.Text.FontWeights.Bold.Weight;
			}
			set
			{
				if (value)
				{
					InnerLabel.FontWeight = Windows.UI.Text.FontWeights.Bold;
				}
				else
				{
					InnerLabel.FontWeight = Windows.UI.Text.FontWeights.Normal;
				}
			}
		}

		bool ITextControl.Italic
		{
			get
			{
				return InnerLabel.FontStyle == Windows.UI.Text.FontStyle.Italic;
			}
			set
			{
				if (value)
				{
					InnerLabel.FontStyle = Windows.UI.Text.FontStyle.Italic;
				}
				else
				{
					InnerLabel.FontStyle = Windows.UI.Text.FontStyle.Normal;
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
				return App.Current.Parse(InnerLabel.TextAlignment);
			}
			set
			{
				InnerLabel.TextAlignment = App.Current.ParseTextAlignment(value);
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
				return App.Current.Parse(base.Padding);
			}
			set
			{
				base.Padding = App.Current.Parse(value);
			}
		}

		double ITextControl.FontSize
		{
			get
			{
				return InnerLabel.FontSize;
			}
			set
			{
				InnerLabel.FontSize = value;
			}
		}

		#endregion
	}
}