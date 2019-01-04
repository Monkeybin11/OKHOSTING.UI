using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Remote.Controls.Layout
{
	/// <summary>
	/// It is a control that represents a grid where we can store objects.
	/// <para xml:lang="es">
	/// Es un control que representa una cuadricula donde podemos almacenar objetos.
	/// </para>
	/// </summary>
	public class Grid : Container, IGrid
	{
		public Grid()
		{
		}

		public IControl[,] Content { get; set; }

		public Dictionary<IControl, int> ColumnSpans { get; set; }

		public Dictionary<IControl, int> RowSpans { get; set; }

		public double[] Widths { get; set; }

		public double[] Heights { get; set; }

		int _ColumnCount;

		public int ColumnCount
		{
			get
			{
				return _ColumnCount;
			}
			set
			{
				if (_ColumnCount != value)
				{
					_ColumnCount = value;
					SetColumnsAndRows();
				}
			}
		}

		int _RowCount
		{
			get
			{
				return _RowCount;
			}
			set
			{
				if (_RowCount != value)
				{
					_RowCount = value;
					SetColumnsAndRows();
				}
			}
		}

		public int RowCount { get; set; }

		public IControl GetContent(int row, int column)
		{
			return Content[row, column];
		}

		public void SetContent(int row, int column, IControl content)
		{
			Content[row, column] = content;
		}

		public int GetColumnSpan(IControl content)
		{
			return ColumnSpans[content];
		}

		public void SetColumnSpan(int columnSpan, IControl content)
		{
			ColumnSpans[content] = columnSpan;
		}

		public void SetRowSpan(int rowSpan, IControl content)
		{
			RowSpans[content] = rowSpan;
		}

		public int GetRowSpan(IControl content)
		{
			return RowSpans[content];
		}

		public void SetWidth(int column, double width)
		{
			Widths[column] = width;
		}

		public double GetWidth(int column)
		{
			return Widths[column];
		}

		public void SetHeight(int row, double height)
		{
			Heights[row] = height;
		}

		public double GetHeight(int row)
		{
			return Heights[row];
		}

		/// <summary>
		/// Space that this grid will set between one cell and another
		/// <para xml:lang="es">
		/// Es el espacio que el grid fijara entre una celda y otra.
		/// </para>
		/// </summary>
		public Thickness CellMargin { get; set; }

		/// <summary>
		/// Space that this grid will set between a cell's border and that cell's content
		/// <para xml:lang="es">
		/// Es el espacio que el grid fijara entre el limite de la celda y el contenido de la celda.
		/// </para>
		/// </summary>
		public Thickness CellPadding { get; set; }

		protected void SetColumnsAndRows()
		{
			var newContent = new IControl[RowCount, ColumnCount];

			for (int r = 0; r < RowCount; r++)
			{
				for (int c = 0; c < ColumnCount; c++)
				{
					newContent[r, c] = Content[r, c];
				}
			}

			Content = newContent;

			var newHeights = new double[RowCount];

			for (int r = 0; r < RowCount; r++)
			{
				newHeights[r] = Heights[r];
			}

			var newWidths = new double[ColumnCount];

			for (int c = 0; c < ColumnCount; c++)
			{
				newWidths[c] = Widths[c];
			}
		}

	}
}