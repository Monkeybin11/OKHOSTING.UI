using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI.Forms
{
	/// <summary>
	/// Field for selecting a DataType
	/// <para xml:lang="es">
	/// Un campo para seleccion de tipo de datos.
	/// </para>
	/// </summary>
	public class TypeField : ListPickerField
	{
		/// <summary>
		/// Initializes a new instance of the TypeField class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase TypeField.
		/// </para>
		/// </summary>
		/// <param name="parent">Parent.</param>
		public TypeField(Form form, Type parent): base(form)
		{
			if (parent == null)
			{ 
				throw new ArgumentNullException("parent");
			}

			Parent = parent;
		}

		/// <summary>
		/// Gets the type of the value.
		/// <para xml:lang="es">Obtiene el tipo del valor.</para>
		/// </summary>
		/// <value>The type of the value.</value>
		public override Type ValueType
		{
			get
			{
				return typeof(Type);
			}
		}

		/// <summary>
		/// Gets or sets the value.
		/// <para xml:lang="es">Obtiene o establece el valor del tipo de campo.</para>
		/// </summary>
		public override object Value
		{
			get
			{
				if (ValueControl.Value == Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue)
				{
					return null;
				}
				else
				{
					return Type.GetType(ValueControl.Value);
				}
			}
			set
			{
				if (value == null && !Required)
				{
					ValueControl.Value = Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue;
				}
				else
				{
					ValueControl.Value = ((Type) value).FullName;
				}
			}
		}

		/// <summary>
		/// The DataType (and subclasses of it) that will be available as an option in the DropDownList.
		/// if set to null, all DataTypes will be available
		/// <para xml:lang="es">
		/// El tipo de datos (y subclases del mismo) que estará disponible como una opción en el DropDownList.
		/// Si se establece en nulo, todos los tipos de datos estarán disponibles
		/// </para>
		/// </summary>
		public readonly Type Parent;

		/// <summary>
		/// Creates the controls for displaying the field
		/// <para xml:lang="es">
		/// Crea los controles para visualizar el campo.
		/// </para>
		/// </summary>
		protected override void CreateValueControl()
		{
			//create listpicker and add empty value if not required
			base.CreateValueControl();

			//add Parent first
			ValueControl.Items.Add(Parent.FullName);

			//add all Parent subclasses
			foreach (Type type in Parent.GetTypeInfo().Assembly.DefinedTypes.Where(t => t.IsSubclassOf(Parent)).Select(t => t.AsType()))
			{
				ValueControl.Items.Add(type.FullName);
			}
		}
	}
}