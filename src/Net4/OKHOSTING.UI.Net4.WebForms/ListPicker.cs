using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms
{
	public class ListPicker : System.Web.UI.WebControls.DropDownList, UI.Controls.IListPicker
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

		IPage IControl.Page
		{
			get
			{
				return (Page)Page;
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
	}
}