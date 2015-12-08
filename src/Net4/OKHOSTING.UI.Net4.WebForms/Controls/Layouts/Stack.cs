using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Net4.WebForms.Controls.Layouts
{
	public class Stack : System.Web.UI.WebControls.Panel, IStack
	{
		public Stack()
		{
			Children = new ControlList(this);
			InnerGrid = new Grid();
			((IGrid) InnerGrid).ColumnCount = 1;

			base.Controls.Add(InnerGrid);
        }

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

		/// <summary>
		/// The actual grid that contains all controls in a "stacky" way
		/// </summary>
		protected readonly Grid InnerGrid;

		public readonly ControlList Children;

		IList<IControl> IStack.Children
		{
			get
			{
				return Children;
			}
		}

		public class ControlList : IList<IControl>
		{
			private readonly Stack ContainerStack;

			public ControlList(Stack containerStack)
			{
				ContainerStack = containerStack;
			}

			public IControl this[int index]
			{
				get
				{
					return (IControl) ContainerStack.InnerGrid.Rows[index].Cells[0].Controls[0];
				}
				set
				{
					ContainerStack.InnerGrid.Rows[index].Cells[0].Controls.Clear();
					ContainerStack.InnerGrid.Rows[index].Cells[0].Controls.Add((System.Web.UI.Control) value);
                }
			}

			public int Count
			{
				get
				{
					return ContainerStack.InnerGrid.Rows.Count;
				}
			}

			public bool IsReadOnly
			{
				get
				{
					return false;
				}
			}

			public void Add(IControl item)
			{
				int last = ContainerStack.InnerGrid.Rows.Count;
				((IGrid) ContainerStack.InnerGrid).RowCount = last + 1;
				((IGrid) ContainerStack.InnerGrid).SetContent(last, 0, item);
			}

			public void Clear()
			{
				ContainerStack.InnerGrid.Rows.Clear();
			}

			public bool Contains(IControl item)
			{
				foreach (System.Web.UI.WebControls.TableRow row in ContainerStack.InnerGrid.Rows)
				{
					if (row.Cells[0].Controls.Count > 0 && row.Cells[0].Controls[0] == item)
					{
						return true;
					}
				}

				return false;
			}

			public void CopyTo(IControl[] array, int arrayIndex)
			{
				for (int i = 0; i < ContainerStack.InnerGrid.Rows.Count; i++)
				{
					System.Web.UI.WebControls.TableRow row = ContainerStack.InnerGrid.Rows[i];

					if (row.Cells[0].Controls.Count > 0)
					{
						array[i] = (IControl) row.Cells[0].Controls[0];
					}
				}
			}

			public IEnumerator<IControl> GetEnumerator()
			{
				foreach (System.Web.UI.WebControls.TableRow row in ContainerStack.InnerGrid.Rows)
				{
					yield return (IControl) row.Controls[0];
				}
			}

			public int IndexOf(IControl item)
			{
				for (int i = 0; i < ContainerStack.InnerGrid.Rows.Count; i++)
				{
					System.Web.UI.WebControls.TableRow row = ContainerStack.InnerGrid.Rows[i];

					if (row.Cells[0].Controls.Count > 0 && row.Cells[0].Controls[0] == item)
					{
						return i;
					}
				}
				return -1;
			}

			public void Insert(int index, IControl item)
			{
				var row = new System.Web.UI.WebControls.TableRow();
				row.Controls.Add((System.Web.UI.Control) item);

				ContainerStack.InnerGrid.Rows.AddAt(index, row);
			}

			public bool Remove(IControl item)
			{
				foreach (System.Web.UI.WebControls.TableRow row in ContainerStack.InnerGrid.Rows)
				{
					if (row.Cells[0].Controls.Contains((System.Web.UI.Control) item))
					{
						row.Cells[0].Controls.Clear();
						return true;
                    }
				}

				return false;
			}

			public void RemoveAt(int index)
			{
				ContainerStack.InnerGrid.Rows.RemoveAt(index);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}
	}
}