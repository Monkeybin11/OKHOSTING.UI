using System;
using System.Windows.Forms;
using OKHOSTING.UI.Controls;
using System.Drawing;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Button : System.Windows.Forms.Button, IButton
	{
		#region ITextControl

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
				return Page.Parse(base.Margin);
			}
			set
			{
				base.Margin = Page.Parse(value);
			}
		}

		Color IControl.BackgroundColor
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

		Color IControl.BorderColor { get; set; }

		Thickness IControl.BorderWidth { get; set; }

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get; set;
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get; set;
		}

		#endregion

		#region ITextControl

		Color ITextControl.FontColor
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

		string ITextControl.FontFamily
		{
			get
			{
				return base.Font.FontFamily.Name;
			}
			set
			{
				base.Font = new System.Drawing.Font(value, (float) base.FontHeight);
			}
		}

		double ITextControl.FontSize
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

		bool ITextControl.Bold
		{
			get
			{
				return base.Font.Bold;
			}
			set
			{
				base.Font = new System.Drawing.Font(Font.Name, base.Font.Size, value? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
			}
		}

		bool ITextControl.Italic
		{
			get
			{
				return base.Font.Italic;
			}
			set
			{
				base.Font = new System.Drawing.Font(Font.Name, base.Font.Size, value? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular);
			}
		}

		bool ITextControl.Underline
		{
			get
			{
				return base.Font.Underline;
			}

			set
			{
				base.Font = new System.Drawing.Font(Font.Name, base.Font.Size, value? System.Drawing.FontStyle.Underline : System.Drawing.FontStyle.Regular);
			}
		}

		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{
			get
			{
				return WinForms.Page.GetHorizontalAlignment(base.TextAlign);
			}
			set
			{
				base.TextAlign = Page.GetContentAlignment(value, ((ITextControl) this).VerticalAlignment);
			}
		}

		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get
			{
				return WinForms.Page.GetVerticalAlignment(base.TextAlign);
			}
			set
			{
				base.TextAlign = Page.GetContentAlignment(((ITextControl) this).HorizontalAlignment, value);
			}
		}

		#endregion

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
		{
			var control = (IControl) this;

			//calculate position and size, based on margin and alignment
			switch (control.HorizontalAlignment)
			{
				case HorizontalAlignment.Left:
					base.Location = new Point((int) (base.Location.X + control.Margin.Left.Value), (int) (base.Location.Y + control.Margin.Top));
					break;

				case HorizontalAlignment.Center:
					base.Location = new Point(this.ClientSize.Width / 2 - base.Width / 2, base.Location.Y);
					break;

				case HorizontalAlignment.Right:
					base.Location = new Point(this.ClientSize.Width / 2 - base.Width / 2, base.Location.Y);
					break;

				case HorizontalAlignment.Fill:
					break;
			}

			//calculate the 4 points or coordinates of the border
			System.Drawing.Point p1 = base.Bounds.Location; //top left

			System.Drawing.Point p2 = base.Bounds.Location;
			p2.Offset(base.Width, 0); //top right

			System.Drawing.Point p3 = base.Bounds.Location; //bottom left
			p2.Offset(0, base.Height * - 1); //top right

			System.Drawing.Point p4 = base.Bounds.Location; //bottom right
			p2.Offset(base.Width, base.Height * -1); //top right

			//draw custom border here

			pevent.Graphics.DrawLine(new System.Drawing.Pen(Page.Parse(((IButton) this).BorderColor), (float) ((IButton) this).BorderWidth.Left), p4, p1); //left
			pevent.Graphics.DrawLine(new System.Drawing.Pen(Page.Parse(((IButton) this).BorderColor), (float) ((IButton) this).BorderWidth.Left), p1, p2); //top
			pevent.Graphics.DrawLine(new System.Drawing.Pen(Page.Parse(((IButton) this).BorderColor), (float) ((IButton) this).BorderWidth.Left), p2, p3); //right
			pevent.Graphics.DrawLine(new System.Drawing.Pen(Page.Parse(((IButton) this).BorderColor), (float) ((IButton) this).BorderWidth.Left), p3, p4); //bottom

			base.OnPaint(pevent);
		}
	}
}