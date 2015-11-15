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
	}
}