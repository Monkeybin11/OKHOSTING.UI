using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Label : System.Windows.Forms.Label, UI.Controls.ILabel
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

		public Color BorderColor
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

		public Measure BorderSize
		{
			get
			{
				return new Measure(1, MeasureUnit.Pixels);
            }
			set
			{
				if (value == 0)
				{
					base.BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
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

		public Measure FontSize
		{
			get
			{
				return base.FontHeight;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		Measure IControl.Height
		{
			get
			{
				return base.Height;
			}

			set
			{
				throw new NotImplementedException();
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
	}
}
