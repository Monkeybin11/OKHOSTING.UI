using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class Stack : System.Windows.Controls.StackPanel, IStack
	{
		public Stack()
		{
			_Children = new ControlList(base.Children);
		}

		public bool Visible
		{
			get
			{
				return base.Visibility == System.Windows.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = System.Windows.Visibility.Visible;
				}
				else
				{
					base.Visibility = System.Windows.Visibility.Hidden;
				}
			}
		}

		public void Dispose()
		{
		}

		protected readonly ControlList _Children;

		IList<IControl> IStack.Children
		{
			get
			{
				return _Children;
			}
		}
	}
}