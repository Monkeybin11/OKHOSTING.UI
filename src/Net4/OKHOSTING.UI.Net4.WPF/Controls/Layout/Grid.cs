using System;
using System.Windows;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Net4.WPF.Controls.Layout
{
	/// <summary>
	/// /// A container for storing objects grid and has design properties.
	/// <para xml:lang="es">
	/// Un contenedor de cuadricula para almacenar objetos y tiene propiedades de diseño.
	/// </para>
	/// </summary>
	public class Grid : System.Windows.Controls.Grid, IGrid
	{
		/// <summary>
		/// Inicialize a new intance of the Grid class.
		/// <para xml:lang="es">	
		/// Inicializa una nueva instancia de la clase Grid.
		/// </para>
		/// </summary>
		public Grid()
		{
            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch;

            Width = Double.NaN;
            Height = Double.NaN;
        }

		/// <summary>
		/// /// Gets or sets the number of columns that will contain the grid.
		/// <para xml:lang="es">
		/// Obtiene o establece el numero de columnas que contendra el grid.
		/// </para>
		/// </summary>
		/// <value>The column count.
		/// <para xml:lang="es">El numero de columnas.</para>
		/// </summary>
		int IGrid.ColumnCount
		{
			get
			{
				return base.ColumnDefinitions.Count;
			}
			set
			{
				//remove all controls from rows to be removed
				for (int i = 0; i < base.Children.Count; i++)
				{
					UIElement element = base.Children[i];

					if (Grid.GetColumn(element) > value)
					{
						base.Children.Remove(element);
					}
				}

				while (base.ColumnDefinitions.Count < value)
				{
					base.ColumnDefinitions.Add(new System.Windows.Controls.ColumnDefinition());
				}

				while (base.ColumnDefinitions.Count > value)
				{
					base.ColumnDefinitions.RemoveAt(base.ColumnDefinitions.Count - 1);
				}
			}
		}

		/// <summary>
		/// Gets or sets the row count.
		/// <para xml:lang="es">
		/// Obtiene o establece el numero de filas que contiene el grid.
		/// </para>
		/// </summary>
		int IGrid.RowCount
		{
			get
			{
				return base.RowDefinitions.Count;
			}
			set
			{
				//remove all controls from rows to be removed
				for (int i = 0; i < base.Children.Count; i++)
				{
					UIElement element = base.Children[i];

					if (Grid.GetRow(element) > value)
					{
						base.Children.Remove(element);
					}
				}

				while (base.RowDefinitions.Count < value)
				{
					base.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
				}

				while (base.RowDefinitions.Count > value)
				{
					base.RowDefinitions.RemoveAt(base.RowDefinitions.Count - 1);
				}
			}
		}

		/// <summary>
		/// Gets the number of rows and columns of the grid
		/// <para xml:alng="es">Obtiene el numero de filas y columnas del grid</para>
		/// </summary>
		/// <param name="row">Row
		/// <para xml:lang="es">Las filas
		/// </param>
		/// <param name="column">Column.
		/// <para xml:lang="es">Las columnas.</para>
		/// </param>
		/// <returns>The content.
		/// <para xml:lang="es">El contenido.</para>
		/// </returns>
		IControl IGrid.GetContent(int row, int column)
		{
			foreach (UIElement children in base.Children)
			{
				if (Grid.GetRow(children) == row && Grid.GetColumn(children) == column)
				{
					return (IControl) children;
				}
			}

			return null;
		}

		/// <summary>
		/// Sets the content of the grid.
		/// <para xml:lang="es">
		/// Establece el contenido del grid.
		/// </para>
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
			var currentControl = ((IGrid)this).GetContent(row, column);

			if (currentControl != null)
			{
				base.Children.Remove((System.Windows.UIElement) currentControl);
			}

			Grid.SetRow((System.Windows.UIElement) content, row);
			Grid.SetColumn((System.Windows.UIElement) content, column);

			base.Children.Add((System.Windows.UIElement) content);
		}

		/// <summary>
		/// It is used to set the margins and paddings of the Grid.
		/// <para xml:lang="es">
		/// Se utilizara para establecer los margenes y paddings del Grid.
		/// </para>
		/// </summary>
		/// <param name="arrangeSize">Arrange size
		/// <para xml:lang="es">Fija el tamaño</para>
		/// </param>
		/// <returns>The arrange size
		/// <para xml:lang="es">El tamaño fijado.</para>
		/// </returns>
		protected override Size ArrangeOverride(Size arrangeSize)
		{
			//apply paddings here? http://stackoverflow.com/questions/1319974/wpf-grid-with-column-row-margin-padding
			return base.ArrangeOverride(arrangeSize);
		}

		/// <summary>
		/// The identifier dispose.
		/// <para xml:lang="es">El identificador dispose.</para>
		/// </summary>
		void IDisposable.Dispose()
		{
		}

		/// <summary>
		/// Sets the column span.
		/// <para xml:lang="es">
		/// Establece el espacio que abarca la columna.
		/// </para>
		/// </summary>
		/// <param name="columnSpan">Column span.
		/// <para xml:lang="es">Espacio que abarca la columna</para>
		/// </param>
		/// <param name="content">Content.
		/// <para xml:lang="es">El contenido.</para>
		/// </param>
		void IGrid.SetColumnSpan(int columnSpan, IControl content)
		{
			SetColumnSpan((UIElement) content, columnSpan);
		}

		/// <summary>
		/// Gets the column span.
		/// <para xml:lang="es">Obtiene el espacio que abarca la columna.</para>
		/// </summary>
		/// <param name="content">Content.
		/// <para xml:lang="es">El contenido.</para>
		/// </param>
		/// <returns>The column span.
		/// <para xml:lang="es">El espacio que abarca la columna.</para>
		/// </returns>
		int IGrid.GetColumnSpan(IControl content)
		{
			return GetColumnSpan((UIElement) content);
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
			SetRowSpan((UIElement) content, rowSpan);
		}

		/// <summary>
		/// Gets the row span.
		/// <para xml:lang="es">Obtiene el espacio que abarca la fila.</para>
		/// </summary>
		/// <param name="content">Content.
		/// <para xml:lang="es">El contenido.</para>
		/// </param>
		/// <returns>The row span.
		/// <para xml:lang="es">El espacio que abarca la fila.</para>
		/// </returns>
		int IGrid.GetRowSpan(IControl content)
		{
			return GetRowSpan((UIElement) content);
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
			base.ColumnDefinitions[column].Width = new GridLength(width, GridUnitType.Pixel);
		}

		/// <summary>
		/// Gets the width of the specified column.
		/// <para xml:lang="es">Obtiene el ancho de la columna especificada.</para>
		/// </summary>
		/// <param name="column">Column.
		/// <para xml:lang="es">La columna.</para>
		/// </param>
		/// <returns>The width.
		/// <para xml:lang="es">El ancho.</para>
		/// </returns>
		double IGrid.GetWidth(int column)
		{
			return base.ColumnDefinitions[column].Width.Value;
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
			base.RowDefinitions[row].Height = new GridLength(height, GridUnitType.Pixel);
		}

		/// <summary>
		/// Gets the height of the specified row.
		/// <para xml:lang="es">Obtiene la altura de la fila especificada.</para>
		/// </summary>
		/// <param name="row">Row.
		/// <para xml:lang="es">La fila.</para>
		/// </param>
		/// <returns>The height.
		/// <para xml:lang="es">La altura</para>
		/// </returns>
		double IGrid.GetHeight(int row)
		{
			return base.RowDefinitions[row].Height.Value;
		}

		#region IControl

		/// <summary>
		/// Gets or sats wether the control is visible or not.
		/// <para xml:lang="es">
		/// Obtiene o establece si el control es visible o no.
		/// </para>
		/// </summary>
		bool IControl.Visible
		{
			get
			{
				return base.Visibility == System.Windows.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = System.Windows.Visibility.Visible;
				}
				else
				{
					base.Visibility = System.Windows.Visibility.Hidden;
				}
			}
		}

		/// <summary>
		/// Gets or sets wether the control is enabled or not
		/// <para xml:lang="es">
		/// Obtiene o establece si el control es habilitado o no.
		/// </para>
		/// </summary>
		bool IControl.Enabled
		{
			get
			{
				return base.IsEnabled;
			}
			set
			{
				base.IsEnabled = value;
			}
		}

		/// <summary>
		/// Width of the control, in density independent pixels
		/// <para xml:lang="es">
		/// Ancho del control, en dencidad de pixeles independientes.
		/// </para>
		/// </summary>
		double? IControl.Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				if (value.HasValue)
				{
					base.Width = value.Value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the height of the grid.
		/// <para xml:lang="es">
		/// Obtiene o establece la altura del grid.
		/// </para>
		/// </summary>
		double? IControl.Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				if (value.HasValue)
				{
					base.Height = value.Value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the margin to the left, top, right and bottom the grid.
		/// <para xml:lang="es">
		/// Obtiene o establece el margen hacia la izquierda, arriba, derecha y abajo del grid.
		/// </para>
		/// </summary>
		Thickness IControl.Margin
		{
			get
			{
				return App.Parse(base.Margin);
			}
			set
			{
				base.Margin = App.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the color of the background of the grid.
		/// <para xml:lang="es">
		/// Obtiene o establece el color de fondo del grid.
		/// </para>
		/// </summary>
		Color IControl.BackgroundColor
		{
			get
			{
				return App.Parse(((System.Windows.Media.SolidColorBrush)base.Background).Color);
			}
			set
			{
				base.Background = new System.Windows.Media.SolidColorBrush(App.Parse(value));
			}
		}

		/// <summary>
		/// Gets or sets the color of the border of the grid.
		/// <para xml:lang="es">
		/// Obtiene o establece el color de borde del grid.
		/// </para>
		/// </summary>
		Color IControl.BorderColor
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the width of the grid.
		/// <para xml:lang="es">
		/// Obtiene o establece el ancho del grid.
		/// </para>
		/// </summary>
		Thickness IControl.BorderWidth
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the horizontal alignment.
		/// <para xml:lang="es">
		/// Obtiene o establece la alineacion horizontal del grid.
		/// </para>
		/// </summary>
		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return App.Parse(base.HorizontalAlignment);
			}
			set
			{
				base.HorizontalAlignment = App.Parse(value);
			}
		}

		/// <summary>
		///  Gets or sets the vertical alignment.
		/// <para xml:lang="es">
		/// Obtiene o establece la alineacion vertical del grid.
		/// </para>
		/// </summary>
		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return App.Parse(base.VerticalAlignment);
			}
			set
			{
				base.VerticalAlignment = App.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the cell margin.
		/// <para xml:lang="es">
		/// Obtiene o establece el margen de las celdas en el grid.
		/// </para>
		/// </summary>
		Thickness IGrid.CellMargin
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the cell padding.
		/// <para xml:lang="es">
		/// Obtiene o establece el pading de las celdas en el grid.
		/// </para>
		/// </summary>
		Thickness IGrid.CellPadding
		{
			get; set;
		}

		#endregion
	}
}