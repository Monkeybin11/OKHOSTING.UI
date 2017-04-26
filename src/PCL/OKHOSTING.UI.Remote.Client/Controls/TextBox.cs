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
	public class TextBox : TextControl, ITextBox
	{
		/// <summary>
		/// Gets or sets the user imput value.
		/// <para xml:lang="es">Obtiene o establece el valor de entrada del usuario</para>
		/// </summary>
		/// <value>The input value.
		/// <para xml:lang="es">El valor de entrada.</para>
		/// </value>
		public string Value
		{
			get;
			set;
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">Ocurre cuando el valor fue cambiado.</para>
		/// </summary>
		public event EventHandler<string> ValueChanged;

		/// <summary>
		/// The text that appears when the TextBox is empty (in a lighter color), use it as an alternative to a using a separate label to indicate this TextBox expected input
		/// </summary>
		public string Placeholder
		{
			get;
			set;
		}

		/// <summary>
		/// The font color of the Placeholder text
		/// </summary>
		public Color PlaceholderColor
		{
			get;
			set;
		}

		public ITextBoxInputType InputType
		{
			get;
			set;
		}

		public int MaxLength
		{
			get;
			set;
		}
	}
}