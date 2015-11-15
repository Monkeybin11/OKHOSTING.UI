using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Net4.WinForms.Controls.Layouts
{
	public class Stack : System.Windows.Forms.FlowLayoutPanel, IStack
	{
		public Stack()
		{

			AutoScroll = true;
			FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			WrapContents = false;

			_Children = new ControlList(base.Controls);
		}


		protected readonly ControlList _Children;

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