using System;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class TimeOfDayPicker : TextBoxBase, ITimeOfDayPicker, IWebInputControl
	{
		public TimeOfDayPicker()
		{
			base.Attributes["type"] = "time";
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
				return TimeSpan.Parse(base.Text);
			}
			set
			{
				if (value.HasValue)
				{
					base.Text = value.Value.ToString();
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