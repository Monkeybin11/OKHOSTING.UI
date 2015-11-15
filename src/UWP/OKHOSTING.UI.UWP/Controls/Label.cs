using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.UWP.Controls
{
	public class Label : Windows.UI.Xaml.Controls.RelativePanel, ILabel
	{
		protected readonly Windows.UI.Xaml.Controls.TextBlock InnerLabel = new Windows.UI.Xaml.Controls.TextBlock();

		public Label()
		{
			base.Children.Add(InnerLabel);
		}

		public string Text
		{
			get
			{
				return InnerLabel.Text;
			}
			set
			{
				InnerLabel.Text = value;
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