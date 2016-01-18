using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A read-only field
	/// </summary>
	[Serializable]
	public class ReadOnlyField : OKHOSTING.UI.Controls.Forms.FormField
	{
		/// <summary>
		/// Creates a read only value cell
		/// </summary>
		internal override void CreateValueControl()
		{
			ValueControl = new HiddenField();
			Label text = new Label();
			AditionalControls.Add(text);
		}

		/// <summary>
		/// Does nothing as this field is readonly
		/// </summary>
		internal override void RetrieveUserInput()
		{
			((HiddenField) ValueControl).Value = ValueControlPostValue;
			((Label)AditionalControls[0]).Text = ValueControlPostValue;
		}

		public override object Value
		{
			get
			{
				return ((HiddenField)ValueControl).Value;
			}
			set
			{
				if (!NullValues.IsNull(value))
				{
					((HiddenField)ValueControl).Value = value.ToString();
					((Label)AditionalControls[0]).Text = value.ToString();
				}
				else
				{
					((HiddenField)ValueControl).Value = null;
					((Label)AditionalControls[0]).Text = null;
				}
			}
		}

		/// <summary>
		/// Creates a new instance
		/// </summary>
		public ReadOnlyField()
		{
		}

		/// <summary>
		/// Creates a new instance based on serialization info
		/// </summary>
		public ReadOnlyField(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext ctxt)
			: base(info, ctxt)
		{
		}
	}
}
