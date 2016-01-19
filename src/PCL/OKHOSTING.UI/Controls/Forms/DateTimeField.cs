using System;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A field for selecting a date and time
	/// </summary>
	public class DateTimeField : DateField
	{
		public DateTimeField()
		{
			Format = "yyyy/MM/dd hh:mm";
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			//create date texbox from base
			base.CreateValueControl();

			//adjust controls width
			ValueControl.InputType = ITextBoxInputType.DateTime;
		}
	}
}