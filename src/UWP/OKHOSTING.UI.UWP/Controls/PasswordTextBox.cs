using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.UWP.Controls
{
	public class PasswordTextBox : Windows.UI.Xaml.Controls.StackPanel, IPasswordTextBox
    {
        public readonly Windows.UI.Xaml.Controls.PasswordBox NativeTextBox;

        public PasswordTextBox()
        {
            NativeTextBox = new Windows.UI.Xaml.Controls.PasswordBox();
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
                throw new NotImplementedException();
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
				return base.Visibility == Windows.UI.Xaml.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = Windows.UI.Xaml.Visibility.Visible;
				}
				else
				{
					base.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
				}
			}
		}

        public void Dispose()
        {
        }
    }
}