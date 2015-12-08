using System;
using System.Windows.Forms;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Button : System.Windows.Forms.Button, IButton
	{
		#region ITextControl

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
				base.Height = (int) value;
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

		Thickness IControl.Margin
		{
			get
			{
				return new Thickness(base.Left, base.Top, base.Right, base.Bottom);
			}
			set
			{
				base.Left = (int)value.Left;
				base.Top = (int)value.Top;
				base.Right = (int)value.Right;
				base.Bottom = (int)value.Bottom;
			}
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				if (base.Left == 0) return HorizontalAlignment.Left;
				if (base.Top == 0) return HorizontalAlignment.t;
				if (base.Left == 0) return HorizontalAlignment.Left;
				if (base.Left == 0) return HorizontalAlignment.Left;
			}
			set
			{
				base.TextAlign = Page.GetContentAlignment(value, ((ITextControl)this).VerticalAlignment);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
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
				base.Font = new System.Drawing.Font(value, (float)base.FontHeight);
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

		event EventHandler IButton.Click
		{
			add
			{
				throw new NotImplementedException();
			}

			remove
			{
				throw new NotImplementedException();
			}
		}

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