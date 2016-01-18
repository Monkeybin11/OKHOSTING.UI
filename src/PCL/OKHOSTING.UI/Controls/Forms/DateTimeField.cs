using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A field for selecting a date and time
	/// </summary>
	[Serializable]
	public class DateTimeField : DateField
	{
		/// <summary>
		/// Control where Time will be stored
		/// </summary>
		TextBox TimeControl;

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			//create date texbox from base
			base.CreateValueControl();

			//add time textbox for hour and minutes
			TimeControl = new TextBox();
			TimeControl.ID = ValueControlId + " _time";
			TimeControl.Enabled = this.Enabled;

			//add ajax time mask
			AjaxControlToolkit.MaskedEditExtender mask = new AjaxControlToolkit.MaskedEditExtender();
			mask.Mask = "99:99";
			mask.MaskType = AjaxControlToolkit.MaskedEditType.Time;
			mask.TargetControlID = TimeControl.ID;
			mask.ID = TimeControl.ID + "_mask";

			//add aditional controls
			AditionalControls.Add(TimeControl);
			AditionalControls.Add(mask);

			//adjust controls width
			ValueControl.Width = new Unit(70, UnitType.Pixel);
			TimeControl.Width = new Unit(35, UnitType.Pixel);
		}

		/// <summary>
		/// Creates a new instance
		/// </summary>
		public DateTimeField()
		{
		}

		/// <summary>
		/// Creates a new instance based on serialization info
		/// </summary>
		public DateTimeField(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext ctxt)
			: base(info, ctxt)
		{
		}

		/// <summary>
		/// Assings the Value to the valuecontrol input
		/// </summary>
		internal override void ValueToControl()
		{
			//get date value from base class
			base.ValueToControl();

			//get time
			if (Value != null)
				TimeControl.Text = ((DateTime)Value).ToString("HH:mm");
			else
				TimeControl.Text = null;
		}

		/// <summary>
		/// Retrieves the user input from the value control and assigns it to Value
		/// </summary>
		internal override void ControlToValue()
		{
			//set date value from base class
			base.ControlToValue();
			
			//if date is null, exit
			if (NullValues.IsNull(Value)) return;

			//set time
			DateTime result;

			if (DateTime.TryParseExact(TimeControl.Text, "HH:mm", null, System.Globalization.DateTimeStyles.None, out result))
			{
				Value = ((DateTime)Value).AddHours(result.Hour).AddMinutes(result.Minute);
			}
		}

		/// <summary>
		/// Retrieves values selected by the user and set's the value to the ValueControl
		/// </summary>
		internal override void RetrieveUserInput()
		{
			//retrieve date from base class
			base.RetrieveUserInput();

			//retrieve time
			TimeControl.Text = Container.Page.Request[TimeControl.UniqueID];
		}
	}
}