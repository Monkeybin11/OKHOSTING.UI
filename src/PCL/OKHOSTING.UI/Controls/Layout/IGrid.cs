namespace OKHOSTING.UI.Controls.Layout
{
	public interface IGrid : IControl
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
		/// </summary>
		Thickness CellMargin { get; set; }

		/// <summary>
		/// Space that this grid will set between a cell's border and that cell's content
		/// </summary>
		Thickness CellPadding { get; set; }
	}

	public static class IGridExtensions
	{
		public static System.Collections.Generic.IEnumerable<IControl> GetAllControlls(this IGrid grid)
		{
			for (int row = 0; row < ((IGrid) grid).RowCount; row++)
			{
				for (int column = 0; column < ((IGrid) grid).ColumnCount; column++)
				{
					yield return ((IGrid) grid).GetContent(row, column);
				}
			}
		}
	}
}