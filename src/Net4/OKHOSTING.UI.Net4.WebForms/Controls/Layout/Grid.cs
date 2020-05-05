using System.Linq;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Drawing;

namespace OKHOSTING.UI.Net4.WebForms.Controls.Layout
{
	/// <summary>
	/// A container for storing objects grid and has design properties.
	/// <para xml:lang="es">
	/// Un contenedor de cuadricula para almacenar objetos y tiene propiedades de diseño.
	/// </para>
	/// </summary>
	public class Grid : System.Web.UI.WebControls.Table, IGrid
	{
		protected Dictionary<int, double> ColumnWidths = new Dictionary<int, double>();
		protected Dictionary<int, double> RowHeights = new Dictionary<int, double>();

		protected Dictionary<IControl, int> RowSpans = new Dictionary<IControl, int>();
		protected Dictionary<IControl, int> ColumnSpans = new Dictionary<IControl, int>();
		protected Dictionary<(int, int), IControl> Content = new Dictionary<(int, int), IControl>();
		protected Dictionary<(int, int), System.Web.UI.WebControls.TableCell> Cells = new Dictionary<(int, int), System.Web.UI.WebControls.TableCell>();

		#region IControl

		/// <summary>
		/// Gets or sets the name of the grid.
		/// <para xml:lang="es">
		/// Obtiene o establece el nombre del grid.
		/// </para>
		/// </summary>
		/// <value>The name.
		/// <para xml:lang="es">El nombre.</para>
		/// </value>
		string IControl.Name
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

		/// <summary>
		/// Gets or sets the color of the background of the grid.
		/// <para xml:lang="es">
		/// Obtiene o establece el color de fondo del grid.
		/// </para>
		/// </summary>
		/// <value>The color of the background.
		/// <para xml:lang="es">El color de fondo.</para>
		/// </value>
		Color IControl.BackgroundColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		/// <summary>
		/// Gets or sets the color of the border of the grid.
		/// <para xml:lang="es">
		/// Obtiene o establece el color de borde del grid.
		/// </para>
		/// </summary>
		/// <value>The color of the border.
		/// <para xml:lang="es">El color del borde.</para>
		/// </value>
		Color IControl.BorderColor
		{
			get
			{
				return base.BorderColor;
			}
			set
			{
				base.BorderColor = value;
			}
		}

		/// <summary>
		/// Gets or sets the width of the grid.
		/// <para xml:lang="es">Obtiene o establece el ancho del grid.</para>
		/// </summary>
		/// <value>The width.
		/// <para xml:lang="es">El ancho.</para>
		/// </value>
		double? IControl.Width
		{
			get
			{
				if (base.Width.IsEmpty)
				{
					return null;
				}

				return base.Width.Value;
			}
			set
			{
				if (value.HasValue)
				{
					base.Width = new System.Web.UI.WebControls.Unit(value.Value, System.Web.UI.WebControls.UnitType.Pixel);
				}
				else
				{
					base.Width = new System.Web.UI.WebControls.Unit();
				}
			}
		}

		/// <summary>
		/// Gets or sets the height of the grid.
		/// <para xml:lang="es">Obtiene o establece la altura del grid.</para>
		/// </summary>
		/// <value>The height.
		/// <para xml:lang="es">La altura</para>
		/// </value>
		double? IControl.Height
		{
			get
			{
				if (base.Height.IsEmpty)
				{
					return null;
				}

				return base.Height.Value;
			}
			set
			{
				if (value.HasValue)
				{
					base.Height = new System.Web.UI.WebControls.Unit(value.Value, System.Web.UI.WebControls.UnitType.Pixel);
				}
				else
				{
					base.Height = new System.Web.UI.WebControls.Unit();
				}
			}
		}

		/// <summary>
		/// Space that this control will set between itself and it's container
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre si mismo y su contenedor.
		/// </para>
		/// </summary>
		Thickness IControl.Margin
		{
			get
			{
				return this.GetMargin();
			}
			set
			{
				this.SetMargin(value);
			}
		}

		/// <summary>
		/// Space that this control will set between itself and it's own border
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre si mismo y su propio borde
		/// </para>
		/// </summary>
		Thickness IControl.Padding
		{
			get
			{
				return this.GetPadding();
			}
			set
			{
				this.SetPadding(value);
			}
		}

		/// <summary>
		/// Gets or sets the width of the control. border.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del IControl.</para>
		/// </summary>
		/// <value>The width of the control. border.
		/// <para xml:lang="es">El ancho del borde del IControl</para>
		/// </value>
		Thickness IControl.BorderWidth
		{
			get
			{
				return this.GetBorderWidth();
			}
			set
			{
				this.SetBorderWidth(value);
			}
		}

