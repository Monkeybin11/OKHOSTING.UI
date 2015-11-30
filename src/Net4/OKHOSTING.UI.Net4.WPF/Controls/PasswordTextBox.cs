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

		public Color BackgroundColor
		{
			get
			{
				return Page.Parse(((System.Windows.Media.SolidColorBrush)base.Background).Color);
			}
			set
			{
				base.Background = new System.Windows.Media.SolidColorBrush(Page.Parse(value));
			}
		}

		public Color BorderColor
		{
			get
			{
				return Page.Parse(((System.Windows.Media.SolidColorBrush) NativeTextBox.BorderBrush).Color);
			}
			set
			{
				NativeTextBox.BorderBrush = new System.Windows.Media.SolidColorBrush(Page.Parse(value));
			}
		}

		public double BorderWidth
		{
			get
			{
				return NativeTextBox.BorderThickness.Bottom;
			}
			set
			{
				NativeTextBox.BorderThickness = new System.Windows.Thickness(value);
			}
		}

		public bool Enabled
		{
			get
			{
				return base.IsEnabled;
			}
			set
			{
				base.IsEnabled = value;
			}
		}

		public Color FontColor
		{
			get
			{
				return Page.Parse(((System.Windows.Media.SolidColorBrush) NativeTextBox.Foreground).Color);
			}
			set
			{
				NativeTextBox.Foreground = new System.Windows.Media.SolidColorBrush(Page.Parse(value));
			}
		}

		string ITextControl.FontFamily
		{
			get
			{
				return NativeTextBox.FontFamily.Source;
			}
			set
			{
				NativeTextBox.FontFamily = new System.Windows.Media.FontFamily(value);
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

		public double FontSize
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

		public void Dispose()
		{
		}
	}
}