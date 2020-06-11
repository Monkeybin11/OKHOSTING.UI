using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class TimeOfDayPicker : TextBoxBase, ITimeOfDayPicker, IInputControl, IInputControl<TimeSpan?>
	{
		public TimeOfDayPicker()
		{
			Attributes["pattern"] = "(0[0-9]|1[0-9]|2[0-3])(:[0-5][0-9])";
			Attributes["placeholder"] = @"hh:mm";
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
				var changed = false;

				if (((IInputControl<TimeSpan?>) this).Value != value)
				{
					changed = true;
				}

				if (value != null)
				{
					base.Text = value.Value.ToString("hh\\:mm");
				}
				else
				{
					base.Text = null;
				}

				if (changed)
				{
					OnValueChanged();
				}
			}
		}

		/// <summary>
		/// Occurs when value changed.
		/// </summary>
		public event EventHandler<TimeSpan?> ValueChanged;

		#endregion

		#region IWebInputControl

		void IInputControl.HandlePostBack()
		{
			TimeSpan span;
			string postedValue = Page?.Request.Form[ID];

			if (TimeSpan.TryParse(postedValue, out span))
			{
				((ITimeOfDayPicker) this).Value = span;
			}
		}

		protected void OnValueChanged()
		{
			ValueChanged?.Invoke(this, ((ITimeOfDayPicker) this).Value);
		}

		#endregion
	}
}