		/// <summary>
		/// Gets or sets the horizontal alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal del grid.</para>
		/// </summary>
		/// <value>The horizontal alignment.
		/// <para xml:lang="es">La alineacion horizontal</para>
		/// </value>
		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				string cssClass = base.CssClass.Split().Where(c => c.StartsWith("horizontal-alignment")).SingleOrDefault();

				//if not bring horizontal alignment, align the grid to the left
				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return HorizontalAlignment.Left;
				}

				//Determines the horizontal alignment of the grid
				if (cssClass.EndsWith("left"))
				{
					return HorizontalAlignment.Left;
				}
				else if (cssClass.EndsWith("right"))
				{
					return HorizontalAlignment.Right;
				}
				else if (cssClass.EndsWith("center"))
				{
					return HorizontalAlignment.Center;
				}
				else if (cssClass.EndsWith("fill"))
				{
					return HorizontalAlignment.Fill;
				}
				else
				{
					return HorizontalAlignment.Left;
				}
			}
			set
			{
				this.RemoveCssClassesStartingWith("horizontal-alignment");
				this.AddCssClass("horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets the vertical alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacion vertical del grid.</para>
		/// </summary>
		/// <value>The vertical alignment.
		/// <para xml:lang="es">La alineacion vertical.</para>
		/// </value>
		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				string cssClass = base.CssClass.Split().Where(c => c.StartsWith("vertical-alignment")).SingleOrDefault();

				//if not bring vertical alignment, align the grid to the top
				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return VerticalAlignment.Top;
				}

				//Determines the vertical alignment of the grid.
				if (cssClass.EndsWith("top"))
				{
					return VerticalAlignment.Top;
				}
				else if (cssClass.EndsWith("bottom"))
				{
					return VerticalAlignment.Bottom;
				}
				else if (cssClass.EndsWith("center"))
				{
					return VerticalAlignment.Center;
				}
				else if (cssClass.EndsWith("fill"))
				{
					return VerticalAlignment.Fill;
				}
				else
				{
					return VerticalAlignment.Top;
				}
			}
			set
			{
				this.RemoveCssClassesStartingWith("vertical-alignment");
				this.AddCssClass("vertical-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">
		/// Obtiene o establece un valor de objeto arbitrario que se puede utilizar para almacenar información personalizada sobre este elemento.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">
		/// Devuelve el valor previsto. Esta propiedad no tiene ningún valor predeterminado.
		/// </para>
		/// </remmarks>
		object IControl.Tag
		{
			get; set;
		}

		/// <summary>
		/// Control that contains this control, like a grid, or stack
		/// </summary>
		IControl IControl.Parent
		{
			get
			{
				return (IControl) base.Parent;
			}
		}

		object ICloneable.Clone()
		{
			return MemberwiseClone();
		}

		#endregion

		/// <summary>
		/// Gets or sets the number of columns that will contain the grid.
		/// <para xml:lang="es">Obtiene o establece el numero de columnas que contendra el grid.</para>
		/// </summary>
		/// <value>The column count.
		/// <para xml:lang="es">El numero de columnas.</para>
		/// </value>
		int IGrid.ColumnCount
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the row count.
		/// <para xml:lang="es">Obtiene o establece el numero de filas que contiene el grid.</para>
		/// </summary>
		/// <value>The row count.
		/// <para xml:lang="es">El numero de filas.</para>
		/// </value>
		int IGrid.RowCount
		{
			get;
			set;
		}

		/// <summary>
		/// When set to true, shows all the cell borders inside the grid, when false, no cell border is shown
		/// </summary>
		bool IGrid.ShowGridLines
		{
			get
			{
				return base.GridLines == System.Web.UI.WebControls.GridLines.Both;
			}
			set
			{
				if (value)
				{
					base.GridLines = System.Web.UI.WebControls.GridLines.Both;
				}
				else
				{
					base.GridLines = System.Web.UI.WebControls.GridLines.None;
				}
			}
		}

		/// <summary>
		/// Gets or sets the cell margin.
		/// <para xml:lang="es">Obtiene o establece el margen de las celdas en el grid.</para>
		/// </summary>
		/// <value>The cell margin.
		/// <para xml:lang="es">El margen de las celdas.</para>
		/// </value>
		Thickness IGrid.CellMargin
		{
			get
			{
				return new Thickness(base.CellSpacing);
			}
			set
			{
				base.CellSpacing = (int) value.Bottom;
			}
		}

		/// <summary>
		/// Gets or sets the cell padding.
		/// <para xml:lang="es">Obtiene o establece el pading de las celdas en el grid.</para>
		/// </summary>
		/// <value>The cell padding.
		/// <para xml:lang="es">El pading de las celdas.</para>
		/// </value>
		Thickness IGrid.CellPadding
		{
			get
			{
				return new Thickness(base.CellSpacing);
			}
			set
			{
				base.CellSpacing = (int) value.Bottom;
			}
		}

		ICollection<IControl> IContainer.Children
		{
			get
			{
				return IGridExtensions.GetAllControlls(this).ToList();
			}
		}

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
		IControl IGrid.GetContent(int row, int column)
		{
			if (Content.ContainsKey((row, column)))
			{
				return Content[(row, column)];
			}

			else return null;
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
		void IGrid.SetContent(int row, int column, IControl content)
		{
			if (row > ((IGrid) this).RowCount)
			{
				throw new ArgumentOutOfRangeException(nameof(row));
			}

			if (column > ((IGrid) this).ColumnCount)
			{
				throw new ArgumentOutOfRangeException(nameof(column));
			}

			if (content == null && Content.ContainsKey((row, column)))
			{
				Content.Remove((row, column));
			}
			else
			{
				Content[(row, column)] = content;
			}
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
		void IGrid.SetColumnSpan(int columnSpan, IControl content)
		{
			if(columnSpan == 0)
			{
				columnSpan = 1;
			}

			ColumnSpans[content] = columnSpan;
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
		int IGrid.GetColumnSpan(IControl content)
		{
			if (ColumnSpans.ContainsKey(content))
			{
				return ColumnSpans[content];
			}

			else return 1;
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
		void IGrid.SetRowSpan(int rowSpan, IControl content)
		{
			if (rowSpan == 0)
			{
				rowSpan = 1;
			}

			RowSpans[content] = rowSpan;
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
		int IGrid.GetRowSpan(IControl content)
		{
			if (RowSpans.ContainsKey(content))
			{
				return RowSpans[content];
			}

			else return 1;
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
		void IGrid.SetWidth(int column, double width)
		{
			ColumnWidths[column] = width;
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
		double IGrid.GetWidth(int column)
		{
			if (ColumnWidths.ContainsKey(column))
			{
				return ColumnWidths[column];
			}

			else return 0;
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
		void IGrid.SetHeight(int row, double height)
		{
			RowHeights[row] = height;
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
		double IGrid.GetHeight(int row)
		{
			if (RowHeights.ContainsKey(row))
			{
				return RowHeights[row];
			}

			else return 0;
		}

		protected void RebuildGrid()
		{
			Rows.Clear();
			Cells.Clear();

			//add rows
			while (Rows.Count < ((IGrid) this).RowCount)
			{
				Rows.Add(new System.Web.UI.WebControls.TableRow());
			}

			for (int row = 0; row < Rows.Count; row++)
			{
				//row height
				if (RowHeights.ContainsKey(row))
				{
					Rows[row].Height = new System.Web.UI.WebControls.Unit(RowHeights[row], System.Web.UI.WebControls.UnitType.Pixel);
				}

				//add cells
				for (int column = 0; column < ((IGrid) this).ColumnCount; column++)
				{
					//there is already a cell in this position, because of rowspan or columnspan
					if (Cells.ContainsKey((row, column)))
					{
						continue;
					}

					//add cell to row
					var cell = new System.Web.UI.WebControls.TableCell();
					Rows[row].Cells.Add(cell);

					//column width
					if (ColumnWidths.ContainsKey(column))
					{
						cell.Width = new System.Web.UI.WebControls.Unit(ColumnWidths[column], System.Web.UI.WebControls.UnitType.Pixel);
					}

					//content
					var content = ((IGrid) this).GetContent(row, column);

					if (content != null)
					{
						//add content
						cell.Controls.Add((System.Web.UI.Control) content);

						//colspan
						int colspan = 1;
						int rowspan = 1;

						if (ColumnSpans.ContainsKey(content))
						{
							colspan = ColumnSpans[content];
						}

						if (RowSpans.ContainsKey(content))
						{
							rowspan = RowSpans[content];
						}

						if (colspan > 1)
						{
							cell.ColumnSpan = colspan;
						}

						if (rowspan > 1)
						{
							cell.RowSpan = rowspan;
						}

						for (int c2 = 0; c2 < colspan; c2++)
						{
							Cells[(row, column + c2)] = cell;

							for (int r2 = 1; r2 < rowspan; r2++)
							{
								Cells[(row + r2, column + c2)] = cell;
							}
						}
					}
				}
			}
		}

		protected override void OnPreRender(EventArgs e)
		{
			RebuildGrid();
			base.OnPreRender(e);
		}
	}
}