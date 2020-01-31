using System;
using System.Drawing;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class TextBox : System.Windows.Controls.TextBox, ITextBox
	{
		public TextBox()
		{
			base.TextChanged += TextBox_TextChanged;
			base.LostFocus += TextBox_LostFocus;
			base.GotFocus += TextBox_GotFocus;
		}

		void IDisposable.Dispose()
		{
		}

		#region IInputControl

		private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			ValueChanged?.Invoke(this, ((IInputControl<string>)this).Value);

		}

		string IInputControl<string>.Value
		{
			get
			{
				if (IsPlaceHolder)
				{
					return null;
				}
				else
				{
					return base.Text;
				}
			}
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					HidePlaceholder();
					base.Text = value;
				}
				else
				{
					ShowPlaceholder();
				}
			}
		}

		public event EventHandler<string> ValueChanged;

		#endregion

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

		/// <summary>
		/// Private member to store the FontColor
		/// </summary>
		private Color _FontColor;

		Color ITextControl.FontColor
		{
			get
			{
				return _FontColor;
			}
			set
			{
				_FontColor = value;
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
				return Platform.Parse(base.HorizontalContentAlignment);
			}
			set
			{
				base.HorizontalContentAlignment = Platform.Parse(value);
			}
		}

		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get
			{
				return Platform.Parse(base.VerticalContentAlignment);
			}
			set
			{
				base.VerticalContentAlignment = Platform.Parse(value);
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

		/// <summary>
		/// Private member to store the placeholder
		/// </summary>
		private string _Placeholder;

		/// <summary>
		/// The text that appears when the TextBox is empty (in a lighter color), use it as an alternative to a using a separate label to indicate this TextBox expected input
		/// </summary>
		string ITextBox.Placeholder
		{
			get
			{
				return _Placeholder;
			}
			set
			{
				_Placeholder = value;
				ShowPlaceholder();
			}
		}

		/// <summary>
		/// Private member to store the PlaceholderColor
		/// </summary>
		private Color _PlaceholderColor;

		/// <summary>
		/// The font color of the Placeholder text
		/// </summary>
		Color ITextBox.PlaceholderColor
		{
			get
			{
				return _PlaceholderColor;
			}
			set
			{
				_PlaceholderColor = value;
				ShowPlaceholder();
			}
		}

		/// <summary>
		/// Wheter the placeholder is currently being displayed or not. It will only be displayed
		/// when Value is empty and the TextBox does not the have the focus
		/// </summary>
		private bool IsPlaceHolder;

		private void ShowPlaceholder()
		{
			if (string.IsNullOrEmpty(base.Text) || base.Text == ((ITextBox) this).Placeholder)
			{
				base.Text = ((ITextBox) this).Placeholder;
				base.Foreground = new System.Windows.Media.SolidColorBrush(Platform.Parse(((ITextBox) this).PlaceholderColor));
				IsPlaceHolder = true;
			}
		}

		private void HidePlaceholder()
		{
			if (base.Text == ((ITextBox) this).Placeholder)
			{
				base.Text = null;
				base.Foreground = new System.Windows.Media.SolidColorBrush(Platform.Parse(((ITextBox) this).FontColor));
				IsPlaceHolder = false;
			}
		}

		private void TextBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			ShowPlaceholder();
		}

		private void TextBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			HidePlaceholder();
		}
	}
}