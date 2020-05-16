using System;
using System.Linq;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// Field for selecting a DataType
	/// <para xml:lang="es">
	/// Un campo para seleccion de tipo de datos.
	/// </para>
	/// </summary>
	public class TypeEditor : ListPickerEditor<Type>
	{
		/// <summary>
		/// Initializes a new instance of the TypeField class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase TypeField.
		/// </para>
		/// </summary>
		/// <param name="parent">Parent.</param>
		public TypeEditor(Type parent)
		{
			if (parent == null)
			{ 
				throw new ArgumentNullException("parent");
			}

			Parent = parent;

			//add Parent first
			Control.Items.Add(Parent.FullName);

			//add all subclasses
			foreach (Type type in Core.AssemblyExtensions.GetAllAssemblies().SelectMany(a => a.DefinedTypes).Where(t => t.IsSubclassOf(Parent)))
			{
				Control.Items.Add(type.FullName);
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
		/// Actually gets the value out of the editor Control
		/// </summary>
		/// <returns></returns>
		protected override object GetValue()
		{
			if (Control.Value == Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue)
			{
				return null;
			}
			else
			{
				return Type.GetType(Control.Value);
			}
		}

		/// <summary>
		/// Sets the editor control with the given value
		/// </summary>
		protected override void SetValue(object value)
		{
			if (value == null && !Required)
			{
				Control.Value = Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue;
			}
			else
			{
				Control.Value = ((Type) value).FullName;
			}
		}
	}
}