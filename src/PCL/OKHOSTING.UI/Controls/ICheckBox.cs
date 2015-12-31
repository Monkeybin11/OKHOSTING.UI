using System;

namespace OKHOSTING.UI.Controls
{
	public interface ICheckBox: ITextControl
	{
		bool SelectedValue { get; set; }

		/// <summary>
		/// Raises after the value has changed by the user. Chages made in code will not raise this event.
		/// </summary>
		event EventHandler ValueChanged;
	}
}