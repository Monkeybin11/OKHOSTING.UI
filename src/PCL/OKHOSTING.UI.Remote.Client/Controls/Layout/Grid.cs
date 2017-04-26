using System.Linq;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;

namespace OKHOSTING.UI.Remote.Client.Controls.Layout
{
	/// <summary>
	/// A container for storing objects grid and has design properties.
	/// <para xml:lang="es">
	/// Un contenedor de cuadricula para almacenar objetos y tiene propiedades de diseño.
	/// </para>
	/// </summary>
	public class Grid : Control, IGrid
	{
		/// <summary>
		/// Gets or sets the number of columns that will contain the grid.
		/// <para xml:lang="es">Obtiene o establece el numero de columnas que contendra el grid.</para>
		/// </summary>
		/// <value>The column count.
		/// <para xml:lang="es">El numero de columnas.</para>
		/// </value>
		public int ColumnCount { get; set; }

		/// <summary>
		/// Gets or sets the row count.
		/// <para xml:lang="es">Obtiene o establece el numero de filas que contiene el grid.</para>
		/// </summary>
		/// <value>The row count.
		/// <para xml:lang="es">El numero de filas.</para>
		/// </value>
		public int RowCount { get; set; }

		/// <summary>
		/// Gets or sets the cell margin.
		/// <para xml:lang="es">Obtiene o establece el margen de las celdas en el grid.</para>
		/// </summary>
		/// <value>The cell margin.
		/// <para xml:lang="es">El margen de las celdas.</para>
		/// </value>
		public Thickness CellMargin { get; set; }

		/// <summary>
		/// Gets or sets the cell padding.
		/// <para xml:lang="es">Obtiene o establece el pading de las celdas en el grid.</para>
		/// </summary>
		/// <value>The cell padding.
		/// <para xml:lang="es">El pading de las celdas.</para>
		/// </value>
		public Thickness CellPadding { get; set; }

		/// <summary>
		/// Gets the number of rows and columns of the grid
		/// <para xml:alng="es">Obtiene el numero de filas y columnas del grid</para>
		/// </summary>
		/// <returns>The content.
		/// <para xml:lang="es">El contenido.</para>
		/// </returns>
		/// <param name="row">Row.
		/// <para xml:lang="es">Las filas
		/// </param>
		/// <param name="column">Column.
		/// <para xml:lang="es">Las columnas.</para>
		/// </param>
		public IControl GetContent(int row, int column)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Sets the content of the grid.
		/// <para xml:lang="es">Establece el contenido del grid</para>
		/// </summary>
		/// <param name="row">Row.
		/// <para xml:lang="es">Las filas.</para>
		/// </param>
		/// <param name="column">Column.
		/// <para xml:lang="es">Las columnas</para>
		/// </param>
		/// <param name="content">Content.
		/// <para xml:lang="es">El contenido del grid.</para>
		/// </param>
		public void SetContent(int row, int column, IControl content)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets all controls of the current grid.
		/// <para xml:lang="es">Obtiene todos los controles del grid actual</para>
		/// </summary>
		/// <returns>The all controls.
		/// <para xml:lang="es">Todos los controles.</para>
		/// </returns>
		public List<IControl> GetAllControls()
		{
			return IGridExtensions.GetAllControlls(this).ToList();
		}

		/// <summary>
		/// Sets the column span.
		/// <para xml:lang="es">Establece el espacio que abarca la columna.</para>
		/// </summary>
		/// <param name="columnSpan">Column span.
		/// <para xml:lang="es">Espacio que abarca la columna</para>
		/// </param>
		/// <param name="content">Content.
		/// <para xml:lang="es">El contenido.</para>
		/// </param>
		public void SetColumnSpan(int columnSpan, IControl content)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the column span.
		/// <para xml:lang="es">Obtiene el espacio que abarca la columna.</para>
		/// </summary>
		/// <returns>The column span.
		/// <para xml:lang="es">El espacio que abarca la columna.</para>
		/// </returns>
		/// <param name="content">Content.
		/// <para xml:lang="es">El contenido.</para>
		/// </param>
		public int GetColumnSpan(IControl content)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Sets the row span.
		/// <para xml:lang="es">Establece el espacio que abarca la fila.</para>
		/// </summary>
		/// <param name="rowSpan">Row span.
		/// <para xml:lang="es">Espacio que abarca la fila.</para>
		/// </param>
		/// <param name="content">Content.
		/// <para xml:lang="es">Contenido.</para>
		/// </param>
		public void SetRowSpan(int rowSpan, IControl content)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the row span.
		/// <para xml:lang="es">Obtiene el espacio que abarca la fila.</para>
		/// </summary>
		/// <returns>The row span.
		/// <para xml:lang="es">El espacio que abarca la fila.</para>
		/// </returns>
		/// <param name="content">Content.
		/// <para xml:lang="es">El contenido.</para>
		/// </param>
		public int GetRowSpan(IControl content)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Sets the width of each column of the grid.
		/// <para xml:lang="es">Establece el ancho de cada columna del grid.</para>
		/// </summary>
		/// <param name="column">Column.
		/// <para xml:lang="es">La column.</para>
		/// </param>
		/// <param name="width">Width.
		/// <para xml:lang="es">El ancho.</para>
		/// </param>
		public void SetWidth(int column, double width)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the width of the specified column.
		/// <para xml:lang="es">Obtiene el ancho de la columna especificada.</para>
		/// </summary>
		/// <returns>The width.
		/// <para xml:lang="es">El ancho.</para>
		/// </returns>
		/// <param name="column">Column.
		/// <para xml:lang="es">La columna.</para>
		/// </param>
		public double GetWidth(int column)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Sets the height of the specified row.
		/// <para xml:lang="es">Establece el alto de la fila especificada.</para>
		/// </summary>
		/// <param name="row">Row.
		/// <para xml:lang="es">La fila.</para>
		/// </param>
		/// <param name="height">Height.
		/// <para xml:lang="es">Alto.</para>
		/// </param>
		public void SetHeight(int row, double height)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the height of the specified row.
		/// <para xml:lang="es">Obtiene la altura de la fila especificada.</para>
		/// </summary>
		/// <returns>The height.
		/// <para xml:lang="es">La altura</para>
		/// </returns>
		/// <param name="row">Row.
		/// <para xml:lang="es">La fila.</para>
		/// </param>
		public double GetHeight(int row)
		{
			throw new NotImplementedException();
		}
	}
}