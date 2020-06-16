using System;
using OKHOSTING.UI.Controls.Layout;
using System.Collections.Generic;
using System.Linq;
using View = global::Xamarin.Forms.View;

namespace OKHOSTING.UI.Xamarin.Forms.Controls.Layout
{
	/// <summary>
	/// It is a control that represents a grid where we can store objects.
	/// <para xml:lang="es">
	/// Es un control que representa una cuadricula donde podemos almacenar objetos.
	/// </para>
	/// </summary>
	public class Grid : Container<global::Xamarin.Forms.Grid>, IGrid
	{
		#region IGrid

		/// <summary>
		/// Gets or sets the column count.
		/// <para xml:lang="es">Obtiene o establece el conteo de columnas del grid</para>
		/// </summary>
		/// <value>The OKHOSTING . user interface . controls. layout. IG rid. column count.</value>
		int IGrid.ColumnCount
		{
			get
			{
				return Content.ColumnDefinitions.Count;
			}
			set
			{
				while (Content.ColumnDefinitions.Count < value)
				{
					Content.ColumnDefinitions.Add(new global::Xamarin.Forms.ColumnDefinition());
				}

				while (Content.ColumnDefinitions.Count > value)
				{
					for (int r = 0; r < RowDefinitions.Count; r++)
					{
						var currentContent = ((IGrid) this).GetContent(r, Content.ColumnDefinitions.Count - 1);

						if (currentContent != null)
						{
							Content.Children.Remove((View) currentContent);
						}
					}

					Content.ColumnDefinitions.RemoveAt(Content.ColumnDefinitions.Count - 1);
				}
			}
		}

		/// <summary>
		/// Gets or sets the row count.
		/// <para xml:lang="es">Obtiene o establece el conteo de filas del grid</para>
		/// </summary>
		/// <value>The OKHOSTING . user interface . controls. layout. IG rid. row count.</value>
		int IGrid.RowCount
		{
			get
			{
				return Content.RowDefinitions.Count;
			}
			set
			{
				while (Content.RowDefinitions.Count < value)
				{
					Content.RowDefinitions.Add(new global::Xamarin.Forms.RowDefinition());
				}

				while (Content.RowDefinitions.Count > value)
				{
					for (int c = 0; c < ColumnDefinitions.Count; c++)
					{
						var currentContent = ((IGrid) this).GetContent(Content.RowDefinitions.Count - 1, c);

						if (currentContent != null)
						{
							Content.Children.Remove((View) currentContent);
						}
					}

					Content.RowDefinitions.RemoveAt(Content.RowDefinitions.Count - 1);
				}
			}
		}

		/// <summary>
		/// When set to true, shows all the cell borders inside the grid, when false, no cell border is shown
		/// </summary>
		bool IGrid.ShowGridLines
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the controls conetent the grid
		/// <para xml:lang="es">Obtiene los controles que contiene del grid</para>
		/// </summary>
		/// <returns>Los controles que contiene el grid.</returns>
		/// <param name="row">Row.
		/// <para xml:lang="es">Numero de filas</para>
		/// </param>
		/// <param name="column">Column.
		/// <para xml:lang="es">Numero de columnas.</para>
		/// </param>
		IControl IGrid.GetContent(int row, int column)
		{
			foreach (View children in Content.Children)
			{
				if (GetRow(children) == row && GetColumn(children) == column)
				{
					return (IControl) children;
				}
			}

			return null;
		}

		/// <summary>
		/// Sets the controls content the grid.
		/// <para xml:lang="es">Establece los controles que contiene el grid.</para>
		/// </summary>
		/// <returns>The controls content the grid.
		/// <para xml:lang="es">Los controles que contiene el grid</para>
		/// </returns>
		/// <param name="row">Row.
		/// <para xml:lang="es">Las filas del grid.</para>
		/// </param>
		/// <param name="column">Column.
		/// <para xml:lang="es">Las columnas del control.</para>
		/// </param>
		/// <param name="content">Content.</param>
		void IGrid.SetContent(int row, int column, IControl content)
		{
			if (row > Content.RowDefinitions.Count)
			{
				throw new ArgumentOutOfRangeException(nameof(row));
			}

			if (column > Content.ColumnDefinitions.Count)
			{
				throw new ArgumentOutOfRangeException(nameof(column));
			}

			SetRow((View) content, row);
			SetColumn((View) content, column);

			//remove previous content, if any
			var currentContent = ((IGrid) this).GetContent(row, column);

			if (currentContent != null)
			{
				Content.Children.Remove((View) currentContent);
			}

			if (content != null)
			{
				Content.Children.Add((View) content);
			}
		}

