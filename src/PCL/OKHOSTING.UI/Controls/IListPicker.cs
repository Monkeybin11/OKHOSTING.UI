using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Controls
{
	public interface IListPicker: ITextControl
	{
		IEnumerable<string> DataSource { get; set; }
		string SelectedItem { get; set; }
		int SelectedIndex { get; set; }

		/// <summary>
		/// Raises after the value has changed by the user. Chages made in code will not raise this event.
		/// </summary>
		event EventHandler SelectedItemChanged;
	}
}