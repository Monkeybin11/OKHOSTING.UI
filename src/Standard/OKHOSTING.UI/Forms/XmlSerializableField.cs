using System;
using System.Reflection;
using System.Linq;
using System.Xml.Serialization;

namespace OKHOSTING.UI.Forms
{
	/// <summary>
	/// A field for Xml values.
	/// <para xml:lang="es">
	/// Un campo para valores Xml.
	/// </para>
	/// </summary>
	public class XmlSerializableField : StringField
	{
		/// <summary>
		/// The type of the xml serializable.
		/// <para xml:lang="es">
		/// El tipo del xml serializable.
		/// </para>
		/// </summary>
		public readonly Type XmlSerializableType;

		/// <summary>
		/// Initializes a new instance of the XmlSerializableField class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase XmlSerializableField.
		/// </para>
		/// </summary>
		/// <param name="xmlSerializableType">Xml serializable type.</param>
		public XmlSerializableField(Form form, Type xmlSerializableType) : base(form)
		{
			if (xmlSerializableType == null)
			{
				throw new ArgumentNullException("xmlSerializableType");
			}

			if (!xmlSerializableType.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IXmlSerializable)))
			{
				throw new ArgumentOutOfRangeException("xmlSerializableType", "Type does not implement IXmlSerializable interface");
			}

			XmlSerializableType = xmlSerializableType;
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
				return Data.Convert.FromXml(ValueControl.Value);
			}
			set
			{
				ValueControl.Value = Data.Convert.ToXml((IXmlSerializable) value);
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
				return XmlSerializableType;
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
