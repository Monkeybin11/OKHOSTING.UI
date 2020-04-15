using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class MenuItem : System.Windows.Forms.ToolStripMenuItem, IMenuItem
	{
		protected readonly MenuItemList _Children;

		public MenuItem(): base()
		{
			_Children = new MenuItemList(base.DropDownItems);
		}

		public MenuItem(string text) : base(text)
		{
			_Children = new MenuItemList(base.DropDownItems);
		}

		public MenuItem(string text, EventHandler onClick) : base(text, null, onClick)
		{
			_Children = new MenuItemList(base.DropDownItems);
		}

		public ICollection<IMenuItem> Children
		{
			get
			{
				return _Children;
			}
		}

		public override string ToString()
		{
			return Text ?? base.ToString();
		}
	}
}