using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class TextBox : System.Web.UI.WebControls.TextBox, UI.Controls.ITextBox
	{
		public TextBoxMode Mode
		{
			get
			{
				switch (base.TextMode)
				{
					case System.Web.UI.WebControls.TextBoxMode.MultiLine:
						return TextBoxMode.MultiLine;

					case System.Web.UI.WebControls.TextBoxMode.Password:
						return TextBoxMode.Password;

					default:
						return TextBoxMode.SingleLine;
				}
			}
			set
			{
				switch (value)
				{
					case TextBoxMode.MultiLine:
						base.TextMode = System.Web.UI.WebControls.TextBoxMode.MultiLine;
						break;

					case TextBoxMode.Password:
						base.TextMode = System.Web.UI.WebControls.TextBoxMode.Password;
						break;

					default:
						base.TextMode = System.Web.UI.WebControls.TextBoxMode.SingleLine;
						break;
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