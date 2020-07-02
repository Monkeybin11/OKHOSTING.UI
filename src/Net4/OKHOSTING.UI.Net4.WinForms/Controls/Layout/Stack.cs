using System;
using System.Collections.Generic;
using System.Drawing;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Net4.WinForms.Controls.Layout
{
	public class Stack : StackBase, IStack
	{
		public Stack()
		{
			FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
		}
	}
}