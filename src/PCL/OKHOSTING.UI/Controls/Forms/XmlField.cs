using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A field for Xml values
	/// </summary>
	[Serializable]
	public class XmlField : TextBoxField
	{
		/// <summary>
		/// Creates a new instance
		/// </summary>
		public XmlField()
		{
			this.TextMode = System.Web.UI.WebControls.TextBoxMode.MultiLine;
			this.TableWide = true;
			ValueType = typeof(string);
		}

		/// <summary>
		/// Creates a new instance based on serialization info
		/// </summary>
		public XmlField(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext ctxt) : base(info, ctxt)
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
			else if (Value is IXmlSerializable)
			{
				ValueControl.Text = TypeConverter.SerializeToString((IXmlSerializable) Value);
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
