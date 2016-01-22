using System;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// Field for enum values
	/// </summary>
	public class EnumField : ListPickerField
	{
		public EnumField(Type enumType)
		{
			EnumType = enumType;
		}

		public override object Value
		{
			get
			{
				if (ValueControl.Value == Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue)
				{
					return null;
				}
				else
				{
					return Enum.Parse(EnumType, ValueControl.Value);
				}
			}
			set
			{
				if (value == null && !Required)
				{
					ValueControl.Value = Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue;
				}
				else
				{
					ValueControl.Value = value.ToString();
				}
			}
		}

		protected readonly Type EnumType;

		public override Type ValueType
		{
			get
			{
				return EnumType;
			}
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			//create listpicker and add empty value if not required
			base.CreateValueControl();

			//add every enum value
			foreach (System.Enum e in System.Enum.GetValues(ValueType))
			{
				//add item
				ValueControl.Items.Add(Translator.Translate(e));
			}
		}
	}
}