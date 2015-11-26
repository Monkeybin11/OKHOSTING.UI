using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class Button : System.Web.UI.WebControls.Button, IButton
	{
		public Color BackgroundColor
		{
			get
			{
				return new Color(base.BackColor.A, base.BackColor.R, base.BackColor.G, base.BackColor.B);
			}
			set
			{
				base.BackColor = System.Drawing.Color.FromArgb(value.Alpha, value.Red, value.Green, value.Blue);
			}
		}

		public Color ForegroundColor
		{
			get
			{
				return new Color(base.ForeColor.A, base.ForeColor.R, base.ForeColor.G, base.ForeColor.B);
			}
			set
			{
				base.ForeColor = System.Drawing.Color.FromArgb(value.Alpha, value.Red, value.Green, value.Blue);
			}
		}

		public string Name
		{
			get
			{
				return base.ID;
			}
			set
			{
				base.ID = value;
			}
		}

		Measure IControl.Height
		{
			get
			{
				if (base.Height.Type == System.Web.UI.WebControls.UnitType.Percentage)
				{
					return new Measure((decimal)base.Height.Value, MeasureUnit.Percentage);
				}
				else
				{
					return new Measure((decimal)base.Height.Value, MeasureUnit.Pixels);
				}
			}
			set
			{
				if (value.Unit == MeasureUnit.Percentage)
				{
					base.Height = new System.Web.UI.WebControls.Unit((double) value.Value, System.Web.UI.WebControls.UnitType.Percentage);
				}
				else
				{
					base.Height = new System.Web.UI.WebControls.Unit((double) value.Value, System.Web.UI.WebControls.UnitType.Pixel);
				}
			}
		}

		Measure IControl.Width
		{
			get
			{
				if (base.Width.Type == System.Web.UI.WebControls.UnitType.Percentage)
				{
					return new Measure((decimal) base.Width.Value, MeasureUnit.Percentage);
				}
				else
				{
					return new Measure((decimal) base.Width.Value, MeasureUnit.Pixels);
				}
			}
			set
			{
				if (value.Unit == MeasureUnit.Percentage)
				{
					base.Width = new System.Web.UI.WebControls.Unit((double) value.Value, System.Web.UI.WebControls.UnitType.Percentage);
				}
				else
				{
					base.Width = new System.Web.UI.WebControls.Unit((double) value.Value, System.Web.UI.WebControls.UnitType.Pixel);
				}
			}
		}
	}
}