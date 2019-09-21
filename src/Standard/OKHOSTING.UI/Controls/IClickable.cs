using System;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A clickable control
	/// <para xml:lang="es">
	/// Un control clickeable
	/// </para>
	/// </summary>
	public interface IClickable : IControl
	{
		/// <summary>
		/// Raises after the value has changed by the user. Chages made in code will not raise this event.
		/// <para xml:lang="es">
		/// Se lanza despiues de que el valor fue cambiado por el usuario. Los cambios realizados en el código no lanzaran este evento.
		/// </para>
		/// </summary>
		event EventHandler Click;
	}
}