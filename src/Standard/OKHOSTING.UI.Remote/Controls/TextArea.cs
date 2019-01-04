using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Remote.Controls
{
	/// <summary>
	/// A multiline textbox
	/// <para xml:lang="es">
	/// Un cuadro de texto de multiples lineas.
	/// </para>
	/// </summary>
	public class TextArea : TextControl, ITextArea
	{
		public string Value { get; set; }

		public event EventHandler<string> ValueChanged;
	}
}