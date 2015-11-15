using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class BooleanPicker : System.Web.UI.WebControls.CheckBox, IBooleanPicker
	{
		public string Name
		{
			get
			{
				return base.ID;
			}

			set
			{
				base.ID = value;
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
				base.Checked = value;
			}
		}

		IPage IControl.Page
		{
			get
			{
				return (Page)Page;
			}
		}

	}
}