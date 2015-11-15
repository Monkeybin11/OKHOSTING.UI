using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Button : System.Windows.Forms.Button, IButton
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