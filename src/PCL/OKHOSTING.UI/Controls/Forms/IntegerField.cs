using System;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A field for integer values
	/// </summary>
	public class IntegerField : TextBoxField
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
				ValueControl.Value = ((int) value).ToString();
			}
		}

		public override Type ValueType
		{
			get
			{
				return typeof(int);
			}
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			base.CreateValueControl();
			ValueControl.InputType = ITextBoxInputType.Number;
		}

		public override bool IsValid
		{
			get
			{
				int test;
				return base.IsValid && int.TryParse(ValueControl.Value, out test);
			}
		}
	}
}
