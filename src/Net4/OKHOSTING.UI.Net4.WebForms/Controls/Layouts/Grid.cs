using System.Linq;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Net4.WebForms.Controls.Layouts
{
	public class Grid : System.Web.UI.WebControls.Table, UI.Controls.Layouts.IGrid
	{
		protected int _ColumnCount = 0;

		#region IControl

		string IControl.Name
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

		Color IControl.BackgroundColor
		{
			get
			{
				return WebForms.Page.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = WebForms.Page.Parse(value);
			}
		}

		Color IControl.BorderColor
		{
			get
			{
				return WebForms.Page.Parse(base.BorderColor);
			}
			set
			{
				base.BorderColor = WebForms.Page.Parse(value);
			}
		}

		double IControl.Width
		{
			get
			{
				return base.Width.Value;
			}
			set
			{
				base.Width = new System.Web.UI.WebControls.Unit(value, System.Web.UI.WebControls.UnitType.Pixel);
			}
		}

		double IControl.Height
		{
			get
			{
				return base.Height.Value;
			}
			set
			{
				base.Height = new System.Web.UI.WebControls.Unit(value, System.Web.UI.WebControls.UnitType.Pixel);
			}
		}

		Thickness IControl.Margin
		{
			get
			{
				Thickness value = new Thickness();

				try
				{
					value.Top = double.Parse(base.Style["margin-top"]);
					value.Right = double.Parse(base.Style["margin-right"]);
					value.Bottom = double.Parse(base.Style["margin-bottom"]);
					value.Left = double.Parse(base.Style["margin-left"]);
				}
				catch { }

				return value;
			}
			set
			{
				base.Style["margin-top"] = string.Format("{0}px", value.Top);
				base.Style["margin-right"] = string.Format("{0}px", value.Right);
				base.Style["margin-bottom"] = string.Format("{0}px", value.Bottom);
				base.Style["margin-left"] = string.Format("{0}px", value.Left);
			}
		}

		Thickness IControl.BorderWidth
		{
			get
			{
				Thickness value = new Thickness();

				try
				{
					value.Top = double.Parse(base.Style["border-top-width"]);
					value.Right = double.Parse(base.Style["border-right-width"]);
					value.Bottom = double.Parse(base.Style["border-bottom-width"]);
					value.Left = double.Parse(base.Style["border-left-width"]);
				}
				catch { }

				return value;
			}
			set
			{
				base.Style["border-top-width"] = string.Format("{0}px", value.Top);
				base.Style["border-right-width"] = string.Format("{0}px", value.Right);
				base.Style["border-bottom-width"] = string.Format("{0}px", value.Bottom);
				base.Style["border-left-width"] = string.Format("{0}px", value.Left);
			}
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				string cssClass = base.CssClass.Split().Where(c => c.StartsWith("horizontal-alignment")).SingleOrDefault();

				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return HorizontalAlignment.Left;
				}

				if (cssClass.EndsWith("left"))
				{
					return HorizontalAlignment.Left;
				}
				else if (cssClass.EndsWith("right"))
				{
					return HorizontalAlignment.Right;
				}
				else if (cssClass.EndsWith("center"))
				{
					return HorizontalAlignment.Center;
				}
				else if (cssClass.EndsWith("fill"))
				{
					return HorizontalAlignment.Fill;
				}
				else
				{
					return HorizontalAlignment.Left;
				}
			}
			set
			{
				WebForms.Page.RemoveCssClassesStartingWith(this, "horizontal-alignment");
				WebForms.Page.AddCssClass(this, "horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				string cssClass = base.CssClass.Split().Where(c => c.StartsWith("vertical-alignment")).SingleOrDefault();

				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return VerticalAlignment.Top;
				}

				if (cssClass.EndsWith("top"))
				{
					return VerticalAlignment.Top;
				}
				else if (cssClass.EndsWith("bottom"))
				{
					return VerticalAlignment.Bottom;
				}
				else if (cssClass.EndsWith("center"))
				{
					return VerticalAlignment.Center;
				}
				else if (cssClass.EndsWith("fill"))
				{
					return VerticalAlignment.Fill;
				}
				else
				{
					return VerticalAlignment.Top;
				}
			}
			set
			{
				WebForms.Page.RemoveCssClassesStartingWith(this, "vertical-alignment");
				WebForms.Page.AddCssClass(this, "vertical-alignment-" + value.ToString().ToLower());
			}
		}

		#endregion

		int IGrid.ColumnCount
		{
			get
			{
				return _ColumnCount;
			}
			set
			{
				_ColumnCount = value;

				foreach (System.Web.UI.WebControls.TableRow row in Rows)
				{
					while (row.Cells.Count < value)
					{
						row.Cells.Add(new System.Web.UI.WebControls.TableCell());
					}

					while (row.Cells.Count > value)
					{
						row.Cells.RemoveAt(row.Cells.Count - 1);
					}
				}
			}
		}

		int IGrid.RowCount
		{
			get
			{
				return Rows.Count;
			}
			set
			{
				while (Rows.Count < value)
				{
					Rows.Add(new System.Web.UI.WebControls.TableRow());
				}

				while (Rows.Count > value)
				{
					Rows.RemoveAt(Rows.Count - 1);
				}

				//re-set columns
				((IGrid) this).ColumnCount = _ColumnCount;
			}
		}

		Thickness IGrid.CellMargin
		{
			get
			{
				return new Thickness(base.CellSpacing);
			}
			set
			{
				base.CellSpacing = (int) value.Bottom;
			}
		}

		Thickness IGrid.CellPadding
		{
			get
			{
				return new Thickness(base.CellSpacing);
			}
			set
			{
				base.CellSpacing = (int) value.Bottom;
			}
		}

		IControl IGrid.GetContent(int row, int column)
		{
			if (Rows[row].Cells[column].Controls.Count == 0)
			{
				return null;
			}

			return (IControl)Rows[row].Cells[column].Controls[0];
		}

		void IGrid.SetContent(int row, int column, IControl content)

		{
			Rows[row].Cells[column].Controls.Clear();
			Rows[row].Cells[column].Controls.Add((System.Web.UI.Control)content);
		}
	}
}