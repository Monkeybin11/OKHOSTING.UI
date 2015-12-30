using System;

namespace OKHOSTING.UI.Controls
{
	public interface IPasswordTextBox: IControl
	{
		/// <summary>
		/// Gets or sets the text that is contained in the textbox
		/// </summary>
		string Text { get; set; }

		event EventHandler ValueChanged;
	}
}