using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.UWP.Controls
{
	public class TextBox : Windows.UI.Xaml.Controls.TextBox, UI.Controls.ITextBox
	{
		public bool Multiline
		{
			get
			{
				return base.TextWrapping == Windows.UI.Xaml.TextWrapping.Wrap;
			}
			set
			{
				if (value)
				{
					base.TextWrapping = Windows.UI.Xaml.TextWrapping.Wrap;
					base.AcceptsReturn = true;
				}
				else
				{
					base.TextWrapping = Windows.UI.Xaml.TextWrapping.NoWrap;
					base.AcceptsReturn = false;
				}
			}
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
	}
}