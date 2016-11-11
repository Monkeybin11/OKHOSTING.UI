using System;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A single line textbox
	/// <para xml:lang="es">Un cuadro de texto de una sola linea.</para>
	/// </summary>
	public interface ITextBox: ITextControl, IInputControl<string>
	{ 
		/// <summary>
		/// The type of input that will be allowed for this TextBox
		/// <para xml:lang="es">
		/// El tipo de entrada que sera permitida para este cuadro de texto.
		/// </para>
		/// </summary>
		ITextBoxInputType InputType { get; set; }

		/// <summary>
		/// Maximum length allowed for the string Value. Zero means no limit.
		/// <para xml:lang="es">
		/// Longitud maxima permitida para el valor de cadena. Cero significa que no hay limite.
		/// </para>
		/// </summary>
		int MaxLength { get; set; }

		/// <summary>
		/// The text that appears when the TextBox is empty (in a lighter color), use it as an alternative to a using a separate label to indicate this TextBox expected input
		/// </summary>
		string Placeholder { get; set; }

		/// <summary>
		/// The font color of the Placeholder text
		/// </summary>
		Color PlaceholderColor { get; set; }
	}
}