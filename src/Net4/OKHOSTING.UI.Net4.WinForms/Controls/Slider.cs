using System;
using System.Drawing;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Slider: System.Windows.Forms.TrackBar, ISlider
	{
		public Slider()
		{
			base.ValueChanged += Slider_ValueChanged;
		}

		private void Slider_ValueChanged(object sender, EventArgs e)
		{
			ValueChanged?.Invoke(sender, Value);
		}

		#region IControl

		double? IControl.Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				if (value.HasValue)
				{
					base.Width = (int) value;
				}
			}
		}

		double? IControl.Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				if (value.HasValue)
				{
					base.Height = (int) value;
				}
			}
		}

		Thickness IControl.Margin
		{
			get
			{
				return Platform.Parse(base.Margin);
			}
			set
			{
				base.Margin = Platform.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		Color IControl.BorderColor { get; set; }

		Thickness IControl.BorderWidth { get; set; }

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Platform.Parse(base.Anchor).Item1;
			}
			set
			{
				base.Anchor = Platform.ParseAnchor(value, ((IControl) this).VerticalAlignment);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Platform.Parse(base.Anchor).Item2;
			}
			set
			{
				base.Anchor = Platform.ParseAnchor(((IControl) this).HorizontalAlignment, value);
			}
		}
		
		#endregion

		public new double Minimum
		{
			get
			{
				return base.Minimum;
			}
			set
			{
				base.Minimum = (int) value;
			}
		}

		public new double Maximum
		{
			get
			{
				return base.Maximum;
			}
			set
			{
				base.Maximum = (int) value;
			}
		}

		public new double Value
		{
			get
			{
				return base.Value;
			}
			set
			{
				base.Value = (int) value;
			}
		}

		public new event EventHandler<double> ValueChanged;
	}
}