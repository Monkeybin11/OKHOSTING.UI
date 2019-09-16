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
		public ITextBoxInputType InputType
		{
			get
			{
				return (ITextBoxInputType) Get(nameof(InputType));
			}
			set
			{
				Set(nameof(InputType), value);
			}
		}

		/// <summary>
		/// Maximum length allowed for the string Value. Zero means no limit.
		/// <para xml:lang="es">
		/// Longitud maxima permitida para el valor de cadena. Cero significa que no hay limite.
		/// </para>
		/// </summary>
		public int MaxLength
		{
			get
			{
				return (int) Get(nameof(MaxLength));
			}
			set
			{
				Set(nameof(MaxLength), value);
			}
		}

		/// <summary>
		/// The text that appears when the TextBox is empty (in a lighter color), use it as an alternative to a using a separate label to indicate this TextBox expected input
		/// </summary>
		public string Placeholder
		{
			get
			{
				return (string) Get(nameof(Placeholder));
			}
			set
			{
				Set(nameof(Placeholder), value);
			}
		}

		/// <summary>
		/// The font color of the Placeholder text
		/// </summary>
		public Color PlaceholderColor
		{
			get
			{
				return (Color) Get(nameof(PlaceholderColor));
			}
			set
			{
				Set(nameof(PlaceholderColor), value);
			}
		}

		public string Value
		{
			get
			{
				return (string) Get(nameof(Value));
			}
			set
			{
				Set(nameof(Value), value);
			}
		}

		public event EventHandler<string> ValueChanged
		{
			add
			{
				AddHybridEventHandler(nameof(ValueChanged), value);
			}
			remove
			{
				RemoveHybridEventHandler(nameof(ValueChanged), value);
			}
		}
	}
}