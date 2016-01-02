using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Controls
{
	public interface IListPicker: ITextControl, IInputControl<string>
	{
		IEnumerable<string> DataSource { get; set; }
		int SelectedIndex { get; set; }
	}
}