using System;
using System.Xml.Serialization;

namespace OKHOSTING.UI.Controllers.Forms
{
	/// <summary>
	/// A field for Xml values.
	/// <para xml:lang="es">
	/// Un campo para valores Xml.
	/// </para>
	/// </summary>
	public class JsonField : StringField
	{
		/// <summary>
		/// The type of the xml serializable.
		/// <para xml:lang="es">
		/// El tipo del xml serializable.
		/// </para>
		/// </summary>
		public readonly Type SerializableType;

		/// <summary>
		/// Initializes a new instance of the XmlSerializableField class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase XmlSerializableField.
		/// </para>
		/// </summary>
		/// <param name="xmlSerializableType">Xml serializable type.</param>
		public JsonField(Form form, Type serializableType) : base(form)
		{
			if (form == null)
			{
				throw new ArgumentNullException(nameof(form));
			}

			if (serializableType == null)
			{
				throw new ArgumentNullException(nameof(serializableType));
			}

			SerializableType = serializableType;
		}

		/// <summary>
		/// Gets or sets the value.
		/// <para xml:lang="es">
		/// Obtiene o establece el valor del campo.
		/// </para>
		/// </summary>
		public override object Value
		{
			get
			{
				return Newtonsoft.Json.JsonConvert.DeserializeObject(ValueControl.Value, SerializableType);
			}
			set
			{
				ValueControl.Value = Newtonsoft.Json.JsonConvert.SerializeObject(value);
			}
		}

		/// <summary>
		/// Gets the type of the value.
		/// <para xml:lang="es">
		/// Obtiene el tipo del valor.
		/// </para>
		/// </summary>
		public override Type ValueType
		{
			get
			{
				return SerializableType;
			}
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
					IXmlSerializable instance = (IXmlSerializable) Value;
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
