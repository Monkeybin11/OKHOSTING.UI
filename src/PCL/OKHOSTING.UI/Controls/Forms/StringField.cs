using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// Field for string values
	/// </summary>
	[Serializable]
	public class StringField : TextBoxField
	{
		/// <summary>
		/// A regular expression pattern used for regex validation.
		/// If set to null, no regex validation is done
		/// </summary>
		public string RegularExpression = null;
		
		/// <summary>
		/// Creates a new instance
		/// </summary>
		public StringField()
		{
			ValueType = typeof(string);
		}

		/// <summary>
		/// Creates a new instance based on serialization info
		/// </summary>
		public StringField(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext ctxt) : base(info, ctxt)
		{
			RegularExpression = info.GetString("RegularExpression");
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			//create TextBox from base
			base.CreateValueControl();

			//if required and  control is a textbox, add validator
			if (!string.IsNullOrWhiteSpace(RegularExpression))
			{
				RegularExpressionValidator validator;

				validator = new RegularExpressionValidator();
				validator.ValidationExpression = RegularExpression;
				validator.ControlToValidate = ValueControlId;
				validator.ID = ValueControlId + "_RegularExpressionValidator";
				validator.ErrorMessage = this.Text + " - " + OKHOSTING.Softosis.Core.Globalization.Translator.Current["Validation.Invalid value"];
				validator.Text = "*";
				validator.ValidationGroup = this.Container.ValidationGroup;

				AditionalControls.Add(validator);
			}
		}

		/// <summary>
		/// Serializes the current field
		/// </summary>
		public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			base.GetObjectData(info, ctxt);
			info.AddValue("RegularExpression", this.RegularExpression);
		}
	}
}