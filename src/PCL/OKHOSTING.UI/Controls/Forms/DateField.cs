using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A field for selecting a date
	/// </summary>
	[Serializable]
	public class DateField : TextBoxField
	{
		/// <summary>
		/// Format used to show and retrieve date value
		/// </summary>
		public const string Format = "dd/MM/yyyy";

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			//create texbox from base
			base.CreateValueControl();

			//add ajax date mask
			AjaxControlToolkit.MaskedEditExtender mask = new AjaxControlToolkit.MaskedEditExtender();
			mask.Mask = "99/99/9999";
			mask.MaskType = AjaxControlToolkit.MaskedEditType.Date;
			mask.TargetControlID = ValueControlId;
			mask.ID = ValueControlId + "_mask";

			//add ajax calendar
			AjaxControlToolkit.CalendarExtender calendar = new AjaxControlToolkit.CalendarExtender();
			calendar.TargetControlID = ValueControlId;
			calendar.ID = ValueControlId + "_calendar";
			calendar.Format = Format;

			//add ajax extenders
			AditionalControls.Add(mask);
			AditionalControls.Add(calendar);
		}

		/// <summary>
		/// Creates a new instance
		/// </summary>
		public DateField()
		{
			ValueType = typeof(DateTime);
		}

		/// <summary>
		/// Creates a new instance based on serialization info
		/// </summary>
		public DateField(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext ctxt)
			: base(info, ctxt)
		{
		}

		/// <summary>
		/// Assings the Value to the valuecontrol input
		/// </summary>
		internal override void ValueToControl()
		{
			if (Value != null)
				ValueControl.Text = ((DateTime)Value).ToString(Format);
			else
				ValueControl.Text = null;
		}

		/// <summary>
		/// Retrieves the user input from the value control and assigns it to Value
		/// </summary>
		internal override void ControlToValue()
		{
			DateTime result;

			if (DateTime.TryParseExact(ValueControl.Text, Format, null, System.Globalization.DateTimeStyles.None, out result))
				Value = result;
			else
				Value = null;
		}
	}
}