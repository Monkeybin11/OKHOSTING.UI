using System;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A field for decimal values
	/// </summary>
	public class DecimalField : TextBoxField
	{
		public override object Value
		{
			get
			{
				if (string.IsNullOrWhiteSpace(ValueControl.Value))
				{
					return 0;
				}
				else
				{
					return int.Parse(ValueControl.Value);
				}
			}
			set
			{
				ValueControl.Value = ((int)value).ToString();
			}
		}

		public override Type ValueType
		{
			get
			{
				return typeof(decimal);
			}
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			//create date texbox from base
			base.CreateValueControl();

			ValueControl.InputType = ITextBoxInputType.Number;
		}

		public override bool IsValid
		{
			get
			{
				decimal test;
				return base.IsValid && decimal.TryParse(ValueControl.Value, out test);
			}
		}
	}
}