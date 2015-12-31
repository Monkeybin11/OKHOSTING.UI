using System;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A multiline textbox
	/// </summary>
	public interface ITextArea : ITextControl
	{ 
		string Text { get; set; }

		/// <summary>
		/// Raises after the value has changed by the user. Chages made in code will not raise this event.
		/// </summary>
		event EventHandler ValueChanged;
	}
}