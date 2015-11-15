using System;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A single line textbox
	/// </summary>
	public interface ITextBox: IControl
	{ 
		/// <summary>
		/// Gets or sets the text that is contained in the textbox
		/// </summary>
		string Text { get; set; }
	}
}