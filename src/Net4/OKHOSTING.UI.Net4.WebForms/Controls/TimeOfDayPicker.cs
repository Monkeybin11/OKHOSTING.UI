using System;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class TimeOfDayPicker : TextBoxBase, ITimeOfDayPicker
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

		/// <summary>
		/// Raises the value changed.
		/// </summary>
		/// <returns>The value changed.</returns>
		protected internal void RaiseValueChanged()
		{
			ValueChanged?.Invoke(this, ((IInputControl<TimeSpan?>) this).Value);
		}

		#endregion
	}
}