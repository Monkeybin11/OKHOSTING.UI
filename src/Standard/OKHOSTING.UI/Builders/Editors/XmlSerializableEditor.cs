using System;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// A field for Xml values.
	/// <para xml:lang="es">
	/// Un campo para valores Xml.
	/// </para>
	/// </summary>
	public class XmlSerializableEditor : TextAreaEditor<object>
	{
		public readonly Type SerializableType;

		public XmlSerializableEditor(Type serializableType)
		{
			if (serializableType == null)
			{
				throw new ArgumentNullException(nameof(serializableType));
			}

			SerializableType = serializableType;
		}
		
		/// <summary>
		/// Actually gets the value out of the editor Control
		/// </summary>
		/// <returns></returns>
		protected override object GetValue()
		{
			return Data.Convert.FromXml(Control.Value, SerializableType);
		}

		/// <summary>
		/// Sets the editor control with the given value
		/// </summary>
		protected override void SetValue(object value)
		{
			Control.Value = Data.Convert.ToXml(value);
		}

		/// <summary>
		/// Gets the is valid.
		/// <para xml:lang="es">
		/// Determina si el valor es valido. 
		/// </para>
		/// </summary>
		/// <value>The is valid.</value>
		public override bool IsValid
		{
			get
			{
				try
				{
					var instance = Value;
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