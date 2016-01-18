using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A DropDownList for selecting DataObjects
	/// </summary>
	[Serializable]
	public class DataObjectDropDownField : FormField
	{
		/// <summary>
		/// Control that parses the value to web
		/// </summary>
		protected new DropDownList ValueControl
		{
			get
			{
				return (DropDownList) base.ValueControl;
			}
			set
			{
				base.ValueControl = value;
			}
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			DropDownList ddl;

			ddl = new DropDownList(ValueType);
			ddl.Required = !this.Required;
			ddl.DataSource = DataBase.Current.Select(ValueType);
			ddl.DataSource.Sort();
			ddl.DataBind();

			//set ValueControl
			ValueControl = ddl;

			//set default selected value, if applicable
			if (Required && ddl.Items.Count > 0)
			{
				Value = ddl.Selected = ddl.DataSource[0];
			}
		}

		/// <summary>
		/// Retrieves values selected by the user and set's the value to the ValueControl
		/// </summary>
		internal override void RetrieveUserInput()
		{
			ValueControl.Selected = TypeConverter.ToDataObject(ValueControlPostValue);
		}

		/// <summary>
		/// Creates a new instance
		/// </summary>
		public DataObjectDropDownField()
		{
		}

		/// <summary>
		/// Creates a new instance based on serialization info
		/// </summary>
		public DataObjectDropDownField(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext ctxt)
			: base(info, ctxt)
		{
		}

		/// <summary>
		/// Assings the Value to the valuecontrol input
		/// </summary>
		internal override void ValueToControl()
		{
			ValueControl.Selected = (DataObject) Value;
		}

		/// <summary>
		/// Retrieves the user input from the value control and assigns it to Value
		/// </summary>
		internal override void ControlToValue()
		{
			Value = ValueControl.Selected;
		}
	}
}