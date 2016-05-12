using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A form field that uses an autocomplete for data input
	/// </summary>
	public class AutocompleteField : FormField
	{
		public override object Value
		{
			get
			{
				return ValueControl.Value;
			}
			set
			{
				if(value == null)
				{
					ValueControl.Value = null;
				}
				else
				{
					ValueControl.Value = value.ToString();
				}
			}
		}

		/// <summary>
		/// Control that parses the value to web
		/// </summary>
		public new IAutocomplete ValueControl
		{
			get
			{
				return (IAutocomplete) base.ValueControl;
			}
			protected set
			{
				base.ValueControl = value;
			}
		}

		public override Type ValueType
		{
			get
			{
				return typeof(string);
			}
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			ValueControl = Platform.Current.Create<IAutocomplete>();
		}
	}
}