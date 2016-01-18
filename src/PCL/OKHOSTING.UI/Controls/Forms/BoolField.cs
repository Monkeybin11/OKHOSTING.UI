using System;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A field for boolean values
	/// </summary>
	public class BoolField : FormField
	{
		public override object Value
		{
			get
			{
				if (Required)
				{
					return ((ICheckBox) ValueControl).Value;
				}
				else
				{
					string val = ((IListPicker) ValueControl).Value;

					if (string.IsNullOrWhiteSpace(val))
					{
						return null;
					}
					else
					{
						return bool.Parse(val);
					}
				}
			}
			set
			{
				if (value == null && !Required)
				{
					((IListPicker) ValueControl).Value = "-";
				}
				else
				{
					((IListPicker) ValueControl).Value = value.ToString();
				}
			}
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			if (Required)
			{
				ValueControl = Platform.Current.Create<ICheckBox>();
			}
			else
			{
				ValueControl = Platform.Current.Create<ICheckBox>();
			}
		}

		/// <summary>
		/// Creates a new instance 
		/// </summary>
		public BoolField(): base()
		{
			ValueType = typeof(bool);
		}
	}
}