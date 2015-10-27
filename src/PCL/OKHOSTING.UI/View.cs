using System;
using System.Collections.Generic;

namespace OKHOSTING.UI
{
	public abstract class View
	{
		public IEnumerable<View> SubViews;
		public bool Visible;

		public abstract void NavigateTo(View view);
	}
}