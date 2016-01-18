using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebDropDownList = System.Web.UI.WebControls.DropDownList;
using System.Web.UI.WebControls;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// Field for enum values
	/// </summary>
	[Serializable]
	public class EnumField : DropDownListField
	{
		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			ListItem item;
			System.Array array;
			string typeName;

			//create and init dropdownlist
			base.CreateValueControl();

			typeName = ValueType.FullName;
			array = System.Enum.GetValues(ValueType);

			//add every enum value
			foreach (System.Enum e in array)
			{
				item = new ListItem
					(
					OKHOSTING.Softosis.Core.Globalization.Translator.Current[e],
					e.ToString()
					);

				//add item
				ValueControl.Items.Add(item);
			}
		}

		/// <summary>
		/// Creates a new instance
		/// </summary>
		public EnumField()
		{
		}
	
		/// <summary>
		/// Creates a new instance based on serialization info
		/// </summary>
		public EnumField(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext ctxt)
			: base(info, ctxt)
		{
		}
	}
}