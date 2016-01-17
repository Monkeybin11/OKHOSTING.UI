using System;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// Represents a control that is used for user input
	/// </summary>
	/// <typeparam name="T">Type of data that this control will allow the user to input</typeparam>
	public interface IInputControl<T> : IControl
	{
		/// <summary>
		/// The actual value that is being shown to the user, and/or that the user has set or modified
		/// </summary>
		T Value { get; set; }

		/// <summary>
		/// Raises after the value has changed by the user. Chages made in code will not raise this event.
		/// </summary>
		event EventHandler<T> ValueChanged;
	}
}