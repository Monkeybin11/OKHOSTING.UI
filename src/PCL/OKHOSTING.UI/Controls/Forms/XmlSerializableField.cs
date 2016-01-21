using System;
using System.Reflection;
using System.Linq;
using System.Xml.Serialization;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A field for Xml values
	/// </summary>
	public class XmlSerializableField : StringField
	{
		public readonly Type XmlSerializableType;

		public XmlSerializableField(Type xmlSerializableType)
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

		public override object Value
		{
			get
			{
				return Data.Convert.ToIXmlSerializable(ValueControl.Value, XmlSerializableType);
			}
			set
			{
				ValueControl.Value = Data.Convert.ToString((IXmlSerializable) value);
			}
		}

		public override Type ValueType
		{
			get
			{
				return XmlSerializableType;
			}
		}

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
