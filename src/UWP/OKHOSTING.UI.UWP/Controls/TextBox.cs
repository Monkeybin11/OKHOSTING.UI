using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.UWP.Controls
{
	public class TextBox : Windows.UI.Xaml.Controls.TextBox, ITextBox
	{
		public TextBox()
		{
			base.TextChanged += TextBox_TextChanged;
		}

		void IDisposable.Dispose()
		{
		}

		#region IInputControl

		private void TextBox_TextChanged(object sender, Windows.UI.Xaml.Controls.TextChangedEventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, ((IInputControl<string>)this).Value);
			}
		}

		public event EventHandler<string> ValueChanged;

		string IInputControl<string>.Value
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		#endregion

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
				return Platform.Current.Parse(((Windows.UI.Xaml.Media.SolidColorBrush)base.Foreground).Color);
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

		ITextBoxInputType ITextBox.InputType
		{
			get
			{
				if (base.InputScope == null || base.InputScope.Names.Count == 0)
				{
					return ITextBoxInputType.Text;
				}

				Windows.UI.Xaml.Input.InputScopeName scopeName = base.InputScope.Names[0];

				switch (scopeName.NameValue)
				{
					case Windows.UI.Xaml.Input.InputScopeNameValue.DateYear:
						//return ITextBoxInputType.Date;
						return ITextBoxInputType.DateTime;

					case Windows.UI.Xaml.Input.InputScopeNameValue.EmailSmtpAddress:
						return ITextBoxInputType.Email;

					case Windows.UI.Xaml.Input.InputScopeNameValue.Number:
						return ITextBoxInputType.Number;

					case Windows.UI.Xaml.Input.InputScopeNameValue.TelephoneNumber:
						return ITextBoxInputType.Telephone;

					case Windows.UI.Xaml.Input.InputScopeNameValue.Default:
						return ITextBoxInputType.Text;

					case Windows.UI.Xaml.Input.InputScopeNameValue.TimeHour:
						return ITextBoxInputType.Time;

					case Windows.UI.Xaml.Input.InputScopeNameValue.Url:
						return ITextBoxInputType.Url;

					default:
						return ITextBoxInputType.Text;
				}
			}
			set
			{
				Windows.UI.Xaml.Input.InputScopeName scopeName = new Windows.UI.Xaml.Input.InputScopeName();

				switch (value)
				{
					case ITextBoxInputType.Date:
						scopeName.NameValue = Windows.UI.Xaml.Input.InputScopeNameValue.DateYear;
						break;

					case ITextBoxInputType.DateTime:
						scopeName.NameValue = Windows.UI.Xaml.Input.InputScopeNameValue.DateYear;
						break;

					case ITextBoxInputType.Email:
						scopeName.NameValue = Windows.UI.Xaml.Input.InputScopeNameValue.EmailSmtpAddress;
						break;

					case ITextBoxInputType.Number:
						scopeName.NameValue = Windows.UI.Xaml.Input.InputScopeNameValue.Number;
						break;

					case ITextBoxInputType.Telephone:
						scopeName.NameValue = Windows.UI.Xaml.Input.InputScopeNameValue.TelephoneNumber;
						break;

					case ITextBoxInputType.Text:
						scopeName.NameValue = Windows.UI.Xaml.Input.InputScopeNameValue.Default;
						break;

					case ITextBoxInputType.Time:
						scopeName.NameValue = Windows.UI.Xaml.Input.InputScopeNameValue.TimeHour;
						break;

					case ITextBoxInputType.Url:
						scopeName.NameValue = Windows.UI.Xaml.Input.InputScopeNameValue.Url;
						break;

					default:
						scopeName.NameValue = Windows.UI.Xaml.Input.InputScopeNameValue.Default;
						break;
				}

				base.InputScope = new Windows.UI.Xaml.Input.InputScope();
				base.InputScope.Names.Add(scopeName);
			}
		}
	}
}