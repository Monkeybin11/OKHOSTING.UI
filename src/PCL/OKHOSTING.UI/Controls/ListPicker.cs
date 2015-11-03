using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Controls
{
	public class ListPicker<T>: IView
	{
		public IEnumerable<T> DataSource { get; set; }
    }
}