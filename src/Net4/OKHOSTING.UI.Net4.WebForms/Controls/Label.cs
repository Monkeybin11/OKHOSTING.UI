using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class Label : System.Web.UI.WebControls.Label, ILabel
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

		public Measure BorderSize
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

		public Color FontColor
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

		public string FontFamily
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

		Color IControl.BorderColor
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

		double IControl.Height
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

		double IControl.Width
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
	}
}