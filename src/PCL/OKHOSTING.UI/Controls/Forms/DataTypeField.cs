using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebDropDownList = System.Web.UI.WebControls.DropDownList;
using System.Web.UI.WebControls;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// Field for selecting a DataType
	/// </summary>
	[Serializable]
	public class DataTypeField : DropDownListField
	{
		/// <summary>
		/// The DataType (and subclasses of it) that will be available as an option in the DropDownList.
		/// if set to null, all DataTypes will be available
		/// </summary>
		public DataType Parent;

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			ListItem item;
			List<DataType> dtypes;

			//create dropdown from base
			base.CreateValueControl();

			//get all DataTypes
			if (Parent == null)
			{
				dtypes = DataType.GetAllDataTypes();
			}
			//get only Parent and it's subclasses
			else
			{
				dtypes = new List<DataType>();
				dtypes.Add(Parent);
				dtypes.AddRange(Parent.GetSubClassDataTypesRecursive());
			}

			//Create an item for each loaded DataType
			foreach (DataType dtype in dtypes)
			{
				item = new ListItem
					(
					OKHOSTING.Softosis.Core.Globalization.Translator.Current[dtype],
					dtype.UniqueId
					);

				//Add item
				ValueControl.Items.Add(item);
			}
		}

		/// <summary>
		/// Creates a new instance
		/// </summary>
		public DataTypeField()
		{
			ValueType = typeof(DataType);
		}

		/// <summary>
		/// Creates a new instance based on serialization info
		/// </summary>
		public DataTypeField(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext ctxt) : base(info, ctxt)
		{
		}

		/// <summary>
		/// Assings the Value to the valuecontrol input
		/// </summary>
		internal override void ValueToControl()
		{
			if (Value == null && ValueControl.Items.Count > 0)
			{
				ValueControl.Items[0].Selected = true;
				return;
			}

			if (Value == null)
			{
				return;
			}
			
			ListItem item = ValueControl.Items.FindByValue(((DataType)Value).UniqueId);

			if (item != null)
			{
				ValueControl.ClearSelection();
				item.Selected = true;
			}
			else
			{
				throw new NullReferenceException("An Item with Value='" + ((DataType)Value).UniqueId + "' does not exist in the Items collection");
			}
		}

		/// <summary>
		/// Retrieves the user input from the value control and assigns it to Value
		/// </summary>
		internal override void ControlToValue()
		{
			if (!string.IsNullOrWhiteSpace(ValueControl.Text))
			{
				Value = DataType.Parse(ValueControl.Text);
			}
			else
			{
				Value = null;
			}
		}
	}
}