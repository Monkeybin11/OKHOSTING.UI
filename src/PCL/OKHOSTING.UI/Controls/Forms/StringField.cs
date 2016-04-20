using System;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// Field for string values
	/// </summary>
	public class StringField : FormField
	{
		public new IInputControl<string> ValueControl
		{
			get
			{
				return (IInputControl<string>) base.ValueControl;
			}

			protected set
			{
				base.ValueControl = value;
			}
		}

		public override object Value
		{
			get
			{
				return ValueControl.Value;
			}
			set
			{
				if (value == null)
				{
					ValueControl.Value = null;
				}
				else
				{
					ValueControl.Value = value.ToString();
				}
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
		/// A regular expression pattern used for regex validation.
		/// If set to null, no regex validation is done
		/// </summary>
		public string RegularExpression { get; set; }

		/// <summary>
		/// Maximum lenght allowed for the string Value. Zero means no limit
		/// </summary>
		public int MaxLenght { get; set; }

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			if (MaxLenght == 0)
			{
				ValueControl = Platform.Current.Create<ITextArea>();
			}
			else
			{
				ValueControl = Platform.Current.Create<ITextBox>();
			}
		}
	}
}