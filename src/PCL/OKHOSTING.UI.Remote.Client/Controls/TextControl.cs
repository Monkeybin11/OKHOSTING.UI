using System;
using System.Collections.Specialized;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Remote.Client.Controls
{
	/// <summary>
	/// It represents a text box control.
	/// <para xml:lang="es">Representa un control de cuadro de texto.</para>
	/// </summary>
	public class TextControl : Control, ITextControl
	{
		/// <summary>
		/// Gets or sets the FontColor of the control.
		/// <para xml:lang="es">Obtiene o establece el color del texto del control.</para>
		/// </summary>
		/// <value>The FontColor of the control.
		/// <para xml:lang="es">El color del texto del control.</para>
		/// </value>
		public Color FontColor
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the FontFamily of the control.
		/// <para xml:lang="es">Obtiene o establece la tipografia del texto del control</para>
		/// </summary>
		/// <value>The FontFamily of the control.
		/// <para xml:lang="es">La tipografia del texto del control.</para>
		/// </value>
		public string FontFamily
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the FontSize of the control.
		/// <para xml:lang="es">Obtiene o establece el tamaño del texto del control.</para>
		/// </summary>
		/// <value>The FontSize of the control.
		/// <para xml:lang="es">El tamaño del texto del control.</para>
		/// </value>
		public double FontSize
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the bold text of the control.
		/// <para xml:lang="es">Obtiene o establece el texto en negritas del control.</para>
		/// </summary>
		/// <value>The text bold of the control.
		/// <para xml:lang="es">El texto en negritas del control.</para>
		/// </value>
		public bool Bold
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the italic text of the control.
		/// <para xml:lang="es">Obtiene o establece el texto en italica del control</para>
		/// </summary>
		/// <value>The italic text of the control.
		/// <para xml:lang="es">El texto en italica del control</para>
		/// </value>
		public bool Italic
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the UnderLine text of the control.
		/// <para xml:lang="es">Obtiene o establece el texto en subrayado del control</para>
		/// </summary>
		/// <value>The UnderLine text of the control.
		/// <para xml:lang="es">El texto en subrayado del control</para>
		/// </value>
		public bool Underline
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the TextHorizontalAlignment of the control.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal del texto del control</para>
		/// </summary>
		public HorizontalAlignment TextHorizontalAlignment
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the TextVerticalAlignment of the control.
		/// <para xml:lang="es">Obtiene o establece la alineación vertical del control.</para>
		/// </summary>
		public VerticalAlignment TextVerticalAlignment
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the padding text of the control.
		/// <para xml:lang="es">obtiene o establece el padding del texto del control.</para>
		/// </summary>
		public Thickness TextPadding
		{
			get;
			set;
		}
	}
}