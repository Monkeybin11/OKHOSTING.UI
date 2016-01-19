namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// Base class for all fields that uses a single TextBox as ValueControl
	/// </summary>
	public abstract class TextBoxField : FormField
	{
		/// <summary>
		/// Control that parses the value to web
		/// </summary>
		protected new ITextBox ValueControl
		{
			get
			{
				return (ITextBox) base.ValueControl;
			}
			set
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

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			//create a sinple TextBox
			ValueControl = Platform.Current.Create<ITextBox>();
		}
	}
}