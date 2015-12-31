using System;

namespace OKHOSTING.UI.Controls
{
	public interface IPasswordTextBox: IControl
	{
		/// <summary>
		/// Gets or sets the text that is contained in the textbox
		/// </summary>
		string Text { get; set; }

		/// <summary>
		/// Raises after the value has changed by the user. Chages made in code will not raise this event.
		/// </summary>
		event EventHandler ValueChanged;
	}
}