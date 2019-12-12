using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	public interface IMenu: ITextControl
	{
		ICollection<MenuItem> Items { get; set; }
	}

	public class MenuItem
	{
		public string Text { get; set; }

		public IImage Image { get; set; }

		public ICollection<MenuItem> Children { get; set; }

		public Action<object, EventArgs> Click;
	}
}