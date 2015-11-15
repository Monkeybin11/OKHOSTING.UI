using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.UWP.Controls
{
	public class TextArea : Windows.UI.Xaml.Controls.TextBox, ITextArea
	{
		public TextArea()
		{
			base.TextWrapping = Windows.UI.Xaml.TextWrapping.Wrap;
			base.AcceptsReturn = true;
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
	}
}