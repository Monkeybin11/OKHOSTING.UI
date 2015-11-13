using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.UWP.Controls.Layouts
{
	public class Stack : Windows.UI.Xaml.Controls.StackPanel, IStack
	{
		public Stack()
		{
			_Children = new ControlList(base.Children);
		}

		public IPage Page
        {
            get
            {
				throw new NotImplementedException();
            }
        }

		public bool Visible
		{
			get
			{
				return base.Visibility == Windows.UI.Xaml.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = Windows.UI.Xaml.Visibility.Visible;
				}
				else
				{
					base.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
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