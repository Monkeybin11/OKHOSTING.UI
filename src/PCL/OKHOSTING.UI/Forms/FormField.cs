using OKHOSTING.Core;
using OKHOSTING.Data.Validation;
using OKHOSTING.UI.Controls;
using System;
using System.Linq;
using System.Reflection;

namespace OKHOSTING.UI.Forms
{
	/// <summary>
	/// An item that will be displayed in the dataform
	/// <para xml:lang="es">Un elemento que se muestra en el dataform</para>
	/// </summary>
	public abstract class FormField: IDisposable
	{
		/// <summary>
		/// Initializes a new instance of the FormField class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase FormField
		/// </para>
		/// </summary>
		public FormField()
		{
			CaptionControl = Platform.Current.Create<ILabel>();
		}

		private IControl _ValueControl;

		#region Public properties

		//abstract

		/// <summary>
		/// The type of value that this field will show/accept
		/// <para xml:lang="es">El tipo de valor que este campo mostrara/aceptara.</para>
		/// </summary>
		public abstract Type ValueType { get; }

		/// <summary>
		/// Value selected by the user
		/// <para xml:lang="es">El valor seleccionado por el usuario.</para>
		/// </summary>
		public abstract object Value { get; set; }

		//non abstract

		/// <summary>
		/// Id or programing-friendly name that you give to this field.
		/// A single form should not contain 2 fields with the same field
		/// <para xml:lang="es">
		/// El Id o el nombre que tu le das a este campo.
		/// En una misma instancia no deve contener dos campos con el mismo nombre.
		/// </para>
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// Label that shows the caption or name for this field
		/// </summary>
		public virtual ILabel CaptionControl { get; protected set; }

		/// <summary>
		/// Control that parses the value to web
		/// <para xml:lang="es">El control que analiza el valor de web.</para>
		/// </summary>
		public virtual IControl ValueControl
		{
			get
			{
				if (_ValueControl == null)
				{
					CreateValueControl();
				}

				return _ValueControl;
			}
			protected set
			{
				_ValueControl = value;
			}
		}

		/// <summary>
		/// If set to true, this field must be set to 100% of the form's width and use a complete row for itself
		/// <para xml:lang="es">
		/// Si es verdadero, este campo deve estar ajustado al 100% del ancho del formulario y el uso de una fila, completada por si misma.
		/// </para>
		/// </summary>
		public virtual bool TableWide { get; set; }

		/// <summary>
		/// Container form
		/// <para xml:lang="es">Contenido del form.</para>
		/// </summary>
		public virtual Form Container { get; set; }

		/// <summary>
		/// Category of the field. Used for grouping fields in the DataForm
		/// <para xml:lang="es">
		/// Categoria del campo. Se utiliza para agrupar campos en el DataForm.
		/// </para>
		/// </summary>
		public virtual string Category { get; set; }

		/// <summary>
		/// Gets or sets a value that defines the order in which fields appear on the DataForm
		/// <para xml:lang="es">
		/// Obtiene o establece un valor que define el orden en el que apareceran los campos en el DataForm.
		/// </para>
		/// </summary>
		public virtual uint SortOrder { get; set; }

		/// <summary>
		/// If true, the current field cannot be left empty, validated in javascript
		/// <para xml:lang="es">
		/// Si es verdadero, el campo actual no puede dejarse vacío, la validacion es en javascript.
		/// </para>
		/// </summary>
		public virtual bool Required { get; set; }

		/// <summary>
		/// Indicates wether all information written by the user has been succesfully validated or not
		/// <para xml:lang="es">
		/// Indica si toda la informacion escrita por el usuario se ha validado o no con exito.
		/// </para>
		/// </summary>
		public virtual bool IsValid
		{
			get
			{
				if (Required)
				{
					return new RequiredValidator().Validate(Value) == null;
				}
				else
				{
					return true;
				}
			}
		}

		#endregion

		#region Methods

		//abstract

		/// <summary>
		/// Creates the controls for displaying the field
		/// <para xml:lang="es">
		/// Crea los controles para visualizar el campo.
		/// </para>
		/// </summary>
		protected abstract void CreateValueControl();

		//non abstract

		/// <summary>
		/// Returns the field's Id
		/// <para xml:lang="es">Devuelve el Id del campo</para>
		/// </summary>
		/// <returns>The Id of field.
		/// <para xml:lang="es">El Id del campo.</para>
		/// </returns>
		public override string ToString()
		{
			if (CaptionControl == null)
			{
				return null;
			}
			else
			{
				return CaptionControl.Text;
			}
		}

		/// <summary>
		/// Releases all resource used by the FormField object.
		/// <para xml:lang="es">Libera todos los recursos utilizados por el objeto de campo de formulario.</para>
		/// </summary>
		/// <remarks>Call Dispose when you are finished using the FormField.
		/// The Dispose method leaves the FormField in an unusable
		/// state. After calling Dispose, you must release all references to the
		/// FormField so the garbage collector can reclaim the memory that the
		/// FormField was occupying.
		/// <para xml:lang="es">
		/// Llame a Dispose cuando termine de usar el FormField.
		/// El método Dispose deja el FormField en un estado inutilizable.
		/// Después de llamar a Dispose, debe liberar todas las referencias al
		/// FormField por lo que el recolector de basura puede reclamar la memoria que el
		/// FormField ocupaba.
		/// </para>
		/// </remarks>
		public void Dispose()
		{
			if (CaptionControl != null)
			{
				CaptionControl.Dispose();
			}

			if (ValueControl != null)
			{
				ValueControl.Dispose();
			}
		}

		#endregion

		#region Static

		/// <summary>
		/// Creates a field that will contain a value of a specific type
		/// <para xml:lang="es">
		/// Crea un campo que contendra un valor de un tipo especifico.
		/// </para>
		/// </summary>
		public static FormField CreateFieldFrom(Type type)
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
				field = new EnumField(type);
			}

			//Type, ignore this since we can't know if type means Person (as in a serializable object) or typeof(Person) as a type which child types you would choose from
			//else if (type.Equals(typeof(Type)))
			//{
			//	field = new TypeField();
			//}

			//Bool
			else if (type.Equals(typeof(bool)))
			{
				field = new BoolField();
			}

			//DateTime
			else if (type.Equals(typeof(DateTime)))
			{
				//field = new DateTimeField();
				field = new DateTimeField();
			}

			//TimeSpan
			else if (type.Equals(typeof(TimeSpan)))
			{
				field = new TimeSpanField();
			}

			//Numeric
			else if (type.IsNumeric())
			{
				if (type.IsIntegral())
				{
					field = new IntegerField();
				}
				else
				{
					field = new DecimalField();
				}
			}

			//String serializable
			else if (type.GetTypeInfo().ImplementedInterfaces.Contains(typeof(Data.IStringSerializable)))
			{
				field = new StringSerializableField(type);
			}

			//XML
			else if (type.GetTypeInfo().ImplementedInterfaces.Contains(typeof(System.Xml.Serialization.IXmlSerializable)))
			{
				field = new XmlSerializableField(type);
			}

			//String
			else if (type.Equals(typeof(string)))
			{
				field = new StringField();
			}

			//byte[]
			else if (type.Equals(typeof(byte[])))
			{
				field = new BinaryField();
			}

			//otherwise just create a textbox
			else
			{
				field = new StringField();
			}

			//return
			return field;
		}

		#endregion
	}
}