		/// <summary>
		/// Gets or sets the cell margin.
		/// <para xml:lang="es">
		/// Obtiene o establece el margen de las celdas del grid.
		/// </para>
		/// </summary>
		Thickness IGrid.CellMargin
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the cell padding.
		/// <para xml:lang="es">Obtiene o establece el padding de las celdas del grid.</para>
		/// </summary>
		Thickness IGrid.CellPadding
		{
			get
			{
				return Forms.Platform.Parse(Content.Padding);
			}
			set
			{
				Content.Padding = Forms.Platform.Parse(value);
			}
		}

		/// <summary>
		/// Sets the columnSpan the cell.
		/// <para xml:lang="es">Establece las columnas que abarcara la celda.</para>
		/// </summary>
		/// <returns>The column span.
		/// <para xml:lang="es">Las columnas que abarcará la celda.</para>
		/// </returns>
		/// <param name="columnSpan">Column span.</param>
		/// <param name="content">Content.</param>
		void IGrid.SetColumnSpan(int columnSpan, IControl content)
		{
			SetColumnSpan((global::Xamarin.Forms.BindableObject) content, columnSpan);
		}

		/// <summary>
		/// Gets the ColumnSpan the cell.
		/// <para xml:lang="es">Obtiene el numero de columnas que abarca la celda.</para>
		/// </summary>
		/// <returns>The column span.
		/// <para xml:lang="es">Las colunmas que abarcara la celda.</para>
		/// </returns>
		/// <param name="content">Content.</param>
		int IGrid.GetColumnSpan(IControl content)
		{
			return GetColumnSpan((global::Xamarin.Forms.BindableObject) content);
		}

		/// <summary>
		/// Sets the RowSpan the cell.
		/// <para xml:lang="es">Establece el numero de filas que abarcara la celda</para>
		/// </summary>
		/// <returns>The row span.
		/// <para xml:lang="es">Las filas que abarcara la celda.</para>
		/// </returns>
		/// <param name="rowSpan">Row span.</param>
		/// <param name="content">Content.</param>
		void IGrid.SetRowSpan(int rowSpan, IControl content)
		{
			SetRowSpan((global::Xamarin.Forms.BindableObject) content, rowSpan);
		}

		/// <summary>
		/// Gets the RowSpan the cell.
		/// <para xml:lang="es">Obtiene las filas que abarcara la celda.</para>
		/// </summary>
		/// <returns>The row span.
		/// <para xml:lang="es">Las filas que abarcará la celda.</para>
		/// </returns>
		/// <param name="content">Content.</param>
		int IGrid.GetRowSpan(IControl content)
		{
			return GetRowSpan((global::Xamarin.Forms.BindableObject) content);
		}

		/// <summary>
		/// Sets the width of the grid.
		/// <para xml:lang="es">Establece el ancho del grid.</para>
		/// </summary>
		/// <returns>The width.
		/// <para xml:lang="es">El ancho.</para>
		/// </returns>
		/// <param name="column">Column.</param>
		/// <param name="width">Width.</param>
		void IGrid.SetWidth(int column, double width)
		{
			base.ColumnDefinitions[column].Width = new global::Xamarin.Forms.GridLength(width, global::Xamarin.Forms.GridUnitType.Star);
		}

		/// <summary>
		/// Gets the width of the grid.
		/// <para xml:lang="es">Obtiene el ancho del grid</para>
		/// </summary>
		/// <returns>The width.
		/// <para xml:lang="es">El ancho del grid.</para>
		/// </returns>
		/// <param name="column">Column.</param>
		double IGrid.GetWidth(int column)
		{
			return Content.ColumnDefinitions[column].Width.Value;
		}

		/// <summary>
		/// Sets of the height of the grid.
		/// <para xml:lang="es">Establece la altura del grid.</para>
		/// </summary>
		/// <returns>The height.
		/// <para xml:lang="es">La altura.</para>
		/// </returns>
		/// <param name="row">Row.</param>
		/// <param name="height">Height.</param>
		void IGrid.SetHeight(int row, double height)
		{
			Content.RowDefinitions[row].Height = new global::Xamarin.Forms.GridLength(height, global::Xamarin.Forms.GridUnitType.Star);
		}

		/// <summary>
		/// Gets the height of the grid.
		/// <para xml:lang="es">Obtiene la altura del grid.</para>
		/// </summary>
		/// <returns>The height.
		/// <para xml:lang="es">La altura del grid.</para>
		/// </returns>
		/// <param name="row">Row.</param>
		double IGrid.GetHeight(int row)
		{
			return Content.RowDefinitions[row].Height.Value;
		}

		#endregion

		public override ICollection<IControl> Children
		{
			get
			{
				return IGridExtensions.GetAllControlls(this).ToList();
			}
		}
	}
}