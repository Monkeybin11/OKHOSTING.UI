using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Remote.Controls
{
	/// <summary>
	/// It contains the events of Button.
	/// <para xml:lang="es">
	/// Contiene los eventos del Button.
	/// </para>
	/// </summary>
	public class Button: TextControl, IButton
	{
		public string Text
		{
			get; set;
		}

		/// <summary>
		/// Raises after the user clicked on the button
		/// <para xml:lang="es">
		/// Se lanza despues de que el usuario ha hecho clic en el botón.
		/// </para>
		/// </summary>
		public event EventHandler Click;
	}
}