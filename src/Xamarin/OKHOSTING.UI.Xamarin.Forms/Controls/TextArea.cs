using OKHOSTING.UI.Controls;
using System;
using System.Drawing;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// A multiline textbox
	/// <para xml:lang="es">
	/// Un cuadro de texto de multiples lineas.
	/// </para>
	/// </summary>
	public class TextArea : Control<global::Xamarin.Forms.Editor>, ITextArea
	{
		/// <summary>
		/// Initializes a new instance of the TextArea class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase TextArea.
		/// </para>
		/// </summary>
		public TextArea()
		{
			Content.TextChanged += TextArea_TextChanged;
		}

		#region IInputControl

		/// <summary>
		/// Texts the area text changed.
		/// <para xml:lang="es">
		/// Cambia el texto del cuadro cuando el usuario lo cambia.
		/// </para>
		/// </summary>
		/// <returns>The area text changed.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void TextArea_TextChanged(object sender, global::Xamarin.Forms.TextChangedEventArgs e)
		{
			ValueChanged?.Invoke(this, ((IInputControl<string>)this).Value);
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">
		/// Ocurre cuando el valor es cambiado.
		/// </para>
		/// </summary>
		public event EventHandler<string> ValueChanged;

		/// <summary>
		/// Gets or sets the user input value.
		/// <para xml:lang="es">
		/// Obtiene o establece el valor de entrada del usuario.
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
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the text control vertical alignment.
		/// <para xml:lang="es">
		/// Obtiene o establece la alineacion vertical del texto.
		/// </para>
		/// </summary>
		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get;
			set;
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
	}
}