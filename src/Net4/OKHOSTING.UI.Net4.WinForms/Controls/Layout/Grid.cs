using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Net4.WinForms.Controls.Layout
{
	public class Grid : System.Windows.Forms.TableLayoutPanel, OKHOSTING.UI.Controls.Layouts.IGrid
	{
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

			pevent.Graphics.DrawLine(new System.Drawing.Pen(App.Current.Parse(((IButton)this).BorderColor), (float)((IButton)this).BorderWidth.Left), p4, p1); //left
			pevent.Graphics.DrawLine(new System.Drawing.Pen(App.Current.Parse(((IButton)this).BorderColor), (float)((IButton)this).BorderWidth.Left), p1, p2); //top
			pevent.Graphics.DrawLine(new System.Drawing.Pen(App.Current.Parse(((IButton)this).BorderColor), (float)((IButton)this).BorderWidth.Left), p2, p3); //right
			pevent.Graphics.DrawLine(new System.Drawing.Pen(App.Current.Parse(((IButton)this).BorderColor), (float)((IButton)this).BorderWidth.Left), p3, p4); //bottom

			base.OnPaint(pevent);
		}

		IControl IGrid.GetContent(int row, int column)
		{
			foreach (System.Windows.Forms.Control control in Controls)
			{
				if (base.GetColumn(control) == column && base.GetRow(control) == row)
				{
					return (IControl) control;
				}
			}

			return null;
		}

		void IGrid.SetContent(int row, int column, IControl content)
		{
			base.Controls.Add((System.Windows.Forms.Control) content, column, row);
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
				return App.Current.Parse(base.Margin);
			}
			set
			{
				base.Margin = App.Current.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return App.Current.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = App.Current.Parse(value);
			}
		}

		Color IControl.BorderColor { get; set; }

		Thickness IControl.BorderWidth { get; set; }

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return App.Current.Parse(base.Anchor).Item1;
			}
			set
			{
				base.Anchor = App.Current.ParseAnchor(value, ((IControl)this).VerticalAlignment);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return App.Current.Parse(base.Anchor).Item2;
			}
			set
			{
				base.Anchor = App.Current.ParseAnchor(((IControl)this).HorizontalAlignment, value);
			}
		}

		int IGrid.ColumnCount
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

		int IGrid.RowCount
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

		Thickness IGrid.CellMargin
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

		Thickness IGrid.CellPadding
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

		string IControl.Name
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

		bool IControl.Visible
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

		bool IControl.Enabled
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
	}
}