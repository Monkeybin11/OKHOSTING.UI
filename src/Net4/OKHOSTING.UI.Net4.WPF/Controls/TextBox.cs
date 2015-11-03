using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class TextBox : System.Windows.Controls.TextBox, UI.Controls.ITextBox
	{
		public TextBoxMode Mode
		{
			get
			{
				if (base.TextWrapping == System.Windows.TextWrapping.Wrap)
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
						base.TextWrapping = System.Windows.TextWrapping.Wrap;
						base.AcceptsReturn = true;
						break;

					case TextBoxMode.Password:
						base.TextWrapping = System.Windows.TextWrapping.NoWrap;
						base.AcceptsReturn = false;
						break;

					case TextBoxMode.SingleLine:
						base.TextWrapping = System.Windows.TextWrapping.NoWrap;
						base.AcceptsReturn = false;
						break;
				}
			}
		}

		public IPage Page
		{
			get
			{
				return (Page)System.Windows.Window.GetWindow(this);
			}
		}

		public bool Visible
		{
			get
			{
				return base.Visibility == System.Windows.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = System.Windows.Visibility.Visible;
				}
				else
				{
					base.Visibility = System.Windows.Visibility.Collapsed;
				}
			}
		}
	}
}