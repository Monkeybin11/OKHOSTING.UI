using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class ListPicker : System.Windows.Forms.ListBox, IListPicker
	{
		public IPage Page
		{
			get
			{
				return (Page) base.FindForm();
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
				return (string) base.SelectedValue;
			}
			set
			{
				base.SelectedValue = value;
			}
		}
	}
}