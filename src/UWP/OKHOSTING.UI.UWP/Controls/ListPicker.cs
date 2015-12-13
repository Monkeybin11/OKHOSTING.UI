using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.UWP.Controls
{
	public class ListPicker : Windows.UI.Xaml.Controls.ListBox, IListPicker
	{
		IEnumerable<string> IListPicker.DataSource
		{
			get
			{
				return (IEnumerable<string>) base.ItemsSource;
			}
			set
			{
				base.ItemsSource = value;
			}
		}

		int IListPicker.SelectedIndex
		{
			get
			{
				return base.SelectedIndex;
			}
			set
			{
				base.SelectedIndex = value;
			}
		}

		string IListPicker.SelectedItem
		{
			get
			{
				return (string) base.SelectedItem;
			}
			set
			{
				base.SelectedItem = value;
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
				return base.FontFamily.Source;
			}
			set
			{
				base.FontFamily = new Windows.UI.Xaml.Media.FontFamily(value);
			}
		}

		double ITextControl.FontSize
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		Color ITextControl.FontColor
		{
			get
			{
				return App.Current.Parse(((Windows.UI.Xaml.Media.SolidColorBrush)base.Foreground).Color);
			}
			set
			{
				base.Foreground = new Windows.UI.Xaml.Media.SolidColorBrush(App.Current.Parse(value));
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
				return App.Current.Parse(base.HorizontalContentAlignment);
			}
			set
			{
				base.HorizontalContentAlignment = App.Current.Parse(value);
			}
		}

		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get
			{
				return App.Current.Parse(base.VerticalContentAlignment);
			}
			set
			{
				base.VerticalContentAlignment = App.Current.Parse(value);
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

		#endregion
	}
}
