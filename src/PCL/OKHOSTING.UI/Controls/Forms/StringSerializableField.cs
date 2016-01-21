using OKHOSTING.Data;
using System;
using System.Linq;
using System.Reflection;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A field for IStringSerialized values
	/// </summary>
	public class StringSerializableField : StringField
	{
		public readonly Type StringSerializableType;

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

		public override object Value
		{
			get
			{
				return Data.Convert.ToIStringSerializable(ValueControl.Value, StringSerializableType);
			}
			set
			{
				ValueControl.Value = Data.Convert.ToString((IStringSerializable) value);
			}
		}

		public override Type ValueType
		{
			get
			{
				return StringSerializableType;
			}
		}

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
