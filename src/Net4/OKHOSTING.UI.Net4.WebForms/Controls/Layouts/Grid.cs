using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls.Layouts
{
	public class Grid : System.Web.UI.WebControls.Table, UI.Controls.Layouts.IGrid
	{
		protected int _ColumnCount = 0;

		public int ColumnCount
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

		public int RowCount
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
				ColumnCount = _ColumnCount;
			}
		}

		IPage IControl.Page
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public IControl GetContent(int row, int column)
		{
			if (Rows[row].Cells[column].Controls.Count == 0)
			{
				return null;
			}

			return (IControl) Rows[row].Cells[column].Controls[0];
		}

		public void SetContent(int row, int column, IControl content)
		{
			Rows[row].Cells[column].Controls.Clear();
			Rows[row].Cells[column].Controls.Add((System.Web.UI.Control) content);
		}
	}
}