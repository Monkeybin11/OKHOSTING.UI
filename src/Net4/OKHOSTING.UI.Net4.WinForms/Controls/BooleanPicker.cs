using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class BooleanPicker : System.Windows.Forms.CheckBox, IBooleanPicker
	{
		public IPage Page
		{
			get
			{
				return (Page)base.FindForm();
			}
		}

		public bool SelectedValue
		{
			get
			{
				return base.Checked;
			}
			set
			{
				base.Checked = true;
			}
		}
	}
}