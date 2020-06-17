using System;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI.Controls.Layout
{
	/// <summary>
	/// Returns all controls inside the grid.
	/// <para xml:lang="es">
	/// Devuelve todos los controles que hay dentro del grid.
	/// </para>
	/// </summary>
	public static class IGridExtensions
	{
		/// <summary>
		/// Gets all controlls.
		/// <para xml:lang="es">
		/// Obtenemos todos los controles que contiene el grid.
		/// </para>
		/// </summary>
		/// <returns>The all controlls.
		/// <para xml:lang="es">Todos los controles.</para>
		/// </returns>
		/// <param name="grid">Grid.</param>
		public static IEnumerable<IControl> GetAllControlls(this IGrid grid)
		{
			for (int row = 0; row < grid.RowCount; row++)
			{
				for (int column = 0; column < grid.ColumnCount; column++)
				{
					var content = grid.GetContent(row, column);

					if (content != null)
					{
						yield return content;
					}
				}
			}
		}

		/// <summary>
		/// Change column content especific to other especific column
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="fromColumn"></param>
		/// <param name="toColumn"></param>
		public static void MoveColumnContent(this IGrid grid, int fromColumn, int toColumn)
		{
			int rows = grid.RowCount;

			for (int row = 0; row < rows; row++)
			{
				var content = grid.GetContent(row, fromColumn);

				if (content != null)
				{
					grid.SetContent(row, toColumn, content);
				}
			}
		}

		/// <summary>
		/// Change row content especific to other especific row
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="fromRow"></param>
		/// <param name="toRow"></param>
		public static void MoveRowContent(this IGrid grid, int fromRow, int toRow)
		{
			int columns = grid.ColumnCount;

			for (int column = 0; column < columns; column++)
			{
				var content = grid.GetContent(fromRow, column);

				if (content != null)
				{
					grid.SetContent(toRow, column, content);
				}
			}
		}

		/// <summary>
		/// Change column content especific to other especific column but verify if the column receiver contain it
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="position"></param>
		/// <param name="columnReceiver"></param>
		public static void InsertColumn(this IGrid grid, int position)
		{
			int columns = grid.ColumnCount;
			grid.ColumnCount++;

			for (int column = columns; column > position; column--)
			{
				MoveColumnContent(grid, column - 1, column);
			}
		}

		/// <summary>
		/// Change row content especific to other especific row but verify if the row receiver contain it
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="position"></param>
		/// <param name="rowReceiver"></param>
		public static void InsertRow(this IGrid grid, int position)
		{
			int rows = grid.RowCount;
			grid.RowCount++;

			for (int row = rows; row > position; row--)
			{
				MoveRowContent(grid, row - 1, row);
			}
		}

		/// <summary>
		/// Removes a specific row and moves up all rows below
		/// </summary>
		/// <param name="rowIndex">Zero based index of he row to be deleted</param>
		public static void RemoveRow(this IGrid grid, int rowIndex)
		{
			if (rowIndex >= grid.RowCount)
			{
				return;
			}

			//delete all controls of row that we want to delete
			for (int column = 0; column < grid.ColumnCount; column++)
			{
				var control = grid.GetContent(column, rowIndex);

				if (control != null)
				{
					grid.Children.Remove(control);
				}
			}

			//move up row controls that comes after row we want to remove
			for (int row = rowIndex + 1; row < grid.RowCount; row++)
			{
				grid.MoveRowContent(row, row - 1);
			}

			//remove last row
			grid.RowCount--;
		}

		/// <summary>
		/// Makes all cells empty (with no content)
		/// </summary>
		public static void ClearContent(this IGrid grid)
		{
			for (int r = 0; r < grid.RowCount; r++)
			{
				for (int c = 0; c < grid.ColumnCount; c++)
				{
					grid.SetContent(r, c, null);
				}
			}
		}

		/// <summary>
		/// Removes a specific column and moves left all columns on right
		/// </summary>
		/// <param name="columnIndex">Zero based index of he column to be deleted</param>
		public static void RemoveColumn(this IGrid grid, int columnIndex)
		{
			if (columnIndex >= grid.ColumnCount)
			{
				return;
			}

			//delete all controls of column that we want to delete
			for (int row = 0; row < grid.RowCount; row++)
			{
				var control = grid.GetContent(columnIndex, row);

				if (control != null)
				{
					grid.Children.Remove(control);
				}
			}

			//move left column controls that comes after the column we want to remove
			for (int column = columnIndex + 1; column < grid.ColumnCount; column++)
			{
				grid.MoveColumnContent(column, column - 1);
			}

			//remove last column
			grid.ColumnCount--;
		}

		/// <summary>
		/// Sets a collection of controls sequentially among the grids rows and columns,
		/// from left to right and top to bottom. 
		/// </summary>
		/// <remarks>
		/// Make sure you have sufficient rows and columns
		/// before making this call since this does not resize the grid.
		/// </remarks>
		public static void SetContent(this IGrid grid, IEnumerable<IControl> content)
		{
			var allControls = content.ToArray();

			for (int row = 0; row < grid.RowCount; row++)
			{
				for (int column = 0; column < grid.ColumnCount; column++)
				{
					int nextIndex = (row * grid.ColumnCount) + column;

					//did we finish?
					if (nextIndex >= allControls.Length)
					{
						return;
					}

					var control = allControls[nextIndex];
					grid.SetContent(row, column, control);
				}
			}
		}

		/// <summary>
		/// Adds the headers as the first row of the grid, then adds every row below the header.
		/// Usefull to create data grids.
		/// </summary>
		/// <remarks>
		/// Make sure you have sufficient rows and columns
		/// before making this call since this does not resize the grid.
		/// </remarks>
		public static void SetContent(this IGrid grid, IEnumerable<IControl> headers, IEnumerable<IEnumerable<IControl>> rows)
		{
			var headersArray = headers.ToArray();
			var rowsArray = rows.ToArray();

			//set headers
			for (int column = 0; column < headersArray.Length; column++)
			{
				grid.SetContent(0, column, headersArray[column]);
			}

			//set content
			for (int row = 0; row < rowsArray.Length; row++)
			{
				var rowArray = rowsArray[row].ToArray();

				for (int column = 0; column < rowArray.Length; column++)
				{
					grid.SetContent(row, column, rowArray[column]);
				}
			}
		}

		/// <summary>
		/// Sets a collection of controls sequentially among one of the grids rows,
		/// from left to right. 
		/// </summary>
		/// <remarks>
		/// Make sure you have sufficient rows and columns
		/// before making this call since this does not resize the grid.
		/// </remarks>
		public static void SetContentRow(this IGrid grid, int row, IEnumerable<IControl> content)
		{
			var allControls = content.ToArray();

			for (int column = 0; column < grid.ColumnCount && column < allControls.Length; column++)
			{
				var control = allControls[column];
				grid.SetContent(row, column, control);
			}
		}

		/// <summary>
		/// Sets a collection of controls sequentially among one of the grids columns,
		/// from top to bottom. 
		/// </summary>
		/// <remarks>
		/// Make sure you have sufficient rows and columns
		/// before making this call since this does not resize the grid.
		/// </remarks>
		public static void SetContentColumn(this IGrid grid, int column, IEnumerable<IControl> content)
		{
			var allControls = content.ToArray();

			for (int row = 0; row < grid.RowCount; row++)
			{
				var control = allControls[row];
				grid.SetContent(row, column, control);
			}
		}

		/// <summary>
		/// Instead of adding the header as the first row, a smaller grid containing all headers
		/// and the values of one row will be added in each cell, sequentially. Usefull for small
		/// devices where you need a "responsive" kind of grid layout.
		/// </summary>
		/// <remarks>
		/// Make sure you have sufficient rows and columns
		/// before making this call since this does not resize the grid.
		/// </remarks>
		public static void SetContentMultipleHeaders(this IGrid grid, IEnumerable<IControl> headers, IEnumerable<IEnumerable<IControl>> rows)
		{
			var headersArray = headers.ToArray();
			var rowsArray = rows.ToArray();

			//set content
			for (int row = 0; row < rowsArray.Length; row++)
			{
				var rowArray = rowsArray[row].ToArray();
				var smallGrid = Core.BaitAndSwitch.Create<IGrid>();


				//set headers
				for (int column = 0; column < headersArray.Length; column++)
				{
					grid.SetContent(0, column, headersArray[column]);
				}

				for (int column = 0; column < rowArray.Length; column++)
				{
					grid.SetContent(row, column, rowArray[column]);
				}
			}
		}

		/// <summary>
		/// Distributes all columns with equal width each so they fill up all the grid's total width
		/// </summary>
		public static void DistributeWidth(this IGrid grid)
		{
			if (grid.Width == null || double.IsNaN(grid.Width.Value))
			{
				return;
			}

			double width = grid.Width.Value / grid.ColumnCount;

			for (int i = 0; i < grid.ColumnCount; i++)
			{
				grid.SetWidth(i, width);
			}
		}

		/// <summary>
		/// Distributes all columns with equal width each so they fill up all the grid's total width
		/// </summary>
		public static void DistributeHeight(this IGrid grid)
		{
			if (grid.Height == null || double.IsNaN(grid.Height.Value))
			{
				return;
			}

			double height = grid.Height.Value / grid.RowCount;

			for (int i = 0; i < grid.RowCount; i++)
			{
				grid.SetHeight(i, height);
			}
		}

		/// <summary>
		/// Sets the same width to all columns in the grid
		/// </summary>
		public static void SetWidths(this IGrid grid, double width)
		{
			for (int i = 0; i < grid.ColumnCount; i++)
			{
				grid.SetWidth(i, width);
			}
		}

		/// <summary>
		/// Sets a respective width to each column in the grid
		/// </summary>
		public static void SetWidths(this IGrid grid, IEnumerable<double> widths)
		{
			int i = 0;

			foreach (var width in widths)
			{
				grid.SetWidth(i, width);
				i++;
			}
		}

		/// <summary>
		/// Sets the same width to all columns in the grid
		/// </summary>
		public static void SetHeights(this IGrid grid, double height)
		{
			for (int i = 0; i < grid.RowCount; i++)
			{
				grid.SetHeight(i, height);
			}
		}

		/// <summary>
		/// Sets a respective height to each column in the grid
		/// </summary>
		public static void SetHeights(this IGrid grid, IEnumerable<double> heights)
		{
			int i = 0;

			foreach (var height in heights)
			{
				grid.SetHeight(i, height);
				i++;
			}
		}

		/// <summary>
		/// Returns the row and column where a control is positioned inside a grid. 
		/// If the control is not inside the grid, an exception is thrown. 
		/// </summary>
		/// <returns>
		/// Position of the control inside the grid, or NULL if the control is not found in the grid
		/// </returns>
		public static (int row, int column) GetPosition(this IGrid grid, IControl control)
		{
			if (control == null)
			{
				throw new ArgumentNullException(nameof(control));
			}

			for (int row = 0; row < grid.RowCount; row++)
			{
				for (int column = 0; column < grid.RowCount; column++)
				{
					var gridContent = grid.GetContent(row, column);

					if (control.Equals(gridContent))
					{
						return (row, column);
					}
				}
			}

			throw new ArgumentOutOfRangeException(nameof(control), "This control is contained directly on this grid");
		}
	}
}