using System;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A multiline textbox
	/// </summary>
	public interface ITextArea : ITextControl
	{ 
		string Text { get; set; }

		event EventHandler ValueChanged;
	}
}