using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI.Builders.Forms
{
	/// <summary>
	/// Creates a form with fields that allow you to easily display
	/// and capture information from the user in a organized grid
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
		public readonly CaptionPosition CaptionPosition;

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
			RepeatColumns = columns;
			CaptionPosition = captionPosition;
			
			//the grid that will actually be displayed to the user and contain all the fields
			Grid = BaitAndSwitch.Create<IGrid>();

			#region Sort fields and init values

			//sort fields by required, category
			//var sorted = fields.ToList();

			//sorted.Sort
			//(
			//	delegate (Field f1, Field f2)
			//	{
			//		//set a "Category.SortOrder.Name" string comparission
			//		string val1, val2;

			//		val1 = f1.SortOrder.ToString("0:000000000000000") + f1.Category + "." + (f1.Editor.Control.Enabled ? "1" : "0") + "." + (f1.Editor.Required ? "0" : "1") + (f1.TableWide ? "1" : "0") + f1.Name;
			//		val2 = f2.SortOrder.ToString("0:000000000000000") + f2.Category + "." + (f2.Editor.Control.Enabled ? "1" : "0") + "." + (f2.Editor.Required ? "0" : "1") + (f2.TableWide ? "1" : "0") + f2.Name;

			//		//compare categories
			//		return val1.CompareTo(val2);
			//	}
			//);
			
			Fields = fields.ToArray();

			//init all fields
			foreach (Field field in Fields)
			{
				field.Container = this;
			}

			#endregion

			switch(CaptionPosition)
			{
				case CaptionPosition.Left:
				case CaptionPosition.Right:
					BuildWithCaptionLeftOrRight();
					break;

				case CaptionPosition.Top:
				case CaptionPosition.Bottom:
					BuildWithCaptionTopOrBottom();
					break;

				case CaptionPosition.None:
					BuildWithCaptionNone();
					break;
			}
		}
		
		#endregion

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

		public void Dispose()
		{
			foreach (var field in Fields)
			{
				field.Caption?.Dispose();
				field.Editor?.Dispose();
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
		protected void CreateCategoryRow(string category)
		{
			ILabel caption = BaitAndSwitch.Create<ILabel>();
			caption.Text = category;

			Grid.RowCount++;
			Grid.SetContent(Grid.RowCount - 1, 0, caption);
			Grid.SetColumnSpan(Grid.ColumnCount, caption);
		}

		/// <summary>
		/// Creates a row that includes a label and another row for the value of a TableWide field
		/// <para xml:lang="es">Crea una fila que incluye una etiqueta y otra fila para el valor de un campo TableWide.</para>
		/// </summary>
		/// <param name="field">FormField that will be included in these rows</param>
		protected void CreateTableWideRows(Field field)
		{
			//add 2 new rows

			switch (CaptionPosition)
			{
				case CaptionPosition.Left:
				case CaptionPosition.Right:
				case CaptionPosition.Top:
					Grid.RowCount = Grid.RowCount + 2;
					Grid.SetContent(Grid.RowCount - 2, 0, field.Caption);
					Grid.SetContent(Grid.RowCount - 1, 0, field.Editor.Control);
					Grid.SetColumnSpan(Grid.ColumnCount, field.Caption);
					break;

				case CaptionPosition.Bottom:
					Grid.RowCount = Grid.RowCount + 2;
					Grid.SetContent(Grid.RowCount - 2, 0, field.Editor.Control);
					Grid.SetContent(Grid.RowCount - 1, 0, field.Caption);
					Grid.SetColumnSpan(Grid.ColumnCount, field.Caption);
					break;

				case CaptionPosition.None:
					Grid.RowCount = Grid.RowCount + 1;
					Grid.SetContent(Grid.RowCount - 1, 0, field.Editor.Control);
					break;
			}

			Grid.SetColumnSpan(Grid.ColumnCount, field.Editor.Control);
		}

		protected void BuildWithCaptionLeftOrRight()
		{
			bool categorize = Fields.Where(f => !string.IsNullOrWhiteSpace(f.Category)).Any();
			string currentCategory = string.Empty;
			int currentColumn = 0;

			Grid.ColumnCount = RepeatColumns < 2 ? 2 : (int) Math.Max(RepeatColumns, Math.Ceiling((decimal)RepeatColumns / 2) * 2);
			Grid.RowCount++;

			//add every field
			foreach (Field field in Fields)
			{
				//if a new category is found, add a new category row
				if (currentCategory != field.Category && categorize)
				{
					//create new category row
					CreateCategoryRow(field.Category);

					currentColumn = 0;
					currentCategory = field.Category;
				}

				//if a field with TableWide = true is found, create a row for this field only
				if (field.TableWide)
				{
					//reset counter
					currentColumn = 0;

					//create new rows for this field
					CreateTableWideRows(field);

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

				if (CaptionPosition == CaptionPosition.Left)
				{
					//Add caption cell
					Grid.SetContent(Grid.RowCount - 1, currentColumn, field.Caption);
					currentColumn++;

					//Add value cell
					Grid.SetContent(Grid.RowCount - 1, currentColumn, field.Editor.Control);
					currentColumn++;
				}
				else if (CaptionPosition == CaptionPosition.Right)
				{
					//Add value cell
					Grid.SetContent(Grid.RowCount - 1, currentColumn, field.Editor.Control);
					currentColumn++;

					//Add caption cell
					Grid.SetContent(Grid.RowCount - 1, currentColumn, field.Caption);
					currentColumn++;
				}
			}
		}

		protected void BuildWithCaptionTopOrBottom()
		{
			bool categorize = Fields.Where(f => !string.IsNullOrWhiteSpace(f.Category)).Any();
			string currentCategory = string.Empty;
			int currentColumn = 0;

			Grid.ColumnCount = RepeatColumns;
			Grid.RowCount += 2;

			//add every field
			foreach (Field field in Fields)
			{
				//if a new category is found, add a new category row
				if (currentCategory != field.Category && categorize)
				{
					//create new category row
					CreateCategoryRow(field.Category);

					//reset counter
					currentColumn = 0;

					//update current category
					currentCategory = field.Category;
				}

				//if a field with TableWide = true is found, create a row for this field only
				if (field.TableWide)
				{
					//create new rows for this field
					CreateTableWideRows(field);

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

				if (CaptionPosition == CaptionPosition.Top)
				{
					//Add caption cell to the almost last row
					Grid.SetContent(Grid.RowCount - 2, currentColumn, field.Caption);

					//Add value cell to the last row
					Grid.SetContent(Grid.RowCount - 1, currentColumn, field.Editor.Control);
				}
				else if (CaptionPosition == CaptionPosition.Bottom)
				{
					//Add value cell to the almost last row
					Grid.SetContent(Grid.RowCount - 2, currentColumn, field.Editor.Control);

					//Add caption cells to the last row
					Grid.SetContent(Grid.RowCount - 1, currentColumn, field.Caption);
				}
				//increment column counter
				currentColumn++;
			}
		}

		protected void BuildWithCaptionNone()

		{
			bool categorize = Fields.Where(f => !string.IsNullOrWhiteSpace(f.Category)).Any();
			string currentCategory = string.Empty;
			int currentColumn = 0;

			Grid.ColumnCount = RepeatColumns;
			Grid.RowCount++;

			//add every field
			foreach (Field field in Fields)
			{
				//if a new category is found, add a new category row
				if (currentCategory != field.Category && categorize)
				{
					//create new category row
					CreateCategoryRow(field.Category);

					currentColumn = 0;
					currentCategory = field.Category;
				}

				//if a field with TableWide = true is found, create a row for this field only
				if (field.TableWide)
				{
					//reset counter
					currentColumn = 0;

					//create new rows for this field
					CreateTableWideRows(field);

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

				//Add value cell
				Grid.SetContent(Grid.RowCount - 1, currentColumn, field.Editor.Control);
				currentColumn++;
			}
		}
	}
}