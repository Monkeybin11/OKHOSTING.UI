using System;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A field for IStringSerialized values
	/// </summary>
	[Serializable]
	public class StringSerializableField : TextBoxField
	{
		/// <summary>
		/// Creates a new instance
		/// </summary>
		public StringSerializableField()
		{
			this.TextMode = System.Web.UI.WebControls.TextBoxMode.MultiLine;
			this.TableWide = true;
			ValueType = typeof(string);
		}

		/// <summary>
		/// Creates a new instance based on serialization info
		/// </summary>
		public StringSerializableField(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext ctxt)
			: base(info, ctxt)
		{
		}

		/// <summary>
		/// Assings the Value to the valuecontrol input
		/// </summary>
		internal override void ValueToControl()
		{
			if (Value == null)
			{
				ValueControl.Text = null;
			}
			else if (Value is IStringSerializable)
			{
				ValueControl.Text = TypeConverter.SerializeToString((IStringSerializable)Value);
			}
			else
			{
				ValueControl.Text = TypeConverter.SerializeToString(Value);
			}

			//set textmode again, just in case
			ValueControl.TextMode = this.TextMode;
		}
	}
}
