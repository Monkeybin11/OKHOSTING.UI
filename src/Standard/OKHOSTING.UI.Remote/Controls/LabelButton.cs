using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Remote.Controls
{
	/// <summary>
	/// Label button.
	/// <para xml:lang="es">
	/// Es un boton simple con una etiqueta de texto.
	/// </para>
	/// </summary>
	public class LabelButton: TextControl, ILabelButton
	{
		public string Text { get; set; }

		/// <summary>
		/// Raises after the value has changed by the user. Chages made in code will not raise this event.
		/// <para xml:lang="es">
		/// Se lanza despiues de que el valor fue cambiado por el usuario. Los cambios realizados en el código no lanzaran este evento.
		/// </para>
		/// </summary>
		public event EventHandler Click;
	}
}