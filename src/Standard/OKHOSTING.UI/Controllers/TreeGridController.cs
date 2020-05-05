using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OKHOSTING.UI.Controllers
{
	public class TreeGridController : Controller
	{
		IGrid Grid;

		/// <summary>
		/// The controls that will be placed at the top of the grid, almost always displaying the column names
		/// </summary>
		public IEnumerable<IControl> Header { get; set; }
		
		/// <summary>
		/// The rows of this grid
		/// </summary>
		public IEnumerable<Row> Rows { get; set; }

		public TreeGridController()
		{
		}

		public TreeGridController(IPage page) : base(page)
		{
		}

		protected internal override void OnStart()
		{
			Grid = Core.BaitAndSwitch.Create<IGrid>();
			Refresh();
		}

		public override void Refresh()
		{
			IControl[] headers = Header.ToArray();

			Grid.ClearContent();
			Grid.ColumnCount = headers.Length + 1; //always add a 0 column that will display the +- icons to open and collapse the children rows
			Grid.RowCount = 1;
			Grid.ShowGridLines = true;
			
			Row[] rows = Rows.ToArray();

			//set headers
			for (int column = 1; column <= headers.Length; column++)
			{
				Grid.SetContent(0, column, headers[column - 1]);
			}

			//set rows
			for (int rowIndex = 0; rowIndex < rows.Length; rowIndex++)
			{
				AddRow(rows, rowIndex);
			}

			Page.Content = Grid;
		}

		protected void AddRow(Row[] rows, int rowIndex)
		{
			Row row = rows[rowIndex];
			Grid.RowCount++;

			//set content of the row, except for expand button
			var content = row.Content.ToArray();
			
			for (int column = 1; column < Grid.ColumnCount; column++)
			{
				Grid.SetContent(Grid.RowCount - 1, column, content[column - 1]);
			}

			if (row.Children != null && row.Children.Any())
			{
				//create expand/collapse button and put it on the first cell
				var cmdExpand = Core.BaitAndSwitch.Create<ILabelButton>();

				if (row.Collapsed)
				{
					cmdExpand.Text = "+";
				}
				else
				{
					cmdExpand.Text = "-";
				}

				cmdExpand.Tag = row;
				cmdExpand.Click += cmdExpand_Click;

				Grid.SetContent(Grid.RowCount - 1, 0, cmdExpand);

				//show children only if the row is not collapsed
				if (!row.Collapsed)
				{
					var childrenMargin = content[0].Margin ?? new Thickness(0);
					childrenMargin = new Thickness(childrenMargin.Left + 20, childrenMargin.Top, childrenMargin.Right, childrenMargin.Bottom);

					var children = row.Children.ToArray();

					for (int childrenIndex = 0; childrenIndex < children.Length; childrenIndex++)
					{
						children[childrenIndex].Content.First().Margin = childrenMargin;

						AddRow(children, childrenIndex);
					}
				}
			}
		}

		private void cmdExpand_Click(object sender, EventArgs e)
		{
			var cmdExpand = (ILabelButton) sender;
			var row = (Row) cmdExpand.Tag;

			//reverse value
			row.Collapsed = !row.Collapsed;
			Refresh();
		}

		/// <summary>
		/// Represents a row in a TreeGrid, with optional parent and children rows
		/// </summary>
		public class Row
		{
			/// <summary>
			/// The content that must be placed in the row, each control will be put in a column
			/// </summary>
			public IEnumerable<IControl> Content { get; set; }

			/// <summary>
			/// When true, the row will not display it's children. 
			/// When false, the children rows will be visible.
			/// </summary>
			public bool Collapsed { get; set; }

			/// <summary>
			/// The children rows of this row, will be visible when collapsed is false, with a little padding to the right of the current row
			/// </summary>
			public ICollection<Row> Children { get; set; }
		}
	}
}