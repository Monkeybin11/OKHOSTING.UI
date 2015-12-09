using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.UWP.Controls
{
	public class Button : Windows.UI.Xaml.Controls.Button, IButton
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
			base.Background = new Windows.UI.Xaml.Media.ImageBrush().ImageSource = new Windows.UI.Xaml.Media.ImageSource()
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
