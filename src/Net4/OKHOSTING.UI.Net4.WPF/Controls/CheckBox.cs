using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class CheckBox : System.Windows.Controls.CheckBox, ICheckBox
	{
		public bool SelectedValue
		{
			get
			{
				if (!base.IsChecked.HasValue)
				{
					return false;
				}

				return base.IsChecked.Value;
			}
			set
			{
				base.IsChecked = value;
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
				return Platform.Current.Parse(((System.Windows.Media.SolidColorBrush)base.Background).Color);
			}
			set
			{
				base.Background = new System.Windows.Media.SolidColorBrush(Platform.Current.Parse(value));
			}
		}

		Color IControl.BorderColor
		{
			get
			{
				return Platform.Current.Parse(((System.Windows.Media.SolidColorBrush)base.BorderBrush).Color);
			}
			set
			{
				base.BorderBrush = new System.Windows.Media.SolidColorBrush(Platform.Current.Parse(value));
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
				base.FontFamily = new System.Windows.Media.FontFamily(value);
			}
		}

		Color ITextControl.FontColor
		{
			get
			{
				return Platform.Current.Parse(((System.Windows.Media.SolidColorBrush)base.Foreground).Color);
			}
			set
			{
				base.Foreground = new System.Windows.Media.SolidColorBrush(Platform.Current.Parse(value));
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
