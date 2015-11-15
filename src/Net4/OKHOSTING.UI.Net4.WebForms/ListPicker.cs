using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms
{
	public class ListPicker : System.Web.UI.WebControls.DropDownList, IListPicker
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

		IEnumerable<string> IListPicker.DataSource
		{
			get
			{
				return (IEnumerable<string>) base.DataSource;
			}
			set
			{
				base.DataSource = value;
			}
		}

		string IListPicker.SelectedItem
		{
			get
			{
				return base.SelectedItem.Value;
			}
			set
			{
				base.SelectedValue = value;
			}
		}
	}
}