using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Net4.WinForms.Controls.Layout
{
	public class Grid : System.Windows.Forms.TableLayoutPanel, IGrid
	{
		private IImage _BackgroundImage;
		
		public Grid()
		{
		}

		#region IGrid

		Thickness IGrid.CellMargin
		{
			get;
			set;
		}

		Thickness IGrid.CellPadding
		{
			get;
			set;
		}

		int IGrid.ColumnCount
		{
			get
			{
				return base.ColumnCount;
			}
			set
			{
				for (int column = base.ColumnCount; column < value; column++)
				{
					base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
				}

				//remove all controls from columns to be removed
				for (int column = base.ColumnCount - 1; column >= value; column--)
				{
					for (int row = 0; row < base.RowCount; row++)
					{
						var control = base.GetControlFromPosition(column, row);
						base.Controls.Remove(control);
					}

					base.ColumnStyles.RemoveAt(column);
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
				for (int row = base.RowCount; row < value; row++)
				{ 
					base.RowStyles.Add(new System.Windows.Forms.RowStyle());
				}

				//remove all controls from rows to be removed
				for (int row = base.RowCount - 1; row >= value; row--)
				{
					for (int column = 0; column < base.ColumnCount; column++)
					{
						var control = base.GetControlFromPosition(column, row);
						base.Controls.Remove(control);
					}

					base.RowStyles.RemoveAt(row);
				}

				base.RowCount = value;
			}
		}

		/// <summary>
		/// When set to true, shows all the cell borders inside the grid, when false, no cell border is shown
		/// </summary>
		bool IGrid.ShowGridLines
		{
			get
			{
				return CellBorderStyle == System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			}
			set
			{
				if (value)
				{
					CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
				}
				else
				{
					CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
				}
			}
		}

		IControl IGrid.GetContent(int row, int column)
		{
			return base.GetControlFromPosition(column, row) as IControl;
		}

		void IGrid.SetContent(int row, int column, IControl content)
		{
			if (row > RowCount)
			{
				throw new ArgumentOutOfRangeException(nameof(row));
			}

			if (column > ColumnCount)
			{
				throw new ArgumentOutOfRangeException(nameof(column));
			}

			var currentControl = ((IGrid) this).GetContent(row, column);

			if (currentControl != null)
			{
				base.Controls.Remove((System.Windows.Forms.Control) currentControl);
			}

			if (content != null)
			{
				base.Controls.Add((System.Windows.Forms.Control)content, column, row);
			}
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

		#endregion

		#region IContainer

		ICollection<IControl> IContainer.Children
		{
			get
			{
				return IGridExtensions.GetAllControlls(this).ToList();
			}
		}

		IImage IContainer.BackgroundImage
		{
			get
			{
				return _BackgroundImage;
			}
			set
			{
				_BackgroundImage = value;
				base.BackgroundImage = ((System.Windows.Forms.PictureBox) value)?.Image;
			}
		}

		#endregion

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
				base.BackColor = Platform.RemoveAlpha(value);
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

		/// <summary>
		/// Control that contains this control, like a grid, or stack
		/// </summary>
		IControl IControl.Parent
		{
			get
			{
				return (IControl) base.Parent;
			}
		}

		/// <summary>
		/// Gets or sets a list of classes that define a control's style. 
		/// Exactly the same concept as in CSS. 
		/// </summary>
		string IControl.CssClass { get; set; }

		#endregion
		
		object ICloneable.Clone()
		{
			return MemberwiseClone();
		}

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
		{
			Platform.DrawBorders(this, pevent);
			base.OnPaint(pevent);
			//base.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			//| System.Windows.Forms.AnchorStyles.Left)
			//| System.Windows.Forms.AnchorStyles.Right)));
		}
	}
}