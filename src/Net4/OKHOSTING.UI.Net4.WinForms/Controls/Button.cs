using System;
using System.Windows.Forms;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Button : System.Windows.Forms.Button, IButton
	{
		public Color BackgroundColor
		{
			get
			{
				return Page.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = Page.Parse(value);
			}
		}

		public Color FontColor
		{
			get
			{
				return Page.Parse(base.ForeColor);
			}
			set
			{
				base.ForeColor = Page.Parse(value);
			}
		}

		public string FontFamily
		{
			get
			{
				return base.Font.FontFamily.Name;
			}
			set
			{
				base.Font = new System.Drawing.Font(value, (float)FontSize);
			}
		}

		public double FontSize
		{
			get
			{
				return base.FontHeight;
			}
			set
			{
				base.FontHeight = (int)value;
			}
		}

		double IControl.Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				base.Width = (int)value;
			}
		}

		double IControl.Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = (int)value;
			}
		}

		public Color BorderColor { get; set; }

		public double BorderWidth { get; set; }

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
		{
			//draw custom border here
			pevent.Graphics.DrawRectangle(new System.Drawing.Pen(Page.Parse(BorderColor), (int)BorderWidth), base.Bounds);

			base.OnPaint(pevent);
		}

		protected override void OnResize(EventArgs e)
		{
			Invalidate();
			base.OnResize(e);
		}
	}
}