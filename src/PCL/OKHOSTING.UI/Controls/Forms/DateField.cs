using System;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A field for selecting a date
	/// </summary>
	public class DateField : TextBoxField
	{
		public DateField()
		{
			Format = "yyyy/MM/dd";
		}

		public override object Value
		{
			get
			{
				return DateTime.ParseExact(ValueControl.Value, Format, System.Globalization.CultureInfo.InvariantCulture);
			}
			set
			{
				ValueControl.Value = ((DateTime) value).ToString(Format);
			}
		}

		public override Type ValueType
		{
			get
			{
				return typeof(DateTime);
			}
		}

		/// <summary>
		/// Format used to show and retrieve date value
		/// </summary>
		public string Format { get; set; }

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			//create date texbox from base
			base.CreateValueControl();

			ValueControl.InputType = ITextBoxInputType.Date;
		}

		public override bool IsValid
		{
			get
			{
				DateTime test;
				return base.IsValid && DateTime.TryParseExact(ValueControl.Value, Format, null, System.Globalization.DateTimeStyles.None, out test);
			}
		}
	}
}