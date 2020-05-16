﻿using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI.Builders.Forms
{
	/// <summary>
	/// It represents a form to store content.
	/// <para xml:lang="es">Representa un formulario para almacenar contenido.</para>
	/// </summary>
	public class Form: IBuilder<IGrid>, IDisposable
	{
		#region Fields and properties

		protected readonly IGrid Grid = BaitAndSwitch.Create<IGrid>();

		/// <summary>
		/// Collection of fields that will be displayed in the current form
		/// <para xml:lang="es">Colección de campos que se mostarara en el formulario actual.</para>
		/// </summary>
		public readonly IEnumerable<Field> Fields;

		/// <summary>
		/// Determines wether the labels will be shown at the right or the top of each value
		/// <para xml:lang="es">Determina si las etiquetas se mostraran en la parte derecha o la parte superior de cada valor.</para>
		/// </summary>
		public readonly CaptionPosition LabelPosition;

		/// <summary>
		/// Gets or sets the number of columns to display horizontally
		/// <para xml:lang="es">Obtiene o establece el numero de columnas que se muestran horizontalmente.</para>
		/// </summary>
		public readonly int RepeatColumns;

		/// <summary>
		/// Gets the is valid.
		/// <para xml:lang="es">Establece si los campos son validos.</para>
		/// </summary>
		public bool IsValid
		{
			get
			{
				return !Fields.Where(f => !f.Editor.IsValid).Any();
			}
		}

		IControl IBuilder.Control
		{
			get
			{
				return Grid;
			}
		}

		public IGrid Control
		{
			get
			{
				return Grid;
			}
		}

		#endregion

		#region Methods

		public Form(IEnumerable<Field> fields): this(fields, 2, CaptionPosition.Left)
		{ 
		}

		public Form(IEnumerable<Field> fields, int columns) : this(fields, columns, CaptionPosition.Left)
		{
		}

		public Form(IEnumerable<Field> fields, int columns, CaptionPosition captionPosition)
		{
			Fields = fields.ToArray();
			RepeatColumns = columns;
			LabelPosition = captionPosition;
			
			//the grid that will actually be displayed to the user and contain all the fields
			Grid = BaitAndSwitch.Create<IGrid>();

			//column counter
			int currentColumn = 0;

			//if there are more than one category, group fields by category
			bool categorize = false;
			string currentCategory = string.Empty;

			#region Sort fields and init values

			//sort fields by required, category
			var sorted = Fields.ToList();

			sorted.Sort
			(
				delegate (Field f1, Field f2)
				{
					//set a "Category.SortOrder.Name" string comparission
					string val1, val2;

					val1 = f1.SortOrder.ToString("0:000000000000000") + f1.Category + "." + (f1.Editor.Control.Enabled ? "1" : "0") + "." + (f1.Editor.Required ? "0" : "1") + (f1.TableWide ? "1" : "0") + f1.Name;
					val2 = f2.SortOrder.ToString("0:000000000000000") + f2.Category + "." + (f2.Editor.Control.Enabled ? "1" : "0") + "." + (f2.Editor.Required ? "0" : "1") + (f2.TableWide ? "1" : "0") + f2.Name;

					//compare categories
					return val1.CompareTo(val2);
				}
			);

			//init all fields
			foreach (Field field in sorted)
			{
				field.Container = this;

				if (string.IsNullOrWhiteSpace(field.Category))
				{
					field.Category = "General";
				}

				if (field.Category != "General")
				{
					categorize = true;
				}
			}

			#endregion

			#region Create cells with LabelPosition = Left

			//If label position is left
			if (LabelPosition == CaptionPosition.Left)
			{
				Grid.ColumnCount = RepeatColumns < 2 ? 2 : (int) Math.Max(RepeatColumns, Math.Ceiling((decimal) RepeatColumns / 2) * 2);
				Grid.RowCount++;

				//add every field
				foreach (Field field in sorted)
				{
					//if a new category is found, add a new category row
					if (currentCategory != field.Category && categorize)
					{
						//create new category row
						CreateCategoryRow(field.Category, Grid);

						currentColumn = 0;
						currentCategory = field.Category;
					}

					//if a field with TableWide = true is found, create a row for this field only
					if (field.TableWide)
					{
						//reset counter
						currentColumn = 0;

						//create new rows for this field
						CreateTableWideRow(field, Grid);

						//go to next field
						Grid.RowCount++;
						currentColumn = 0;
						continue;
					}

					//create new row if this is the first row or if RepeatColumns has been reached 
					if (currentColumn >= RepeatColumns)
					{
						Grid.RowCount++;
						currentColumn = 0;
					}

					//Add name cell
					Grid.SetContent(Grid.RowCount - 1, currentColumn, field.Caption);
					currentColumn++;

					//Add value cell
					Grid.SetContent(Grid.RowCount - 1, currentColumn, field.Editor.Control);
					currentColumn++;
				}
			}

			#endregion

			#region Create cells with LabelPosition = Top

			//If label position is top
			else
			{
				Grid.ColumnCount = RepeatColumns;
				Grid.RowCount += 2;

				//add every field
				foreach (Field field in sorted)
				{
					//if a new category is found, add a new category row
					if (currentCategory != field.Category && categorize)
					{
						//create new category row
						CreateCategoryRow(field.Category, Grid);

						//reset counter
						currentColumn = 0;

						//update current category
						currentCategory = field.Category;
					}

					//if a field with TableWide = true is found, create a row for this field only
					if (field.TableWide)
					{
						//create new rows for this field
						CreateTableWideRow(field, Grid);

						//reset counter
						currentColumn = 0;

						//go to next field
						continue;
					}

					//create new row if this is the first row or if RepeatColumns has been reached 
					if (currentColumn >= RepeatColumns)
					{
						currentColumn = 0;
						Grid.RowCount += 2;
					}

					//Add name cells to the almost last row
					Grid.SetContent(Grid.RowCount - 2, currentColumn, field.Caption);

					//Add value cell to the last row
					Grid.SetContent(Grid.RowCount - 1, currentColumn, field.Editor.Control);

					//increment column counter
					currentColumn++;
				}
			}

			#endregion
		}

		/// <summary>
		/// Searches for a field with the specified Id
		/// <para xml:lang="es">Busca un campo con Id especificado.</para>
		/// </summary>
		/// <param name="fieldName">Id of the field to be searched
		/// <para xml:lang="es">Id del campo que va a ser buscado.</para>
		/// </param>
		/// <returns>If found, the field with the specified Id, null otherwise
		/// <para xml:lang="es">Si lo encuentra, el campo con el Id especificado, de lo contrario nulo.</para>
		/// </returns>
		public Field this[string fieldName]
		{
			get
			{
				return Fields.Where(f => f.Name == fieldName).SingleOrDefault();
			}
		}

		//protected

		/// <summary>
		/// Creates a division row with a category name
		/// <para xml:lang="es">Crea una fila de divición con el nombre de una categoria.</para>
		/// </summary>
		/// <param name="category">Name of the category
		/// <para xml:lang="es">Nombre de la categooria.</para>
		/// </param>
		protected void CreateCategoryRow(string category, IGrid grid)
		{
			ILabel caption = BaitAndSwitch.Create<ILabel>();
			caption.Text = category;

			grid.RowCount++;
			grid.SetContent(grid.RowCount - 1, 0, caption);
			grid.SetColumnSpan(grid.ColumnCount, caption);
		}

		/// <summary>
		/// Creates a row that includes a label and another row for the value of a TableWide field
		/// <para xml:lang="es">Crea una fila que incluye una etiqueta y otra fila para el valor de un campo TableWide.</para>
		/// </summary>
		/// <param name="field">FormField that will be included in these rows</param>
		protected void CreateTableWideRow(Field field, IGrid grid)
		{
			//add a full row for the caption
			grid.RowCount++;
			grid.SetContent(grid.RowCount - 1, 0, field.Caption);
			grid.SetColumnSpan(grid.ColumnCount, field.Caption);

			//and another full row for the value
			grid.RowCount++;
			grid.SetContent(grid.RowCount - 1, 0, field.Editor.Control);
			grid.SetColumnSpan(grid.ColumnCount, field.Editor.Control);
		}

		public void Dispose()
		{
			foreach (var field in Fields)
			{
				field.Caption?.Dispose();
				field.Editor?.Dispose();
			}
		}

		#endregion
	}
}