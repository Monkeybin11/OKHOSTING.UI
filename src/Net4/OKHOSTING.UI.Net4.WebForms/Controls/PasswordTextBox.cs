using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class PasswordTextBox : System.Web.UI.WebControls.TextBox, UI.Controls.IPasswordTextBox
	{
		public PasswordTextBox()
		{
			base.TextMode = System.Web.UI.WebControls.TextBoxMode.Password;
		}

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
				return (Page) Page;
			}
		}
	}
}