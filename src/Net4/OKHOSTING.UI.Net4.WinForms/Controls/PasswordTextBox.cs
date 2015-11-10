using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class PasswordTextBox : System.Windows.Forms.TextBox, UI.Controls.IPasswordTextBox
	{
		public PasswordTextBox()
		{
			base.UseSystemPasswordChar = true;
		}

		public IPage Page
		{
			get
			{
				return (Page) base.FindForm();
			}
		}
	}
}