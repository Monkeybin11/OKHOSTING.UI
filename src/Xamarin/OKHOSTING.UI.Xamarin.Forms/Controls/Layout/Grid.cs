using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace OKHOSTING.UI.Xamarin.Forms.Controls.Layout
{
	/// <summary>
	/// It is a control that represents a grid where we can store objects.
	/// <para xml:lang="es">
	/// Es un control que representa una cuadricula donde podemos almacenar objetos.
	/// </para>
	/// </summary>
	public class Grid : global::Xamarin.Forms.Grid, IGrid
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
				return base.ColumnDefinitions.Count;
			}
			set
			{
				while (base.ColumnDefinitions.Count < value)
				{
					base.ColumnDefinitions.Add(new global::Xamarin.Forms.ColumnDefinition());
				}

				while (base.ColumnDefinitions.Count > value)
				{
					for (int r = 0; r < RowDefinitions.Count; r++)
					{
						var currentContent = ((IGrid) this).GetContent(r, base.ColumnDefinitions.Count - 1);

						if (currentContent != null)
						{
							base.Children.Remove((global::Xamarin.Forms.View) currentContent);
						}
					}

					base.ColumnDefinitions.RemoveAt(base.ColumnDefinitions.Count - 1);
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
				return base.RowDefinitions.Count;
			}
			set
			{
				while (base.RowDefinitions.Count < value)
				{
					base.RowDefinitions.Add(new global::Xamarin.Forms.RowDefinition());
				}

				while (base.RowDefinitions.Count > value)
				{
					for (int c = 0; c < ColumnDefinitions.Count; c++)
					{
						var currentContent = ((IGrid) this).GetContent(base.RowDefinitions.Count - 1, c);

						if (currentContent != null)
						{
							base.Children.Remove((global::Xamarin.Forms.View) currentContent);
						}
					}

					base.RowDefinitions.RemoveAt(base.RowDefinitions.Count - 1);
				}
			}
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
			foreach (global::Xamarin.Forms.View children in base.Children)
			{
				if (global::Xamarin.Forms.Grid.GetRow(children) == row && global::Xamarin.Forms.Grid.GetColumn(children) == column)
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
			if (row > RowDefinitions.Count)
			{
				throw new ArgumentOutOfRangeException(nameof(row));
			}

			if (column > ColumnDefinitions.Count)
			{
				throw new ArgumentOutOfRangeException(nameof(column));
			}

			SetRow((global::Xamarin.Forms.View) content, row);
			SetColumn((global::Xamarin.Forms.View) content, column);

			//remove previous content, if any
			var currentContent = ((IGrid) this).GetContent(row, column);

			if (currentContent != null)
			{
				base.Children.Remove((global::Xamarin.Forms.View) currentContent);
			}

			base.Children.Add((global::Xamarin.Forms.View) content);
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
				return Forms.Platform.Parse(base.Padding);
			}
			set
			{
				base.Padding = Forms.Platform.Parse(value);
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
			return base.ColumnDefinitions[column].Width.Value;
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
			base.RowDefinitions[row].Height = new global::Xamarin.Forms.GridLength(height, global::Xamarin.Forms.GridUnitType.Star);
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
			return base.RowDefinitions[row].Height.Value;
		}

		#endregion

		#region IControl

		/// <summary>
		/// Gets or sets the name of the Control.
		/// <para xml:lang="es">Obtiene o establece el nommbre del control.</para>
		/// </summary>
		string IControl.Name
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the if the control visible.
		/// <para xml:lang="es">Obtiene o establece si el control es visible o no.</para>
		/// </summary>
		bool IControl.Visible
		{
			get
			{
				return base.IsVisible;
			}
			set
			{
				base.IsVisible = value;
			}
		}

		/// <summary>
		/// Gets or sets the control is enabled or not.
		/// <para xml:lang="es">
		/// Obtiene o establece si el control esta habilitado o no.
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
		/// Gets or sets the width of the control.
		/// <para xml:lang="es">Obtiene o establece el ancho del control.</para>
		/// </summary>
		double? IControl.Width
		{
			get
			{
				return base.WidthRequest;
			}
			set
			{
				if (value.HasValue)
				{
					base.WidthRequest = value.Value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the height of the control.
		/// <para xml:lang="es">Obtiene o establece la altura del control.</para>
		/// </summary>
		double? IControl.Height
		{
			get
			{
				return base.HeightRequest;
			}
			set
			{
				if (value.HasValue)
				{
					base.HeightRequest = value.Value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the control margin.
		/// <para xml:lang="es">
		/// Obtiene o establece el margen del control.
		/// </para>
		/// </summary>
		Thickness IControl.Margin
		{
			get
			{
				return Forms.Platform.Parse(base.Margin);
			}
			set
			{
				base.Margin = Forms.Platform.Parse(value);
			}
		}

		/// <summary>
		/// Space that this control will set between its content and its border
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre su contenido y su borde
		/// </para>
		/// </summary>
		Thickness IControl.Padding
		{
			get
			{
				return Forms.Platform.Parse(base.Padding);
			}
			set
			{
				base.Padding = Forms.Platform.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the backgroundcolor of the control.
		/// <para xml:lang="es">Obtiene o establece el color de fondo del control</para>
		/// </summary>
		Color IControl.BackgroundColor
		{
			get
			{
				return Forms.Platform.Parse(base.BackgroundColor);
			}
			set
			{
				base.BackgroundColor = Forms.Platform.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the bordercolor of the control.
		/// <para xml:lang="es">Obtiene o establece el color del borde del control.</para>
		/// </summary>
		Color IControl.BorderColor
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the borderwidth of the control.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del control.</para>
		/// </summary>
		Thickness IControl.BorderWidth
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the horizontal alignment of the control.
		/// <para xml:lang="es">
		/// Obtiene o establece la alineacion horizontal del control.
		/// </para>
		/// </summary>
		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Forms.Platform.Parse(base.HorizontalOptions.Alignment);
			}
			set
			{
				base.HorizontalOptions = new global::Xamarin.Forms.LayoutOptions(Forms.Platform.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets the vertical alignment of the control.
		/// <para xml:lang="es">Obtiene o establevce la alineacion vertical del control.</para>
		/// </summary>
		/// <value>The OKHOSTING . user interface . controls. IC ontrol. vertical alignment.</value>
		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Forms.Platform.ParseVerticalAlignment(base.VerticalOptions.Alignment);
			}
			set
			{
				base.VerticalOptions = new global::Xamarin.Forms.LayoutOptions(Forms.Platform.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">
		/// Obtiene o establece un objeto de valor arbitrario que puede ser usado para almacenar información personalizada sobre este elemento.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">
		/// Devuelve el valor previsto. Esta propiedad no contiene un valor predeterminado.
		/// </para>
		/// </remarks>
		object IControl.Tag
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets a list of classes that define a control's style. 
		/// Exactly the same concept as in CSS. 
		/// </summary>
		string IControl.CssClass { get; set; }

		/// <summary>
		/// Control that contains this control, like a grid, or stack
		/// </summary>
		IControl IControl.Parent
		{
			get
			{
				return (IControl)base.Parent;
			}
		}

		#endregion

		ICollection<IControl> IContainer.Children
		{
			get
			{
				return IGridExtensions.GetAllControlls(this).ToList();
			}
		}

		/// <summary>
		/// Dispose
		/// <para xml:lang="es">Libera la memoria</para>
		/// </summary>
		/// <returns>The identifier dispose.
		/// <para xml:lang="es">El identificador Dispose.</para>
		/// </returns>
		void IDisposable.Dispose()
		{
		}
	}
}