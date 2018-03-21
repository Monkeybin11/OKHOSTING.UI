using System;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class TimeOfDayPicker : TextBoxBase, ITimeOfDayPicker, IWebInputControl
	{
		public TimeOfDayPicker()
		{
			//Attributes["pattern"] = "(0[0-9]|1[0-9]|2[0-3])(:[0-5][0-9]){2}";
			Attributes["pattern"] = "(0[0-9]|1[0-9]|2[0-3])(:[0-5][0-9])";
			Attributes["placeholder"] = @"HH:MM";
		}

		#region IInputControl

		/// <summary>
		/// Gets or sets the OKHOSTING.UI.Controls.InputControl<TimeSpan?>.Value
		/// </summary>
		/// <value>The OKHOSTING.UI.Controls.InputControl<TimeSpan?>.Value</value>
		TimeSpan? IInputControl<TimeSpan?>.Value
		{
			get
			{
				TimeSpan val;

				if (TimeSpan.TryParseExact(base.Text, "hh\\:mm", null, out val))
				{
					return val;
				}
				else
				{
					return null;
				}
			}
			set
			{
				if (value.HasValue)
				{
					base.Text = value.Value.ToString("hh\\:mm");
				}
			}
		}

		/// <summary>
		/// Occurs when value changed.
		/// </summary>
		public event EventHandler<TimeSpan?> ValueChanged;

		#endregion

		#region IWebInputControl

		bool IWebInputControl.HandlePostBack()
		{
			TimeSpan span = TimeSpan.Zero;
			string postedValue = Page.Request.Form[ID];

			if (TimeSpan.TryParse(postedValue, out span) && span != ((ITimeOfDayPicker) this).Value)
			{
				((ITimeOfDayPicker) this).Value = span;
				return true;
			}
			else
			{
				return false;
			}
		}

		void IWebInputControl.RaiseValueChanged()
		{
			ValueChanged?.Invoke(this, ((ITimeOfDayPicker) this).Value);
		}

		#endregion
	}
}