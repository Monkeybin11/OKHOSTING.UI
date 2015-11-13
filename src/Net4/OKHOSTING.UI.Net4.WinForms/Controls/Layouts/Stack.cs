using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Net4.WinForms.Controls.Layouts
{
	public class Stack : System.Windows.Forms.Panel, IStack
	{
		protected readonly Grid InnerGrid = new Grid();

		public Stack()
		{
			InnerGrid.ColumnCount = 1;
			base.Controls.Add(InnerGrid);

			_Children.Adding += _Children_Adding;
			_Children.Removing += _Children_Removing;
		}

		private void _Children_Removing(object sender, IControl e)
		{
			int index = _Children.IndexOf(e);
			InnerGrid.setc
		}

		private void _Children_Adding(object sender, IControl e)
		{
			throw new NotImplementedException();
		}

		protected readonly ControlList _Children = new ControlList(new List<System.Windows.Forms.Control>());

        public IList<IControl> Children
		{
			get
			{
				return _Children;
			}
		}

		public IPage Page
		{
			get
			{
				return (Page) base.FindForm();
			}
		}
	}
}