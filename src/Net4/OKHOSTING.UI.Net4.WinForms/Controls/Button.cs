using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Button : System.Windows.Forms.Button, UI.Controls.IButton
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