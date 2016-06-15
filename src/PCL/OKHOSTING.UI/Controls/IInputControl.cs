using System;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// Represents a control that is used for user input
	/// <para xml:lang="es">
	/// Representa un control que es usado para entradas del usuario.
	/// </para>
	/// </summary>
	/// <typeparam name="T">Type of data that this control will allow the user to input
	/// <para xml:lang="es">Tipo de dato que este control permitira al usuario introducir.</para>
	/// </typeparam>
	public interface IInputControl<T> : IControl
	{
		/// <summary>
		/// The actual value that is being shown to the user, and/or that the user has set or modified
		/// <para xml:lang="es">
		/// El valor actual que se muestra al usuario, y/o que el usuario ha establecido o modificado.
		/// </para>
		/// </summary>
		T Value { get; set; }

		/// <summary>
		/// Raises after the value has changed by the user. Chages made in code will not raise this event.
		/// <para xml:lang="es">
		/// Se lanza despues de que el valor fue cambiado por el usuario. Los cambios realizados en el código no lanzaran este evento.
		/// </para>
		/// </summary>
		event EventHandler<T> ValueChanged;
	}
}