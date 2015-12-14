using System;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A single line textbox
	/// </summary>
	public interface ITextBox: ITextControl
	{ 
		/// <summary>
		/// Gets or sets the text that is contained in the textbox
		/// </summary>
		string Text { get; set; }

		/// <summary>
		/// The type of input that will be allowed for this TextBox
		/// </summary>
		ITextBoxInputType InputType { get; set; }
	}
}