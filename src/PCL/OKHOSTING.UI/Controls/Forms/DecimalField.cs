using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A field for decimal values
	/// </summary>
	[Serializable]
	public class DecimalField : TextBoxField
	{
		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			//create controls form base class
			base.CreateValueControl();

			//add integral validator
			CompareValidator validator;
			validator = new CompareValidator();
			validator.Operator = ValidationCompareOperator.DataTypeCheck;
			validator.Type = ValidationDataType.Double;
			validator.ControlToValidate = ValueControlId;
			validator.ErrorMessage = this.Text + " - " + OKHOSTING.Softosis.Core.Globalization.Translator.Current["Validation.Invalid decimal number"];
			validator.Text = "*";
			validator.ValidationGroup = this.Container.ValidationGroup;
			validator.ID = ValueControlId + "_CompareValidator";

			AditionalControls.Add(validator);
		}

		/// <summary>
		/// Creates a new instance
		/// </summary>
		public DecimalField()
		{
			ValueType = typeof(decimal);
		}
	
		/// <summary>
		/// Creates a new instance based on serialization info
		/// </summary>
		public DecimalField(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext ctxt)
			: base(info, ctxt)
		{
		}

		/// <summary>
		/// Retrieves the user input from the value control and assigns it to Value
		/// </summary>
		internal override void ControlToValue()
		{
			decimal result;

			if (decimal.TryParse(ValueControl.Text, out result))
				Value = result;
			else
				Value = null;
		}
	}
}
