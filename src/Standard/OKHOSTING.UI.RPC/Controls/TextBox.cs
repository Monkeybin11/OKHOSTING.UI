using OKHOSTING.UI.Controls;
using System;
using System.Drawing;

namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// A single line textbox
	/// <para xml:lang="es">Un cuadro de texto de una sola linea.</para>
	/// </summary>
	public class TextBox: TextControl, ITextBox
	{ 
		/// <summary>
		/// The type of input that will be allowed for this TextBox
		/// <para xml:lang="es">
		/// El tipo de entrada que sera permitida para este cuadro de texto.
		/// </para>
		/// </summary>
		public ITextBoxInputType InputType { get; set; }

		/// <summary>
		/// Maximum length allowed for the string Value. Zero means no limit.
		/// <para xml:lang="es">
		/// Longitud maxima permitida para el valor de cadena. Cero significa que no hay limite.
		/// </para>
		/// </summary>
		public int MaxLength { get; set; }

		/// <summary>
		/// The text that appears when the TextBox is empty (in a lighter color), use it as an alternative to a using a separate label to indicate this TextBox expected input
		/// </summary>
		public string Placeholder { get; set; }

		/// <summary>
		/// The font color of the Placeholder text
		/// </summary>
		public Color PlaceholderColor { get; set; }

		public string Value { get; set; }

		public event EventHandler<string> ValueChanged;
	}
}