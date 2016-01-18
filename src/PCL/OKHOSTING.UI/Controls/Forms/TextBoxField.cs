using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// Base class for all fields that uses a single TextBox as ValueControl
	/// </summary>
	[Serializable]
	public abstract class TextBoxField : FormField
	{
		/// <summary>
		/// Maximum lenght for the TextBox
		/// </summary>
		public int MaxLenght = NullValues.Int32;

		/// <summary>
		/// TextMode for the field
		/// </summary>
		public TextBoxMode TextMode = TextBoxMode.SingleLine;

		/// <summary>
		/// Control that parses the value to web
		/// </summary>
		protected new TextBox ValueControl
		{
			get
			{
				return (TextBox) base.ValueControl;
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
			//create a sinple TextBox
			ValueControl = new TextBox();

			//set maxlenght if it is not null
			if (!NullValues.IsNull(MaxLenght)) ValueControl.MaxLength = this.MaxLenght;

			//set to multiline if this field is table wide
			if (this.TableWide) this.TextMode = TextBoxMode.MultiLine;
			
			//set textmode
			ValueControl.TextMode = this.TextMode;

			//if required and  control is a textbox, add validator
			if (Required)
			{
				RequiredFieldValidator validator = new RequiredFieldValidator();
				validator.ControlToValidate = ValueControlId;
				validator.ID = ValueControlId + "_RequiredFieldValidator";
				validator.ErrorMessage = this.Text + " - " + OKHOSTING.Softosis.Core.Globalization.Translator.Current["Validation.Required field"];
				validator.Text = "*";
				validator.ValidationGroup = this.Container.ValidationGroup;

				AditionalControls.Add(validator);
			}
		}

		/// <summary>
		/// Retrieves values selected by the user and set's the value to the ValueControl
		/// </summary>
		internal override void RetrieveUserInput()
		{
			ValueControl.Text = ValueControlPostValue;
		}

		/// <summary>
		/// Creates a new instance
		/// </summary>
		public TextBoxField()
		{
		}

		/// <summary>
		/// Creates a new instance based on serialization info
		/// </summary>
		public TextBoxField(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt)
		{
			MaxLenght = info.GetInt32("MaxLenght");
			TextMode = (TextBoxMode) info.GetValue("TextMode", typeof(TextBoxMode));
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
			else
			{
				ValueControl.Text = TypeConverter.ToString(Value);
			}

			//set textmode again, just in case
			ValueControl.TextMode = this.TextMode;
		}

		/// <summary>
		/// Retrieves the user input from the value control and assigns it to Value
		/// </summary>
		internal override void ControlToValue()
		{
			if (string.IsNullOrWhiteSpace(ValueControl.Text))
				Value = null;
			else
				Value = TypeConverter.ChangeType(ValueControl.Text, ValueType);
		}

		/// <summary>
		/// Serializes the current field
		/// </summary>
		public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			base.GetObjectData(info, ctxt);
			info.AddValue("MaxLenght", this.MaxLenght);
			info.AddValue("TextMode", this.TextMode);
		}
	}
}