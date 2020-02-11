namespace OKHOSTING.UI.Controls.Layout
{
	/// <summary>
	/// It is a control that represents a grid where we can store objects.
	/// <para xml:lang="es">
	/// Es un control que representa una cuadricula donde podemos almacenar objetos.
	/// </para>
	/// </summary>
	public interface IGrid : IContainer
	{
		int ColumnCount { get; set; }
		int RowCount { get; set; }

		IControl GetContent(int row, int column);
		void SetContent(int row, int column, IControl content);

		void SetColumnSpan(int columnSpan, IControl content);
		int GetColumnSpan(IControl content);

		void SetRowSpan(int rowSpan, IControl content);
		int GetRowSpan(IControl content);

		void SetWidth(int column, double width);
		double GetWidth(int column);

		void SetHeight(int row, double height);
		double GetHeight(int row);

		/// <summary>
		/// Space that this grid will set between one cell and another
		/// <para xml:lang="es">
		/// Es el espacio que el grid fijara entre una celda y otra.
		/// </para>
		/// </summary>
		Thickness CellMargin { get; set; }

		/// <summary>
		/// Space that this grid will set between a cell's border and that cell's content
		/// <para xml:lang="es">
		/// Es el espacio que el grid fijara entre el limite de la celda y el contenido de la celda.
		/// </para>
		/// </summary>
		Thickness CellPadding { get; set; }
	}

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
		public static System.Collections.Generic.IEnumerable<IControl> GetAllControlls(this IGrid grid)
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
		/// Automatically adjusts the columns and rows of the grid to fit a specific width
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="containerWidth"></param>
		public static void MakeResponsive(this IGrid grid, int containerWidth)
		{
			grid.Width = containerWidth;
			int rows = grid.RowCount;
			int columns = grid.ColumnCount;

				for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < columns; column++)
                    {
					//posible solucion para decidir bajar contenido
					//double CW = containerWidth - grid.GetWidth(column);
					//if (grid.GetWidth(column) > CW) { }
					if (grid.GetContent(row, column) != null)
                        {
						grid.SetContent(grid.RowCount - 1, 0, grid.GetContent(row, column));
                            grid.RowCount++;
                        }
                    }
                }
		}

		/// <summary>
		/// Change column content especific to other especific column
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="columnSender"></param>
		/// <param name="columnReceiver"></param>
		public static void ChangeColumn(this IGrid grid, int columnSender, int columnReceiver)
		{
			int rows = grid.RowCount;

			for (int row = 0; row < rows; row++)
			{
				if (grid.GetContent(row, columnSender) != null)
				{
						grid.SetContent(row, columnReceiver, grid.GetContent(row, columnSender));
				}
			}
		}

		/// <summary>
		/// Change row content especific to other especific row
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="rowSender"></param>
		/// <param name="rowReceiver"></param>
		public static void ChangeRow(this IGrid grid, int rowSender, int rowReceiver)
		{
			int columns = grid.ColumnCount;

			for (int column = 0; column < columns; column++)
			{
				if(grid.GetContent(rowSender, column) != null)
				{
					grid.SetContent(rowReceiver, column, grid.GetContent(rowSender, column));
				}
			}
		}

		/// <summary>
		/// Change column content especific to other especific column but verify if the column receiver contain it
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="columnSender"></param>
		/// <param name="columnReceiver"></param>
		public static void InsertColumn(this IGrid grid, int columnSender, int columnReceiver)
		{
            int columns = grid.ColumnCount;
            grid.ColumnCount++;

            for (int column = columns; column > columnReceiver; column--)
            {
                ChangeColumn(grid, column - 1, column);
            }
            ChangeColumn(grid, columnSender, columnReceiver);
        }

		/// <summary>
		/// Change row content especific to other especific row but verify if the row receiver contain it
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="rowSender"></param>
		/// <param name="rowReceiver"></param>
		public static void InsertRow(this IGrid grid, int rowSender, int rowReceiver)
		{
			int rows = grid.RowCount;
			grid.RowCount++;

			for (int row = rows; row > rowReceiver; row--)
			{
				ChangeRow(grid, row - 1, row);
			}
			ChangeRow(grid, rowSender, rowReceiver);
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
				grid.ChangeRow(row, row - 1);
			}

			//remove last row
			grid.RowCount--;
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
				grid.ChangeColumn(column, column - 1);
			}

			//remove last column
			grid.ColumnCount--;
		}
	}
}