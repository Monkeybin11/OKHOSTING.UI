using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class TextArea : System.Windows.Controls.TextBox, ITextArea
	{
		public TextArea()
		{
			base.TextWrapping = System.Windows.TextWrapping.Wrap;
			base.AcceptsReturn = true;
		}

		public IPage Page
		{
			get
			{
				return (Page) System.Windows.Window.GetWindow(this);
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