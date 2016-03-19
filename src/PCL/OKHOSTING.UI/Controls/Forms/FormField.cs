using OKHOSTING.Core;
using OKHOSTING.Data.Validation;
using System;
using System.Linq;
using System.Reflection;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// An item that will be displayed in the dataform
	/// </summary>
	public abstract class FormField: IDisposable
	{
		public FormField()
		{
			CaptionControl = Platform.Current.CreateControl<ILabel>();
		}

		private IControl _ValueControl;

		#region Public properties

		//abstract

		/// <summary>
		/// The type of value that this field will show/accept
		/// </summary>
		public abstract Type ValueType { get; }

		/// <summary>
		/// Value selected by the user
		/// </summary>
		public abstract object Value { get; set; }

		//non abstract

		/// <summary>
		/// Id or programing-friendly name that you give to this field.
		/// A single form should not contain 2 fields with the same field
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// Label that shows the caption or name for this field
		/// </summary>
		public virtual ILabel CaptionControl { get; protected set; }

		/// <summary>
		/// Control that parses the value to web
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
		/// </summary>
		public virtual bool TableWide { get; set; }

		/// <summary>
		/// Container form
		/// </summary>
		public virtual Form Container { get; set; }

		/// <summary>
		/// Category of the field. Used for grouping fields in the DataForm
		/// </summary>
		public virtual string Category { get; set; }

		/// <summary>
		/// Gets or sets a value that defines the order in which fields appear on the DataForm
		/// </summary>
		public virtual uint SortOrder { get; set; }

		/// <summary>
		/// If true, the current field cannot be left empty, validated in javascript
		/// </summary>
		public virtual bool Required { get; set; }

		#endregion

		#region Methods

		//abstract

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected abstract void CreateValueControl();

		//non abstract

		/// <summary>
		/// Indicates wether all information written by the user has been succesfully validated or not
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

		/// <summary>
		/// Returns the field's Id
		/// </summary>
		/// <returns></returns>
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
		/// </summary>
		public static FormField CreateFieldFrom(Type type)
		{
			//validate arguments
			if (type == null) throw new ArgumentNullException("type");

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
				field = new DateTimeField();
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