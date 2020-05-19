using OKHOSTING.Data;
using System;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// A field for IStringSerialized values
	/// <para xml:lang="es">
	/// Un campo para valores de cadena serializados.
	/// </para>
	/// </summary>
	public class StringSerializableEditor : TextBoxEditor<IStringSerializable>
	{
		public readonly Type SerializableType;

		public StringSerializableEditor(Type serializableType)
		{
			if (serializableType == null)
			{
				throw new ArgumentNullException(nameof(serializableType));
			}

			SerializableType = serializableType;
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
					IStringSerializable instance = Value;
				}
				catch
				{
					return false;
				}

				return base.IsValid;
			}
		}

		/// <summary>
		/// Actually gets the value out of the editor Control
		/// </summary>
		/// <returns></returns>
		protected override object GetValue()
		{
			return Data.Convert.ToIStringSerializable(Control.Value, SerializableType);
		}

		/// <summary>
		/// Sets the editor control with the given value
		/// </summary>
		protected override void SetValue(object value)
		{
			if (value == null)
			{
				Control.Value = null;
			}
			else
			{
				Control.Value = Data.Convert.ToString(value);
			}
		}
	}
}
