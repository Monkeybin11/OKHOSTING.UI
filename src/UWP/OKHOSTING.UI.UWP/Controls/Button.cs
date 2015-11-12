using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.UWP.Controls
{
	public class Button : Windows.UI.Xaml.Controls.Button, UI.Controls.IButton
	{
		public Button()
		{
			base.Click += Button_Click;
		}

		private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			if (Click != null)
			{
				Click(sender, new EventArgs());
			}
		}

		public void Dispose()
		{
		}

		public IPage Page
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public string Text
		{
			get
			{
				return (string) base.Content;
			}

			set
			{
				base.Content = value;
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

		public new event EventHandler Click;
	}
}
