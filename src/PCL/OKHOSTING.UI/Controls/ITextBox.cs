using System;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A single line textbox
	/// </summary>
	public interface ITextBox: ITextControl, IInputControl<string>
	{ 
		/// <summary>
		/// The type of input that will be allowed for this TextBox
		/// </summary>
		ITextBoxInputType InputType { get; set; }
	}
}