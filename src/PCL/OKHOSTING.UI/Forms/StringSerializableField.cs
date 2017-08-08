using OKHOSTING.Data;
using System;
using System.Linq;
using System.Reflection;

namespace OKHOSTING.UI.Forms
{
	/// <summary>
	/// A field for IStringSerialized values
	/// <para xml:lang="es">
	/// Un campo para valores de cadena serializados.
	/// </para>
	/// </summary>
	public class StringSerializableField : StringField
	{
		/// <summary>
		/// The type of the string serializable.
		/// <para xml:lang="es">El tipo de la serialización de la cadena.</para>
		/// </summary>
		public readonly Type StringSerializableType;

		/// <summary>
		/// Initializes a new instance of the StringSerializableField class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase StringSerializableField.</para>
		/// </summary>
		/// <param name="stringSerializableType">String serializable type.</param>
		public StringSerializableField(Type stringSerializableType)
		{
			if (stringSerializableType == null)
			{
				throw new ArgumentNullException("stringSerializableType");
			}

			if (!stringSerializableType.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IStringSerializable)))
			{
				throw new ArgumentOutOfRangeException("stringSerializableType", "Type does not implement IStringSerializable interface");
			}

			StringSerializableType = stringSerializableType;
		}

		/// <summary>
		/// Gets or sets the value.
		/// <para xml:lang="es">Obtiene o establece el valor a serializar.</para>
		/// </summary>
		/// <value>The value.</value>
		public override object Value
		{
			get
			{
				return Data.Convert.ToIStringSerializable(ValueControl.Value, StringSerializableType);
			}
			set
			{
				if (value == null)
				{
					ValueControl.Value = null;
				}
				else
				{
					ValueControl.Value = Data.Convert.ToString((IStringSerializable) value);
				}
			}
		}

		/// <summary>
		/// Gets the type of the value.
		/// <para xml:lang="es">Obtien el tipo del valor.</para>
		/// </summary>
		public override Type ValueType
		{
			get
			{
				return StringSerializableType;
			}
		}

		/// <summary>
		/// Gets the is valid.
		/// <para xml:lang="es">Determina si el valor es valido.</para>
		/// </summary>
		public override bool IsValid
		{
			get
			{
				try
				{
					IStringSerializable instance = (IStringSerializable) Value;
				}
				catch
				{
					return false;
				}

				return base.IsValid;
			}
		}
	}
}
