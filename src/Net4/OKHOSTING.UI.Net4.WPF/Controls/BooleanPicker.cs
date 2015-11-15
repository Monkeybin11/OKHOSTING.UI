using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class BooleanPicker : System.Windows.Controls.CheckBox, IBooleanPicker
	{
		public IPage Page
		{
			get
			{
				return (Page)System.Windows.Window.GetWindow(this);
			}
		}

		public bool SelectedValue
		{
			get
			{
				if (!base.IsChecked.HasValue)
				{
					return false;
				}

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
