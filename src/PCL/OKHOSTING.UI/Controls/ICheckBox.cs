using System;

namespace OKHOSTING.UI.Controls
{
	public interface ICheckBox: ITextControl
	{
		bool SelectedValue { get; set; }

		event EventHandler ValueChanged;
	}
}