using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class ListPicker : System.Windows.Forms.ListBox, UI.Controls.IListPicker
	{
		public IPage Page
		{
			get
			{
				return (Page)base.FindForm();
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