using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class ListPicker : System.Windows.Forms.ComboBox, IListPicker
	{
		IEnumerable<string> IListPicker.DataSource
		{
			get
			{
				return (IEnumerable<string>) base.DataSource;
			}
			set
			{
				base.DataSource = value;
			}
		}

		string IListPicker.SelectedItem
		{
			get
			{
				return (string) base.SelectedValue;
			}
			set
			{
				base.SelectedValue = value;
			}
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
					base.Width = (int)value;
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
					base.Height = (int)value;
				}
			}
		}

		Thickness IControl.Margin
		{
			get
			{
				return Platform.Current.Parse(base.Margin);
			}
			set
			{
				base.Margin = Platform.Current.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return Platform.Current.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = Platform.Current.Parse(value);
			}
		}

		Color IControl.BorderColor { get; set; }

		Thickness IControl.BorderWidth { get; set; }

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Platform.Current.Parse(base.Anchor).Item1;
			}
			set
			{
				base.Anchor = Platform.Current.ParseAnchor(value, ((IControl)this).VerticalAlignment);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Platform.Current.Parse(base.Anchor).Item2;
			}
			set
			{
				base.Anchor = Platform.Current.ParseAnchor(((IControl)this).HorizontalAlignment, value);
			}
		}

		#endregion

		#region ITextControl

		Color ITextControl.FontColor
		{
			get
			{
				return Platform.Current.Parse(base.ForeColor);
			}
			set
			{
				base.ForeColor = Platform.Current.Parse(value);
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
				base.Font = new System.Drawing.Font(Font.Name, base.Font.Size, value ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
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
				base.Font = new System.Drawing.Font(Font.Name, base.Font.Size, value ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular);
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
				base.Font = new System.Drawing.Font(Font.Name, base.Font.Size, value ? System.Drawing.FontStyle.Underline : System.Drawing.FontStyle.Regular);
			}
		}

		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{
			get
			{
				return HorizontalAlignment.Left;
			}
			set
			{
				//do nothing since dis control doe snot dupport text elignment
			}
		}

		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get
			{
				return VerticalAlignment.Top;
			}
			set
			{
				//do nothing since dis control doe snot dupport text elignment
			}
		}

		Thickness ITextControl.TextPadding
		{
			get
			{
				return Platform.Current.Parse(base.Padding);
			}
			set
			{
				base.Padding = Platform.Current.Parse(value);
			}
		}

		#endregion

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
		{
			var control = (IControl)this;

			//calculate the 4 points or coordinates of the border
			System.Drawing.Point p1 = base.Bounds.Location; //top left

			System.Drawing.Point p2 = base.Bounds.Location;
			p2.Offset(base.Width, 0); //top right

			System.Drawing.Point p3 = base.Bounds.Location; //bottom left
			p2.Offset(0, base.Height * -1); //top right

			System.Drawing.Point p4 = base.Bounds.Location; //bottom right
			p2.Offset(base.Width, base.Height * -1); //top right

			//draw custom border here

			pevent.Graphics.DrawLine(new System.Drawing.Pen(Platform.Current.Parse(((IButton)this).BorderColor), (float)((IButton)this).BorderWidth.Left), p4, p1); //left
			pevent.Graphics.DrawLine(new System.Drawing.Pen(Platform.Current.Parse(((IButton)this).BorderColor), (float)((IButton)this).BorderWidth.Left), p1, p2); //top
			pevent.Graphics.DrawLine(new System.Drawing.Pen(Platform.Current.Parse(((IButton)this).BorderColor), (float)((IButton)this).BorderWidth.Left), p2, p3); //right
			pevent.Graphics.DrawLine(new System.Drawing.Pen(Platform.Current.Parse(((IButton)this).BorderColor), (float)((IButton)this).BorderWidth.Left), p3, p4); //bottom

			base.OnPaint(pevent);
		}
	}
}