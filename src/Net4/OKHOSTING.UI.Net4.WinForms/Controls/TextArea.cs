using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class TextArea : System.Windows.Forms.TextBox, ITextArea
	{
		public TextArea()
		{
			base.Multiline = true;
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
