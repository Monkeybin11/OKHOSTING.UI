using OKHOSTING.Core;
using OKHOSTING.Data.Validation;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OKHOSTING.UI.Controllers.Forms
{
	/// <summary>
	/// It represents a form to store content.
	/// <para xml:lang="es">Representa un formulario para almacenar contenido.</para>
	/// </summary>
	public class Form: Controller
	{
		public Form()
		{
		}

		public Form(IPage page): base(page)
		{
		}

		#region Fields and properties

		/// <summary>
		/// Collection of fields that will be displayed in the current form
		/// <para xml:lang="es">Colección de campos que se mostarara en el formulario actual.</para>
		/// </summary>
		public readonly List<FormField> Fields = new List<FormField>();

		/// <summary>
		/// Determines wether the labels will be shown at the right or the top of each value
		/// <para xml:lang="es">Determina si las etiquetas se mostraran en la parte derecha o la parte superior de cada valor.</para>
		/// </summary>
		public CaptionPosition LabelPosition { get; set; } = CaptionPosition.Left;

		/// <summary>
		/// Gets or sets the number of columns to display horizontally
		/// <para xml:lang="es">Obtiene o establece el numero de columnas que se muestran horizontalmente.</para>
		/// </summary>
		public int RepeatColumns { get; set; } = 1;

		/// <summary>
		/// Gets the is valid.
		/// <para xml:lang="es">Establece si los campos son validos.</para>
		/// </summary>
		public bool IsValid
		{
			get
			{
				return Fields.Where(f => f.IsValid).Count() == 0;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Creates all cells and controls based on the Fields collection
		/// <para xml:lang="es">Crea todas las celdas y los controles basados en la coleccion de campos.</para>
		/// </summary>
		protected internal override void OnStart()
		{
			//the grid that will actually be displayed to the user and contain all the fields
			IGrid content = BaitAndSwitch.Create<IGrid>();

			//column counter
			int currentColumn = 0;

			//if there are more than one category, group fields by category
			bool categorize = false;
			string currentCategory = string.Empty;

			#region Sort fields and init values

			//sort fields by required, category
			Fields.Sort
			(
				delegate (FormField f1, FormField f2)
				{
					//set categories to empty in case they are null
					if (string.IsNullOrWhiteSpace(f1.Category)) f1.Category = "General";
					if (string.IsNullOrWhiteSpace(f2.Category)) f2.Category = "General";

					//set a "Category.SortOrder.Name" string comparission
					string val1, val2;

					val1 = f1.SortOrder.ToString("0:000000000000000") + f1.Category + "." + (f1.ValueControl.Enabled ? "1" : "0") + "." + (f1.Required ? "0" : "1") + (f1.TableWide ? "1" : "0") + f1.Name;
					val2 = f2.SortOrder.ToString("0:000000000000000") + f2.Category + "." + (f2.ValueControl.Enabled ? "1" : "0") + "." + (f2.Required ? "0" : "1") + (f2.TableWide ? "1" : "0") + f2.Name;

					//compare categories
					return val1.CompareTo(val2);
				}
			);

			//init all fields
			foreach (FormField field in Fields)
			{
				field.Container = this;

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
				content.ColumnCount = RepeatColumns < 2 ? 2 : (int) Math.Max(RepeatColumns, Math.Ceiling((decimal) RepeatColumns / 2) * 2);
				content.RowCount++;

				//add every field
				foreach (FormField field in Fields)
				{
					//if a new category is found, add a new category row
					if (currentCategory != field.Category && categorize)
					{
						//create new category row
						CreateCategoryRow(field.Category, content);

						currentColumn = 0;
						currentCategory = field.Category;
					}

					//if a field with TableWide = true is found, create a row for this field only
					if (field.TableWide)
					{
						//reset counter
						currentColumn = 0;

						//create new rows for this field
						CreateTableWideRow(field, content);

						//go to next field
						content.RowCount++;
						currentColumn = 0;
						continue;
					}

					//create new row if this is the first row or if RepeatColumns has been reached 
					if (currentColumn >= RepeatColumns)
					{
						content.RowCount++;
						currentColumn = 0;
					}

					//Add name cell
					content.SetContent(content.RowCount - 1, currentColumn, field.CaptionControl);
					currentColumn++;

					//Add value cell
					content.SetContent(content.RowCount - 1, currentColumn, field.ValueControl);
					currentColumn++;
				}
			}

			#endregion

			#region Create cells with LabelPosition = Top

			//If label position is top
			else
			{
				content.ColumnCount = RepeatColumns;
				content.RowCount += 2;

				//add every field
				foreach (FormField field in Fields)
				{
					//if a new category is found, add a new category row
					if (currentCategory != field.Category && categorize)
					{
						//create new category row
						CreateCategoryRow(field.Category, content);

						//reset counter
						currentColumn = 0;

						//update current category
						currentCategory = field.Category;
					}

					//if a field with TableWide = true is found, create a row for this field only
					if (field.TableWide)
					{
						//create new rows for this field
						CreateTableWideRow(field, content);

						//reset counter
						currentColumn = 0;

						//go to next field
						continue;
					}

					//create new row if this is the first row or if RepeatColumns has been reached 
					if (currentColumn >= RepeatColumns)
					{
						currentColumn = 0;
						content.RowCount += 2;
					}

					//Add name cells to the almost last row
					content.SetContent(content.RowCount - 2, currentColumn, field.CaptionControl);

					//Add value cell to the last row
					content.SetContent(content.RowCount - 1, currentColumn, field.ValueControl);

					//increment column counter
					currentColumn++;
				}
			}

			#endregion

			Page.Content = content;
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
		public FormField this[string fieldName]
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
		protected void CreateTableWideRow(FormField field, IGrid grid)
		{
			//add a full row for the caption
			grid.RowCount++;
			grid.SetContent(grid.RowCount - 1, 0, field.CaptionControl);
			grid.SetColumnSpan(grid.ColumnCount, field.CaptionControl);

			//and another full row for the value
			grid.RowCount++;
			grid.SetContent(grid.RowCount - 1, 0, field.ValueControl);
			grid.SetColumnSpan(grid.ColumnCount, field.ValueControl);
		}

		public override void Dispose()
		{
			foreach (FormField field in Fields)
			{
				field.Dispose();
			}
		}

		#endregion

		#region Creating fields

		/// <summary>
		/// Creates a field that will contain a value of a specific type
		/// <para xml:lang="es">
		/// Crea un campo que contendra un valor de un tipo especifico.
		/// </para>
		/// </summary>
		public virtual FormField CreateFieldFor(Type type)
		{
			//validate arguments
			if (type == null) throw new ArgumentNullException("type");

			if (Nullable.GetUnderlyingType(type) != null)
			{
				type = Nullable.GetUnderlyingType(type);
			}

			//field
			FormField field;

			//Enum
			if (type.GetTypeInfo().IsEnum)
			{
				field = new EnumField(this, type);
			}

			//Type, ignore this since we can't know if type means Person (as in a serializable object) or typeof(Person) as a type which child types you would choose from
			//else if (type.Equals(typeof(Type)))
			//{
			//	field = new TypeField();
			//}

			//Bool
			else if (type.Equals(typeof(bool)))
			{
				field = new BoolField(this);
			}

			//DateTime
			else if (type.Equals(typeof(DateTime)))
			{
				//field = new DateTimeField();
				field = new DateTimeField(this);
			}

			//TimeSpan
			else if (type.Equals(typeof(TimeSpan)))
			{
				field = new TimeSpanField(this);
			}

			//Numeric
			else if (type.IsNumeric())
			{
				if (type.IsIntegral())
				{
					field = new IntegerField(this);
				}
				else
				{
					field = new DecimalField(this);
				}
			}

			//String serializable
			else if (type.GetTypeInfo().ImplementedInterfaces.Contains(typeof(Data.IStringSerializable)))
			{
				field = new StringSerializableField(this, type);
			}

			//XML
			else if (type.GetTypeInfo().ImplementedInterfaces.Contains(typeof(System.Xml.Serialization.IXmlSerializable)))
			{
				field = new XmlSerializableField(this, type);
			}

			//Uri
			else if (type.Equals(typeof(Uri)))
			{
				field = new StringField(this);
			}

			//String
			else if (type.Equals(typeof(string)))
			{
				field = new StringField(this);
			}

			//byte[]
			else if (type.Equals(typeof(byte[])))
			{
				field = new BinaryField(this);
			}

			//otherwise just create a json textbox
			else
			{
				field = new JsonField(this, type);
			}

			//return
			return field;
		}

		/// <summary>
		/// Creates a field for a DataMember
		/// <para xml:lang="es">
		/// Crea un campo para un DataMember
		/// </para>
		/// </summary>
		public virtual FormField CreateFieldFor(MemberInfo member)
		{
			//if there's no values defined, exit
			if (member == null) throw new ArgumentNullException(nameof(member));

			//field
			FormField field;
			Type returnType = Data.MemberExpression.GetReturnType(member);

			//String
			if (returnType.Equals(typeof(string)))
			{
				if (member.Name.ToLower() == "password" || member.Name.ToLower() == "pwd")
				{
					field = new PasswordField(this);
				}
				else
				{
					field = new StringField(this);

					//set max lenght, if defined
					int maxLenght = (int) StringLengthValidator.GetMaxLength(member);

					if (maxLenght == 0)
					{
						field.TableWide = true;
					}
					else
					{
						((StringField) field).MaxLenght = maxLenght;
					}

					//set regular expression validation, if defined
					var regex = member.CustomAttributes.Where(att => att.AttributeType.Equals(typeof(RegexValidator))).SingleOrDefault();

					if (regex != null)
					{
						((StringField) field).RegularExpression = (string) regex.ConstructorArguments[0].Value;
					}
				}
			}

			//otherwise delegate to the static method to create the field from the return type
			else
			{
				field = CreateFieldFor(returnType);
			}

			field.Name = member.Name;
			field.Required = RequiredValidator.IsRequired(member);
			field.CaptionControl.Text = Translator.Translate(member);
			//if (member.Column.IsPrimaryKey) field.SortOrder = 0;

			return field;
		}

		/// <summary>
		/// Creates fields for every Member that is mapped on a persistent object
		/// <para xml:lang="es">
		/// Agrega campos para cada miembro que se asigna en un objeto persistente
		/// </para>
		/// </summary>
		/// <param name="instance">
		/// Object which values will be copied to the form
		/// <para xml:lang="es">
		/// Objeto que se van a copiar al formulario
		/// </para>
		/// </param>
		public virtual IEnumerable<FormField> CreateFieldsFor(object instance)
		{
			//validate arguments
			if (instance == null) throw new ArgumentNullException(nameof(instance));
			Type type = instance.GetType();

			//create fields
			foreach (MemberInfo member in type.GetAllMemberInfos())
			{
				FormField field = CreateFieldFor(member);
				field.Value = Data.MemberExpression.GetValue(member, instance);

				yield return field;
			}
		}

		/// <summary>
		/// Creates fiels for all the parameters that a method needs to be executed
		/// </summary>
		public virtual IEnumerable<FormField> CreateFieldsFor(MethodInfo method)
		{
			uint order = 0;

			//add a field for each parameter
			foreach (ParameterInfo param in method.GetParameters())
			{
				FormField field;

				field = CreateFieldFor(param.ParameterType);

				//set common values
				field.Name = param.Name;
				field.Required = !param.IsOptional && !param.IsOut;
				//field.CaptionControl.Text = new System.Resources.ResourceManager(method.DeclaringType).GetString(method.GetFriendlyFullName().Replace('.', '_') + '_' + param.Name);
				field.CaptionControl.Text = param.Name;
				field.SortOrder = order++;

				yield return field;
			}
		}

		#endregion
	}
}