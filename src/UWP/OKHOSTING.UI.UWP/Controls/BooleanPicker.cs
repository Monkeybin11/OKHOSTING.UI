using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.UWP.Controls
{
	public class BooleanPicker : Windows.UI.Xaml.Controls.CheckBox, IBooleanPicker
	{
		public bool SelectedValue
		{
			get
			{
				return base.IsChecked.Value;
			}
			set
			{
				base.IsChecked = value;
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
	}
}