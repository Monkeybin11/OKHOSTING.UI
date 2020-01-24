﻿namespace OKHOSTING.UI.Controls.Layout
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

			//if (containerWidth > )
			//{
				for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < columns; column++)
                    {
						if (grid.GetContent(row, column) != null)
                        {
                            grid.SetContent(grid.RowCount - 1, 0, grid.GetContent(row, column));
                            grid.RowCount++;
                        }
                    }
                }
			//}
		}

		/// <summary>
		/// Change column content especific to other row especific
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="ColumnSender"></param>
		/// <param name="ColumnReceiver"></param>
		public static void ChangeColumn(this IGrid grid, int ColumnSender, int ColumnReceiver)
		{
			int rows = grid.RowCount;

			for (int row = 0; row < rows; row++)
			{
				if (grid.GetContent(row, ColumnSender) != null)
				{
					grid.SetContent(row, ColumnReceiver, grid.GetContent(row, ColumnSender));
				}
			}
		}

		/// <summary>
		/// Change row content especific to other especific row
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="RowSender"></param>
		/// <param name="RowReceiver"></param>
		public static void ChangeRow(this IGrid grid, int RowSender, int RowReceiver)
		{
			int columns = grid.ColumnCount;

			for (int column = 0; column < columns; column++)
			{
				if(grid.GetContent(RowSender, column) != null)
				{
					grid.SetContent(RowReceiver, column, grid.GetContent(RowSender, column));
				}
			}
		}
	}
}