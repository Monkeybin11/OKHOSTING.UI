using System;
using System.Collections.Generic;

namespace OKHOSTING.UI
{
	public abstract class View
	{
		IEnumerable<View> SubViews;

		public abstract void NavigateTo(View view);
	}
}