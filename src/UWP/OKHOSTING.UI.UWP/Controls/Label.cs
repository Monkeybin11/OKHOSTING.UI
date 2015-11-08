using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.UWP.Controls
{
	public class Label : Windows.UI.Xaml.Controls.RelativePanel, UI.Controls.ILabel
	{
		protected readonly Windows.UI.Xaml.Controls.TextBlock InnerLabel = new Windows.UI.Xaml.Controls.TextBlock();

		public Label()
		{
			base.Children.Add(InnerLabel);
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
	}
}