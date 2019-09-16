using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.RPC.Controls.Layout
{
	/// <summary>
	/// It is a control that represents a grid where we can store objects.
	/// <para xml:lang="es">
	/// Es un control que representa una cuadricula donde podemos almacenar objetos.
	/// </para>
	/// </summary>
	public class Grid : Container, IGrid
	{
		public int ColumnCount
		{
			get
			{
				return (int) Get(nameof(ColumnCount));
			}
			set
			{
				Set(nameof(ColumnCount), value);
			}
		}

		public int RowCount
		{
			get
			{
				return (int) Get(nameof(RowCount));
			}
			set
			{
				Set(nameof(RowCount), value);
			}
		}

		public IControl GetContent(int row, int column)
		{
			return (IControl) Invoke(nameof(GetContent), row, column);
		}

		public void SetContent(int row, int column, IControl content)
		{
			Invoke(nameof(SetContent), row, column, content);
		}

		public int GetColumnSpan(IControl content)
		{
			return (int) Invoke(nameof(GetColumnSpan), content);
		}

		public void SetColumnSpan(int columnSpan, IControl content)
		{
			Invoke(nameof(SetColumnSpan), columnSpan, content);
		}

		public void SetRowSpan(int rowSpan, IControl content)
		{
			Invoke(nameof(SetRowSpan), rowSpan, content);
		}

		public int GetRowSpan(IControl content)
		{
			return (int) Invoke(nameof(GetRowSpan), content);
		}

		public void SetWidth(int column, double width)
		{
			Invoke(nameof(SetWidth), column, width);
		}

		public double GetWidth(int column)
		{
			return (double) Invoke(nameof(GetWidth), column);
		}

		public void SetHeight(int row, double height)
		{
			Invoke(nameof(SetHeight), row, height);
		}

		public double GetHeight(int row)
		{
			return (double) Invoke(nameof(GetHeight), row);
		}

		/// <summary>
		/// Space that this grid will set between one cell and another
		/// <para xml:lang="es">
		/// Es el espacio que el grid fijara entre una celda y otra.
		/// </para>
		/// </summary>
		public Thickness CellMargin
		{
			get
			{
				return (Thickness) Get(nameof(CellMargin));
			}
			set
			{
				Set(nameof(CellMargin), value);
			}
		}

		/// <summary>
		/// Space that this grid will set between a cell's border and that cell's content
		/// <para xml:lang="es">
		/// Es el espacio que el grid fijara entre el limite de la celda y el contenido de la celda.
		/// </para>
		/// </summary>
		public Thickness CellPadding
		{
			get
			{
				return (Thickness) Get(nameof(CellPadding));
			}
			set
			{
				Set(nameof(CellPadding), value);
			}
		}
	}
}