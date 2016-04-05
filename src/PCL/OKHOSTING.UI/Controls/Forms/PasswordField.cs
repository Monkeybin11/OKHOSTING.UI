using System;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// Field for string values
	/// </summary>
	public class PasswordField : FormField
	{
		public new IPasswordTextBox ValueControl
		{
			get
			{
				return (IPasswordTextBox) base.ValueControl;
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
				ValueControl.Value = (string) value;
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
			ValueControl = Platform.Current.Create<IPasswordTextBox>();
        }
	}
}