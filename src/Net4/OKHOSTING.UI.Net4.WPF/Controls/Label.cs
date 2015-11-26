using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class Label : System.Windows.Controls.Label, ILabel
	{
		public Color BackgroundColor
		{
			get
			{
				var bgColor = ((System.Windows.Media.SolidColorBrush) base.Background).Color;
				return new Color(bgColor.A, bgColor.R, bgColor.G, bgColor.B);
			}
			set
			{
				base.Background = new System.Windows.Media.SolidColorBrush(new System.Windows.Media.Color() { A = (byte) value.Alpha, R = (byte) value.Red, G = (byte) value.Green, B = (byte) value.Blue });
			}
		}

		public Color BorderColor
		{
			get
			{
				var bgColor = ((System.Windows.Media.SolidColorBrush) base.BorderBrush).Color;
				return new Color(bgColor.A, bgColor.R, bgColor.G, bgColor.B);
			}
			set
			{
				base.BorderBrush = new System.Windows.Media.SolidColorBrush(new System.Windows.Media.Color() { A = (byte)value.Alpha, R = (byte)value.Red, G = (byte)value.Green, B = (byte)value.Blue });
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

		string IControl.FontFamily
		{
			get
			{
				return base.FontFamily.Source;
			}
			set
			{
				base.FontFamily = new System.Windows.Media.FontFamily(value);
			}
		}

		public void Dispose()
		{
		}
	}
}