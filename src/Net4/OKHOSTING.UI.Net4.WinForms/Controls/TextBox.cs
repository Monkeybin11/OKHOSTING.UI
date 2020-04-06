using System;
using System.Drawing;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class TextBox : System.Windows.Forms.TextBox, ITextBox
	{
		public TextBox()
		{
			base.TextChanged += PasswordTextBox_TextChanged;
			base.GotFocus += TextBox_GotFocus;
			base.LostFocus += TextBox_LostFocus;
		}
		
		#region IInputControl

		private void PasswordTextBox_TextChanged(object sender, System.EventArgs e)
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
					base.Width = (int) value;
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
					base.Height = (int) value;
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
				return base.BackColor;
			}
			set
			{
				base.BackColor = Platform.RemoveAlpha(value);
			}
		}

		Color IControl.BorderColor { get; set; }

		Thickness IControl.BorderWidth { get; set; }

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Platform.Parse(base.Anchor).Item1;
			}
			set
			{
				base.Anchor = Platform.ParseAnchor(value, ((IControl)this).VerticalAlignment);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Platform.Parse(base.Anchor).Item2;
			}
			set
			{
				base.Anchor = Platform.ParseAnchor(((IControl)this).HorizontalAlignment, value);
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
				return (IControl) base.Parent;
			}
		}

		#endregion

		#region ITextControl

		Color ITextControl.FontColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = Platform.RemoveAlpha(value);
			}
		}

		string ITextControl.FontFamily
		{
			get
			{
				return base.Font.FontFamily.Name;
			}
			set
			{
				base.Font = new System.Drawing.Font(value, (float)base.FontHeight);
			}
		}

		double ITextControl.FontSize
		{
			get
			{
				return base.FontHeight;
			}
			set
			{
				base.FontHeight = (int) value;
			}
		}

		bool ITextControl.Bold
		{
			get
			{
				return base.Font.Bold;
			}
			set
			{
				base.Font = new System.Drawing.Font(Font.Name, base.Font.Size, value ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
			}
		}

		bool ITextControl.Italic
		{
			get
			{
				return base.Font.Italic;
			}
			set
			{
				base.Font = new System.Drawing.Font(Font.Name, base.Font.Size, value ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular);
			}
		}

		bool ITextControl.Underline
		{
			get
			{
				return base.Font.Underline;
			}

			set
			{
				base.Font = new System.Drawing.Font(Font.Name, base.Font.Size, value ? System.Drawing.FontStyle.Underline : System.Drawing.FontStyle.Regular);
			}
		}

		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{
			get
			{
				return Platform.Parse(base.TextAlign);
			}
			set
			{
				base.TextAlign = Platform.Parse(value);
			}
		}

		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get
			{
				return VerticalAlignment.Top;
			}
			set
			{
				//not supported
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

		/// <summary>
		/// The type of input that will be allowed for this TextBox
		/// <para xml:lang="es">
		/// El tipo de entrada que sera permitida para este cuadro de texto.
		/// </para>
		/// </summary>
		ITextBoxInputType ITextBox.InputType
		{
			get; set;
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
			var placeholder = ((ITextBox) this).Placeholder;

			if (!string.IsNullOrEmpty(placeholder) && (string.IsNullOrEmpty(base.Text) || base.Text == placeholder))
			{
				base.Text = ((ITextBox) this).Placeholder;
				base.ForeColor = ((ITextBox) this).PlaceholderColor;
				IsPlaceHolder = true;
			}
		}

		private void HidePlaceholder()
		{
			if (base.Text == ((ITextBox) this).Placeholder)
			{
				base.Text = null;
				base.ForeColor = ((ITextBox) this).FontColor;
				IsPlaceHolder = false;
			}
		}

		private void TextBox_LostFocus(object sender, EventArgs e)
		{
			ShowPlaceholder();
		}

		private void TextBox_GotFocus(object sender, EventArgs e)
		{
			HidePlaceholder();
		}

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
		{
			Platform.DrawBorders(this, pevent);
			base.OnPaint(pevent);
		}
	}
}
