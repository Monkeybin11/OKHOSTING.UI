using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	public interface IListPicker: ITextControl, IInputControl<string>
	{
		IList<string> Items { get; set; }
		int SelectedIndex { get; set; }
	}
}