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
			base.Controls.Add(InnerGrid);
        }

		/// <summary>
		/// The actual grid that contains all controls in a "stacky" way
		/// </summary>
		protected readonly Grid InnerGrid;

		public readonly ControlList Children;

		public string Name
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
				int last = ContainerStack.InnerGrid.Rows.Count - 1;
				ContainerStack.InnerGrid.RowCount = last + 1;
				ContainerStack.InnerGrid.SetContent(last + 2, 0, item);
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