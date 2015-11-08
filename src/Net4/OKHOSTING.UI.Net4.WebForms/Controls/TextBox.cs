using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class TextBox : System.Web.UI.WebControls.TextBox, UI.Controls.ITextBox
	{
		public bool Multiline
		{
			get
			{
				return base.TextMode == System.Web.UI.WebControls.TextBoxMode.MultiLine;
			}
			set
			{
				if (value)
				{
					base.TextMode = System.Web.UI.WebControls.TextBoxMode.MultiLine;
				}
				else
				{
					base.TextMode = System.Web.UI.WebControls.TextBoxMode.SingleLine;
				}
			}
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