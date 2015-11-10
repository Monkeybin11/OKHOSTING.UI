using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class PasswordTextBox : System.Windows.Controls.StackPanel, IPasswordTextBox
	{
		public readonly System.Windows.Controls.PasswordBox NativeTextBox;

		public PasswordTextBox()
		{
			NativeTextBox = new System.Windows.Controls.PasswordBox();
			base.Children.Add(NativeTextBox);
		}

		public bool Multiline
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public IPage Page
		{
			get
			{
				return (Page) System.Windows.Window.GetWindow(this);
			}
		}

		public string Text
		{
			get
			{
				return NativeTextBox.Password;
			}

			set
			{
				NativeTextBox.Password = value;
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
					base.Visibility = System.Windows.Visibility.Hidden;
				}
			}
		}

		public void Dispose()
		{
		}
	}
}