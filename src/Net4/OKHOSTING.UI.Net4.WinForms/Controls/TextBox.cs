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
		public TextBoxMode Mode
		{
			get
			{
				if (UseSystemPasswordChar)
				{
					return TextBoxMode.Password;
				}

				if (Multiline)
				{
					return TextBoxMode.MultiLine;
				}

				return TextBoxMode.SingleLine;
			}

			set
			{
				switch (value)
				{
					case TextBoxMode.MultiLine:
						Multiline = true;
						UseSystemPasswordChar = false;
						break;

					case TextBoxMode.Password:
						Multiline = false;
						UseSystemPasswordChar = true;
						break;

					case TextBoxMode.SingleLine:
						Multiline = false;
						UseSystemPasswordChar = false;
						break;
				}
			}
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
