using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class TextBox : System.Windows.Controls.TextBox, ITextBox
	{

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

		ITextBoxInputType ITextBox.InputType
		{
			get
			{
				if (base.InputScope == null || base.InputScope.Names.Count == 0)
				{
					return ITextBoxInputType.Text;
				}

				System.Windows.Input.InputScopeName scopeName = (System.Windows.Input.InputScopeName)base.InputScope.Names[0];

				switch (scopeName.NameValue)
				{
					case System.Windows.Input.InputScopeNameValue.Date:
						//return ITextBoxInputType.Date;
						return ITextBoxInputType.DateTime;

					case System.Windows.Input.InputScopeNameValue.EmailSmtpAddress:
						return ITextBoxInputType.Email;

					case System.Windows.Input.InputScopeNameValue.Number:
						return ITextBoxInputType.Number;

					case System.Windows.Input.InputScopeNameValue.TelephoneNumber:
						return ITextBoxInputType.Telephone;

					case System.Windows.Input.InputScopeNameValue.Default:
						return ITextBoxInputType.Text;

					case System.Windows.Input.InputScopeNameValue.Time:
						return ITextBoxInputType.Time;

					case System.Windows.Input.InputScopeNameValue.Url:
						return ITextBoxInputType.Url;

					default:
						return ITextBoxInputType.Text;
				}
			}
			set
			{
				System.Windows.Input.InputScopeName scopeName = new System.Windows.Input.InputScopeName();

				switch (value)
				{
					case ITextBoxInputType.Date:
						scopeName.NameValue = System.Windows.Input.InputScopeNameValue.Date;
						break;

					case ITextBoxInputType.DateTime:
						scopeName.NameValue = System.Windows.Input.InputScopeNameValue.Date;
						break;

					case ITextBoxInputType.Email:
						scopeName.NameValue = System.Windows.Input.InputScopeNameValue.EmailSmtpAddress;
						break;

					case ITextBoxInputType.Number:
						scopeName.NameValue = System.Windows.Input.InputScopeNameValue.Number;
						break;

					case ITextBoxInputType.Telephone:
						scopeName.NameValue = System.Windows.Input.InputScopeNameValue.TelephoneNumber;
						break;

					case ITextBoxInputType.Text:
						scopeName.NameValue = System.Windows.Input.InputScopeNameValue.Default;
						break;

					case ITextBoxInputType.Time:
						scopeName.NameValue = System.Windows.Input.InputScopeNameValue.Time;
						break;

					case ITextBoxInputType.Url:
						scopeName.NameValue = System.Windows.Input.InputScopeNameValue.Url;
						break;

					default:
						scopeName.NameValue = System.Windows.Input.InputScopeNameValue.Default;
						break;
				}

				base.InputScope = new System.Windows.Input.InputScope();
				base.InputScope.Names.Add(scopeName);
			}
		}
    }
}