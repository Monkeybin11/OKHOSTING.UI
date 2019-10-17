using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Net4.WinForms.Controls.Layout
{
	public class Grid : System.Windows.Forms.TableLayoutPanel, IGrid
	{
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
		{
			Platform.DrawBorders(this, pevent);
			base.OnPaint(pevent);

			//AutoScroll = true;
			AutoSize = true;
			//base.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			//| System.Windows.Forms.AnchorStyles.Left)
			//| System.Windows.Forms.AnchorStyles.Right)));
		}

		IControl IGrid.GetContent(int row, int column)
		{
			return base.GetControlFromPosition(column, row) as IControl;
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

		Thickness IGrid.CellMargin
		{
			get;
			set;
		}

		Thickness IGrid.CellPadding
		{
			get
			{
				return Platform.Parse(base.Padding);
			}
			set
			{
				base.Padding = Platform.Parse(value);
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
				//remove all controls from columns to be removed
				for (int column = base.ColumnCount - 1; column >= value; column--)
				{
					for (int row = 0; row < base.RowCount; row++)
					{
						var control = base.GetControlFromPosition(column, row);
						base.Controls.Remove(control);
					}

					//base.ColumnStyles.RemoveAt(column);
				}

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
				//remove all controls from rows to be removed
				for (int row = base.RowCount - 1; row >= value; row--)
				{
					for (int column = 0; column < base.ColumnCount; column++)
					{
						var control = base.GetControlFromPosition(column, row);
						base.Controls.Remove(control);
					}

					//base.RowStyles.RemoveAt(row);
				}

				base.RowCount = value;
			}
		}

		/// <summary>
		/// Removes a specific row and moves up all rows below
		/// </summary>
		/// <param name="rowIndex">Zero based index of he row to be deleted</param>
		public void RemoveRow(int rowIndex)
		{
			if (rowIndex >= base.RowCount)
			{
				return;
			}

			//delete all controls of row that we want to delete
			for (int column = 0; column < base.ColumnCount; column++)
			{
				var control = base.GetControlFromPosition(column, rowIndex);
				base.Controls.Remove(control);
			}

			//move up row controls that comes after row we want to remove
			for (int row = rowIndex + 1; row < base.RowCount; row++)
			{
				for (int column = 0; column < base.ColumnCount; column++)
				{
					var control = base.GetControlFromPosition(column, row);

					if (control != null)
					{
						base.SetRow(control, row - 1);
					}
				}
			}

			//remove last row
			//base.RowStyles.RemoveAt(base.RowCount - 1);
			base.RowCount--;
		}

		/// <summary>
		/// Removes a specific column and moves left all columns on right
		/// </summary>
		/// <param name="columnIndex">Zero based index of he column to be deleted</param>
		public void RemoveColumn(int columnIndex)
		{
			if (columnIndex >= base.ColumnCount)
			{
				return;
			}

			//delete all controls of column that we want to delete
			for (int row = 0; row < base.RowCount; row++)
			{
				var control = base.GetControlFromPosition(columnIndex, row);
				base.Controls.Remove(control);
			}

			//move left column controls that comes after the column we want to remove
			for (int column = columnIndex + 1; column < base.ColumnCount; column++)
			{
				for (int row = 0; row < base.RowCount; row++)
				{
					var control = base.GetControlFromPosition(column, row);

					if (control != null)
					{
						base.SetColumn(control, column - 1);
					}
				}
			}

			//remove last column
			//base.ColumnStyles.RemoveAt(base.ColumnCount - 1);
			base.ColumnCount--;
		}

		void IGrid.SetColumnSpan(int columnSpan, IControl content)
		{
			base.SetColumnSpan((System.Windows.Forms.Control) content, columnSpan);
		}

		int IGrid.GetColumnSpan(IControl content)
		{
			return base.GetColumnSpan((System.Windows.Forms.Control) content);
		}

		void IGrid.SetRowSpan(int rowSpan, IControl content)
		{
			base.SetRowSpan((System.Windows.Forms.Control) content, rowSpan);
		}

		int IGrid.GetRowSpan(IControl content)
		{
			return base.GetRowSpan((System.Windows.Forms.Control) content);
		}

		void IGrid.SetWidth(int column, double width)
		{
			base.ColumnStyles[column].Width = (float) width;
		}

		double IGrid.GetWidth(int column)
		{
			return base.ColumnStyles[column].Width;
		}

		void IGrid.SetHeight(int row, double height)
		{
			base.RowStyles[row].Height = (float) height;
		}

		double IGrid.GetHeight(int row)
		{
			return base.RowStyles[row].Height;
		}

		ICollection<IControl> IContainer.Children
		{
			get
			{
				return IGridExtensions.GetAllControlls(this).ToList();
			}
		}

		/// <summary>
		/// Gets or sets a list of classes that define a control's style. 
		/// Exactly the same concept as in CSS. 
		/// </summary>
		string IControl.CssClass { get; set; }

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
				return Platform.Parse(base.Margin);
			}
			set
			{
				base.Margin = Platform.Parse(value);
			}
		}

		Thickness IControl.Padding
		{
			get
			{
				return Platform.Parse(base.Padding);
			}
			set
			{
				base.Padding = Platform.Parse(value);
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
				base.Anchor = Platform.ParseAnchor(value, ((IControl)this).VerticalAlignment);
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
				base.Anchor = Platform.ParseAnchor(((IControl)this).HorizontalAlignment, value);
			}
		}

		#endregion
	}
}