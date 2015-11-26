using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class BooleanPicker : System.Windows.Controls.CheckBox, IBooleanPicker
	{
		public Color BackgroundColor
		{
			get
			{
				var color = ((System.Windows.Media.SolidColorBrush) base.Background).Color;
				return new Color(color.A, color.R, color.G, color.B);
			}
			set
			{
				base.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb((byte) value.Alpha, (byte) value.Red, (byte) value.Green, (byte) value.Blue));
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

		public Color ForegroundColor
		{
			get
			{
				var color = ((System.Windows.Media.SolidColorBrush) base.Foreground).Color;
				return new Color(color.A, color.R, color.G, color.B);
			}
			set
			{
				base.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb((byte)value.Alpha, (byte)value.Red, (byte)value.Green, (byte)value.Blue));
			}
		}

		public bool SelectedValue
		{
			get
			{
				if (!base.IsChecked.HasValue)
				{
					return false;
				}

				return base.IsChecked.Value;
			}
			set
			{
				base.IsChecked = value;
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

		Measure IControl.Height
		{
			get
			{
				return new Measure((decimal) base.Height, MeasureUnit.Pixels);
			}
			set
			{
				base.Height = value.Value;
			}
		}

		Measure IControl.Width
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
