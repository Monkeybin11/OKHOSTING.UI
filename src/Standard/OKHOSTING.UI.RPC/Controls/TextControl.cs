using System.Drawing;

namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// A control that can contain text, therefore has font properties
	/// <para xml:lang="es">
	/// Un control que puede contener texto, por lo tanto, tiene propiedades de texto.
	/// </para>
	/// </summary>
	public class TextControl: Control
	{
		/// <summary>
		/// Name of the font
		/// <para xml:lang="es">
		/// Nombre de la fuente.
		/// </para>
		/// </summary>
		public string FontFamily
		{
			get
			{
				return (string) Get(nameof(FontFamily));
			}
			set
			{
				Set(nameof(FontFamily), value);
			}
		}

		/// <summary>
		/// Color of the font
		/// <para xml:lang="es">
		/// Color del texto.
		/// </para>
		/// </summary>
		public Color FontColor
		{
			get
			{
				return (Color) Get(nameof(FontColor));
			}
			set
			{
				Set(nameof(FontColor), value);
			}
		}

		/// <summary>
		/// Size of the font, in DIP
		/// <para xml:lang="es">
		/// Tamaño del texto, en DIP
		/// </para>
		/// </summary>
		public double FontSize
		{
			get
			{
				return (double) Get(nameof(FontSize));
			}
			set
			{
				Set(nameof(FontSize), value);
			}
		}

		/// <summary>
		/// Wether the font is bold or not
		/// <para xml:lang="es">
		/// Si el texto esta en negrita o no.
		/// </para>
		/// </summary>
		public bool Bold
		{
			get
			{
				return (bool) Get(nameof(Bold));
			}
			set
			{
				Set(nameof(Bold), value);
			}
		}

		/// <summary>
		/// Wether the font is italic or not
		/// <para xml:lang="es">
		/// Si el texto esta en italica o no.
		/// </para>
		/// </summary>
		public bool Italic
		{
			get
			{
				return (bool) Get(nameof(Italic));
			}
			set
			{
				Set(nameof(Italic), value);
			}
		}

		/// <summary>
		/// Wether the font is underscored or not
		/// <para xml:lang="es">
		/// Si el texto esta en subrayado o no.
		/// </para>
		/// </summary>
		public bool Underline
		{
			get
			{
				return (bool) Get(nameof(Underline));
			}
			set
			{
				Set(nameof(Underline), value);
			}
		}

		/// <summary>
		/// Horizontal alignment of the text with respect to the control
		/// <para xml:lang="es">
		/// Alineación horizontal del texto con respecto al control.
		/// </para>
		/// </summary>
		public HorizontalAlignment TextHorizontalAlignment
		{
			get
			{
				return (HorizontalAlignment) Get(nameof(TextHorizontalAlignment));
			}
			set
			{
				Set(nameof(TextHorizontalAlignment), value);
			}
		}

		/// <summary>
		/// Vertical alignment of the text with respect to the control
		/// <para xml:lang="es">
		/// Alineacion vertical del texto con respecto al control.
		/// </para>
		/// </summary>
		public VerticalAlignment TextVerticalAlignment
		{
			get
			{
				return (VerticalAlignment) Get(nameof(TextVerticalAlignment));
			}
			set
			{
				Set(nameof(TextVerticalAlignment), value);
			}
		}

		/// <summary>
		/// Space that this control will set between a it's border and it's text.
		/// <para xml:lang="es">
		/// Espacio que este control se establecera entre un borde y el texto.
		/// </para>
		/// </summary>
		public Thickness TextPadding
		{
			get
			{
				return (Thickness) Get(nameof(TextPadding));
			}
			set
			{
				Set(nameof(TextPadding), value);
			}
		}
	}
}