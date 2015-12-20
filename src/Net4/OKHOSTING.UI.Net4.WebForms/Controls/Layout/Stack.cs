using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Net4.WebForms.Controls.Layout
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
				return Platform.Current.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = Platform.Current.Parse(value);
			}
		}

		Color IControl.BorderColor
		{
			get
			{
				return Platform.Current.Parse(base.BorderColor);
			}
			set
			{
				base.BorderColor = Platform.Current.Parse(value);
			}
		}

		double? IControl.Width
		{
			get
			{
				if (base.Width.IsEmpty)
				{
					return null;
				}

				return base.Width.Value;
			}
			set
			{
				if (value.HasValue)
				{
					base.Width = new System.Web.UI.WebControls.Unit(value.Value, System.Web.UI.WebControls.UnitType.Pixel);
				}
				else
				{
					base.Width = new System.Web.UI.WebControls.Unit();
				}
			}
		}

		double? IControl.Height
		{
			get
			{
				if (base.Height.IsEmpty)
				{
					return null;
				}

				return base.Height.Value;
			}
			set
			{
				if (value.HasValue)
				{
					base.Height = new System.Web.UI.WebControls.Unit(value.Value, System.Web.UI.WebControls.UnitType.Pixel);
				}
				else
				{
					base.Height = new System.Web.UI.WebControls.Unit();
				}
			}
		}

		Thickness IControl.Margin
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(base.Style["margin-left"], out left)) thickness.Left = left;
				if (double.TryParse(base.Style["margin-top"], out top)) thickness.Top = top;
				if (double.TryParse(base.Style["margin-right"], out right)) thickness.Right = right;
				if (double.TryParse(base.Style["margin-bottom"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) base.Style["margin-left"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) base.Style["margin-top"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) base.Style["margin-right"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) base.Style["margin-bottom"] = string.Format("{0}px", value.Bottom);
			}
		}

		Thickness IControl.BorderWidth
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(base.Style["border-left-width"], out left)) thickness.Left = left;
				if (double.TryParse(base.Style["border-top-width"], out top)) thickness.Top = top;
				if (double.TryParse(base.Style["border-right-width"], out right)) thickness.Right = right;
				if (double.TryParse(base.Style["border-bottom-width"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) base.Style["border-left-width"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) base.Style["border-top-width"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) base.Style["border-right-width"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) base.Style["border-bottom-width"] = string.Format("{0}px", value.Bottom);
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
				Platform.Current.RemoveCssClassesStartingWith(this, "horizontal-alignment");
				Platform.Current.AddCssClass(this, "horizontal-alignment-" + value.ToString().ToLower());
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
				Platform.Current.RemoveCssClassesStartingWith(this, "vertical-alignment");
				Platform.Current.AddCssClass(this, "vertical-alignment-" + value.ToString().ToLower());
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