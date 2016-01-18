using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// Base class for all fields that uses a single TextBox as ValueControl
	/// </summary>
	public abstract class DropDownListField : FormField
	{
		/// <summary>
		/// Control that parses the value to web
		/// </summary>
		public new IListPicker ValueControl
		{
			get
			{
				return (IListPicker) base.ValueControl;
			}
			protected set
			{
				base.ValueControl = value;
			}
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			ValueControl = Platform.Current.Create<IListPicker>();
			
			//Add null value to DropDwonList if not required
			if (!Required)
			{
				ValueControl.Items = new string[] { "-" }.Union(ValueControl.Items);
			}
		}
	}
}