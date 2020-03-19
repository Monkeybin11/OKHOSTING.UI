using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class MenuItem : global::Xamarin.Forms.MenuItem, IMenuItem
	{
		public ICollection<IMenuItem> Children
		{
			get;
			set;
		}

		public event EventHandler Click;
	}
}