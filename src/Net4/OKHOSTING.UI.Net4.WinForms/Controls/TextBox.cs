using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class TextBox : System.Windows.Forms.TextBox, UI.Controls.ITextBox
	{
		public IPage Page
		{
			get
			{
				return (Page) base.FindForm();
			}
		}
	}
}
