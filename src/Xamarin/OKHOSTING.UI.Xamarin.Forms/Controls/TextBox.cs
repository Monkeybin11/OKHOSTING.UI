using OKHOSTING.UI.Controls;
using System;
using System.Drawing;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// A single line textbox
	/// <para xml:lang="es">
	/// Un cuadro de texto de una sola linea.
	/// </para>
	/// </summary>
	public class TextBox : Control<global::Xamarin.Forms.Entry>, ITextBox
	{
		/// <summary>
		/// Initializes a new instance of the TextBox class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase TextBox.
		/// </para>
		/// </summary>
		public TextBox()
		{
			Content.TextChanged += TextBox_TextChanged;
		}

		#region IInputControl

		/// <summary>
		/// Texts the box text changed.
		/// <para xml:lang="es">
		/// Cambia el texto del textbox y lanza el evento ValueChanged.
		/// </para>
		/// </summary>
		/// <returns>The box text changed.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void TextBox_TextChanged(object sender, global::Xamarin.Forms.TextChangedEventArgs e)
		{
			ValueChanged?.Invoke(this, ((IInputControl<string>)this).Value);
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">
		/// Ocurre cuando el valor del textbox es cambiado.
		/// </para>
		/// </summary>
		public event EventHandler<string> ValueChanged;

		/// <summary>
		/// Gets or sets the user input value.
		/// <para xml:lang="es">
		/// Obtiene o establece el valor de la entrada del usuario.
		/// </para>
		/// </summary>
		string IInputControl<string>.Value
		{
			get
			{
				return Content.Text;
			}
			set
			{
				Content.Text = value;
			}
		}

		#endregion

		#region ITextControl

		/// <summary>
		/// Gets or sets text control font family.
		/// <para xml:lang="es">
		/// Obtiene o establece la tipografia del texto del control.
		/// </para>
		/// </summary>
		string ITextControl.FontFamily
		{
			get
			{
				return Content.FontFamily;
			}
			set
			{
				Content.FontFamily = value;
			}
		}

		/// <summary>
		/// Gets or sets the color of the text control font.
		/// <para xml:lang="es">
		/// Obtiene o establece el color del texto del control.
		/// </para>
		/// </summary>
		Color ITextControl.FontColor
		{
			get
			{
				return Forms.Platform.Parse(Content.TextColor);
			}
			set
			{
				Content.TextColor = Forms.Platform.Parse(value);
			}
		}

		/// <summary>
		/// Size of the font, in DIP
		/// <para xml:lang="es">
		/// Tamaño del texto, en DIP
		/// </para>
		/// </summary>
		double ITextControl.FontSize
		{
			get
			{
				return Content.FontSize;
			}
			set
			{
				Content.FontSize = value;
			}
		}

		/// <summary>
		/// Gets or sets wether Text control bold or no.
		/// <para xml:lang="es">
		/// Obtiene o establece si el texto del control esta en negritas o no.
		/// </para>
		/// </summary>
		bool ITextControl.Bold
		{
			get
			{
				return Content.FontAttributes.HasFlag(global::Xamarin.Forms.FontAttributes.Bold);
			}
			set
			{
				Content.FontAttributes = global::Xamarin.Forms.FontAttributes.Bold;
			}
		}

		/// <summary>
		/// Gets or sets wether text control italic or not.
		/// <para xml:lang="es">
		/// Obtiene o establece si el texto del control esta en italica o no.
		/// </para>
		/// </summary>
		bool ITextControl.Italic
		{
			get
			{
				return Content.FontAttributes.HasFlag(global::Xamarin.Forms.FontAttributes.Italic);
			}
			set
			{
				Content.FontAttributes = global::Xamarin.Forms.FontAttributes.Italic;
			}
		}

		/// <summary>
		/// Gets or sets wether text control underline or not.
		/// <para xml:lang="es">
		/// Obtiene o establece si el texto del control esta subrayado.
		/// </para>
		/// </summary>	
		bool ITextControl.Underline
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets text control horizontal alignment.
		/// <para xml:lang="es">
		/// Obtiene o establece la laineacion horizontal del texto del control.
		/// </para>
		/// </summary>
		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{
			get
			{
				return Forms.Platform.Parse(Content.HorizontalTextAlignment);
			}
			set
			{
				Content.HorizontalTextAlignment = Forms.Platform.ParseTextAlignment(value);
			}
		}

		/// <summary>
		/// Gets or sets the text control vertical alignment.
		/// <para xml:lang="es">
		/// Obtiene o establece la alineacion vertical del texto.
		/// </para>
		/// </summary>
		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get
			{
				return Forms.Platform.ParseVerticalTextAlignment(Content.VerticalTextAlignment);
			}
			set
			{
				Content.VerticalTextAlignment = Forms.Platform.ParseTextAlignment(value);
			}
		}

		/// <summary>
		/// Gets or sets the controls text padding.
		/// <para xml:lang="es">
		/// Obtiene o establece el espacio entre un borde del control y su texto.
		/// </para>
		/// </summary>
		Thickness ITextControl.TextPadding
		{
			get;
			set;
		}

		#endregion

		#region ITextBox

		/// <summary>
		/// Gets or sets the type of the user Text box input.
		/// <para xml:lang="es">
		/// Obtiene o establece el tipo de entrada del texto del textbox.
		/// </para>
		/// </summary>
		ITextBoxInputType ITextBox.InputType
		{
			get
			{
				if (Content.Keyboard == global::Xamarin.Forms.Keyboard.Email) return ITextBoxInputType.Email;
				if (Content.Keyboard == global::Xamarin.Forms.Keyboard.Numeric) return ITextBoxInputType.Number;
				if (Content.Keyboard == global::Xamarin.Forms.Keyboard.Telephone) return ITextBoxInputType.Telephone;
				if (Content.Keyboard == global::Xamarin.Forms.Keyboard.Text) return ITextBoxInputType.Text;
				if (Content.Keyboard == global::Xamarin.Forms.Keyboard.Url) return ITextBoxInputType.Url;

				return ITextBoxInputType.Text;
			}
			set
			{
				switch (value)
				{
					case ITextBoxInputType.Date:
					case ITextBoxInputType.DateTime:
						Content.Keyboard = global::Xamarin.Forms.Keyboard.Default;
						break;

					case ITextBoxInputType.Email:
						Content.Keyboard = global::Xamarin.Forms.Keyboard.Email;
						break;

					case ITextBoxInputType.Number:
						Content.Keyboard = global::Xamarin.Forms.Keyboard.Numeric;
						break;

					case ITextBoxInputType.Telephone:
						Content.Keyboard = global::Xamarin.Forms.Keyboard.Telephone;
						break;

					case ITextBoxInputType.Text:
						Content.Keyboard = global::Xamarin.Forms.Keyboard.Text;
						break;

					case ITextBoxInputType.Time:
						Content.Keyboard = global::Xamarin.Forms.Keyboard.Default;
						break;

					case ITextBoxInputType.Url:
						Content.Keyboard = global::Xamarin.Forms.Keyboard.Url;
						break;

					default:
						Content.Keyboard = global::Xamarin.Forms.Keyboard.Default;
						break;
				}
			}
		}

		/// <summary>
		/// Gets or sets the length of the Text box max.
		/// <para xml:lang="es">
		/// Obtiene o establece la longitud maxima del textbox.
		/// </para>
		/// </summary>
		int ITextBox.MaxLength
		{
			get
			{
				return Content.MaxLength;
			}
			set
			{
				Content.MaxLength = value;
			}
		}

		/// <summary>
		/// The font color of the Placeholder text
		/// </summary>
		Color ITextBox.PlaceholderColor
		{
			get
			{
				return Forms.Platform.Parse(Content.PlaceholderColor);
			}
			set
			{
				Content.PlaceholderColor = Forms.Platform.Parse(value);
			}
		}

		/// <summary>
		/// The text that appears when the TextBox is empty (in a lighter color), use it as an alternative to a using a separate label to indicate this TextBox expected input
		/// </summary>
		string ITextBox.Placeholder
		{
			get
			{
				return Content.Placeholder;
			}
			set
			{
				Content.Placeholder = value;
			}
		}

		#endregion
	}
}