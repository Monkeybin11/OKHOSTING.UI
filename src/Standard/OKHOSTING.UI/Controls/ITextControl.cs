using System;
using System.Collections.Generic;
using System.Drawing;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A control that can contain text, therefore has font properties
	/// <para xml:lang="es">
	/// Un control que puede contener texto, por lo tanto, tiene propiedades de texto.
	/// </para>
	/// </summary>
	public interface ITextControl: IControl
	{
		/// <summary>
		/// Name of the font
		/// <para xml:lang="es">
		/// Nombre de la fuente.
		/// </para>
		/// </summary>
		string FontFamily { get; set; }

		/// <summary>
		/// Color of the font
		/// <para xml:lang="es">
		/// Color del texto.
		/// </para>
		/// </summary>
		Color FontColor { get; set; }

		/// <summary>
		/// Size of the font, in DIP
		/// <para xml:lang="es">
		/// Tamaño del texto, en DIP
		/// </para>
		/// </summary>
		double FontSize { get; set; }

		/// <summary>
		/// Wether the font is bold or not
		/// <para xml:lang="es">
		/// Si el texto esta en negrita o no.
		/// </para>
		/// </summary>
		bool Bold { get; set; }

		/// <summary>
		/// Wether the font is italic or not
		/// <para xml:lang="es">
		/// Si el texto esta en italica o no.
		/// </para>
		/// </summary>
		bool Italic { get; set; }

		/// <summary>
		/// Wether the font is underscored or not
		/// <para xml:lang="es">
		/// Si el texto esta en subrayado o no.
		/// </para>
		/// </summary>
		bool Underline { get; set; }

		/// <summary>
		/// Horizontal alignment of the text with respect to the control
		/// <para xml:lang="es">
		/// Alineación horizontal del texto con respecto al control.
		/// </para>
		/// </summary>
		HorizontalAlignment TextHorizontalAlignment { get; set; }

		/// <summary>
		/// Vertical alignment of the text with respect to the control
		/// <para xml:lang="es">
		/// Alineacion vertical del texto con respecto al control.
		/// </para>
		/// </summary>
		VerticalAlignment TextVerticalAlignment { get; set; }

		/// <summary>
		/// Space that this control will set between a it's border and it's text.
		/// <para xml:lang="es">
		/// Espacio que este control se establecera entre un borde y el texto.
		/// </para>
		/// </summary>
		Thickness TextPadding { get; set; }
	}
}