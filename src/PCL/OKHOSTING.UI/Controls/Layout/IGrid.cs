namespace OKHOSTING.UI.Controls.Layouts
{
	public interface IGrid : IControl
	{
		int ColumnCount { get; set; }
		int RowCount { get; set; }

		IControl GetContent(int row, int column);
		void SetContent(int row, int column, IControl content);

		/// <summary>
		/// Space that this grid will set between one cell and another
		/// </summary>
		Thickness CellMargin { get; set; }

		/// <summary>
		/// Space that this grid will set between a cell's border and that cell's content
		/// </summary>
		Thickness CellPadding { get; set; }
	}
}