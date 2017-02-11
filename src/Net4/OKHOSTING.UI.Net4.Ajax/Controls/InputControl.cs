using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OKHOSTING.UI.Net4.Ajax.Controls
{
	public abstract class InputControl<T> : TextControl, UI.Controls.IInputControl<T>
	{
		public virtual T Value
		{
			get;
			set;
		}

		public event EventHandler<T> ValueChanged;
	}
}