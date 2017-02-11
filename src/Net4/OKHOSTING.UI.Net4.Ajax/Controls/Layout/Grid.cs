using System.Linq;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;

namespace OKHOSTING.UI.Net4.Ajax.Controls.Layout
{
	/// <summary>
	/// A container for storing objects grid and has design properties.
	/// <para xml:lang="es">
	/// Un contenedor de cuadricula para almacenar objetos y tiene propiedades de diseño.
	/// </para>
	/// </summary>
	public class Grid : System.Web.UI.WebControls.Table, IGrid
	{
		protected int _ColumnCount = 0;

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
				return Platform.Current.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = Platform.Current.Parse(value);
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
				return Platform.Current.Parse(base.BorderColor);
			}
			set
			{
				base.BorderColor = Platform.Current.Parse(value);
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
		/// Gets or sets the margin to the left, top, right and bottom the grid.
		/// <para xml:lang="es">
		/// Obtiene o establece el margen hacia la izquierda, arriba, derecha y abajo del grid.
		/// </para>
		/// </summary>
		/// <value>The margin.
		/// <para xml:lang="es">El margen.</para>
		/// </value>
		Thickness IControl.Margin
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(base.Style["margin-left"], out left)) thickness.Left = left;
				if (double.TryParse(base.Style["margin-top"], out top)) thickness.Top = top;
				if (double.TryParse(base.Style["margin-right"], out right)) thickness.Right = right;
				if (double.TryParse(base.Style["margin-bottom"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) base.Style["margin-left"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) base.Style["margin-top"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) base.Style["margin-right"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) base.Style["margin-bottom"] = string.Format("{0}px", value.Bottom);
			}
		}

		/// <summary>
		/// Gets or sets the width of the border of the grid.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del grid</para>
		/// </summary>
		/// <value>The width of the border.</value>
		Thickness IControl.BorderWidth
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				//Verifies the value you get the width of the border of each side of the grid
				if (double.TryParse(base.Style["border-left-width"], out left)) thickness.Left = left;
				if (double.TryParse(base.Style["border-top-width"], out top)) thickness.Top = top;
				if (double.TryParse(base.Style["border-right-width"], out right)) thickness.Right = right;
				if (double.TryParse(base.Style["border-bottom-width"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				//Verifies y sets the value you get the width of the edge of each side of the grid
				if (value.Left.HasValue) base.Style["border-left-width"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) base.Style["border-top-width"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) base.Style["border-right-width"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) base.Style["border-bottom-width"] = string.Format("{0}px", value.Bottom);
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
				Platform.Current.RemoveCssClassesStartingWith(this, "horizontal-alignment");
				Platform.Current.AddCssClass(this, "horizontal-alignment-" + value.ToString().ToLower());
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
				Platform.Current.RemoveCssClassesStartingWith(this, "vertical-alignment");
				Platform.Current.AddCssClass(this, "vertical-alignment-" + value.ToString().ToLower());
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
			get
			{
				return _ColumnCount;
			}
			set
			{
				_ColumnCount = value;

				foreach (System.Web.UI.WebControls.TableRow row in Rows)
				{
					while (row.Cells.Count < value)
					{
						row.Cells.Add(new System.Web.UI.WebControls.TableCell());
					}

					while (row.Cells.Count > value)
					{
						row.Cells.RemoveAt(row.Cells.Count - 1);
					}
				}
			}
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
			get
			{
				return Rows.Count;
			}
			set
			{
				while (Rows.Count < value)
				{
					Rows.Add(new System.Web.UI.WebControls.TableRow());
				}

				while (Rows.Count > value)
				{
					Rows.RemoveAt(Rows.Count - 1);
				}

				//re-set columns
				((IGrid) this).ColumnCount = _ColumnCount;
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
			if (Rows[row].Cells[column].Controls.Count == 0)
			{
				return null;
			}

			return (IControl)Rows[row].Cells[column].Controls[0];
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
			if (row > Rows.Count)
			{
				throw new ArgumentOutOfRangeException(nameof(row));
			}

			if (column > _ColumnCount)
			{
				throw new ArgumentOutOfRangeException(nameof(column));
			}

			while (Rows[row].Cells.Count < _ColumnCount)
			{
				Rows[row].Cells.Add(new System.Web.UI.WebControls.TableCell());
			}

			Rows[row].Cells[column].Controls.Clear();
			Rows[row].Cells[column].Controls.Add((System.Web.UI.Control)content);
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
		void IGrid.SetColumnSpan(int columnSpan, IControl content)
		{
			System.Web.UI.WebControls.TableCell cell = (System.Web.UI.WebControls.TableCell) ((System.Web.UI.WebControls.WebControl) content).Parent;
			cell.ColumnSpan = columnSpan;
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
			System.Web.UI.WebControls.TableCell cell = (System.Web.UI.WebControls.TableCell)((System.Web.UI.WebControls.WebControl)content).Parent;
			return cell.ColumnSpan;
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
			System.Web.UI.WebControls.TableCell cell = (System.Web.UI.WebControls.TableCell)((System.Web.UI.WebControls.WebControl)content).Parent;
			cell.RowSpan = rowSpan;
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
			System.Web.UI.WebControls.TableCell cell = (System.Web.UI.WebControls.TableCell)((System.Web.UI.WebControls.WebControl)content).Parent;
			return cell.RowSpan;
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
			foreach (System.Web.UI.WebControls.TableRow row in base.Rows)
			{
				row.Cells[column].Width = new System.Web.UI.WebControls.Unit(width, System.Web.UI.WebControls.UnitType.Pixel);
			}
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
			if (base.Rows.Count == 0)
			{
				return 0;
			}

			return base.Rows[0].Cells[column].Width.Value;
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
			base.Rows[row].Height = new System.Web.UI.WebControls.Unit(height, System.Web.UI.WebControls.UnitType.Pixel);
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
			return base.Rows[row].Height.Value;
		}
	}
}