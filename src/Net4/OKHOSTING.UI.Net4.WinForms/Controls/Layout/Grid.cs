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
			Platform.Current.DrawBorders(this, pevent);
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
			var currentControl = ((IGrid) this).GetContent(row, column);

			if (currentControl != null)
			{
				base.Controls.Remove((System.Windows.Forms.Control) currentControl);
			}

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

		int IGrid.ColumnCount
		{
			get
			{
				return base.ColumnCount;
			}
			set
			{
				base.ColumnCount = value;
			}
		}

		int IGrid.RowCount
		{
			get
			{
				return base.RowCount;
			}
			set
			{
				base.RowCount = value;
			}
		}

		Thickness IGrid.CellMargin
		{
			get;
			set;
		}

		Thickness IGrid.CellPadding
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
	}
}