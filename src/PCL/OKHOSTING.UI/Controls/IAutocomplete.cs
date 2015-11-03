using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Controls
{
	public class SearchableListPicker<T>: ListPicker<T>
	{
		public IEnumerable<T> Search(string pattern)
		{
			throw NotImplementedException();
		}
	}
}