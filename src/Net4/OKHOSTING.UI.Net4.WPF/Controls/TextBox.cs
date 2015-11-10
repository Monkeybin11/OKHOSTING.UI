using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class TextBox : System.Windows.Controls.TextBox, ITextBox
	{
		public bool Multiline
		{
			get
			{
				return base.TextWrapping == System.Windows.TextWrapping.Wrap;
			}
			set
			{
				if (value)
				{
					base.TextWrapping = System.Windows.TextWrapping.Wrap;
					base.AcceptsReturn = true;
				}
				else
				{
					base.TextWrapping = System.Windows.TextWrapping.NoWrap;
					base.AcceptsReturn = false;
				}
			}
		}

		public IPage Page
		{
			get
			{
				return (Page)System.Windows.Window.GetWindow(this);
			}
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
	}
}