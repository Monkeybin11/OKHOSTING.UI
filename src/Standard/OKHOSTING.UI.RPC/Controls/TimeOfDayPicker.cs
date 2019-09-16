using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// Allows the user to choose a time of day value, from 00:00:00 to 23:23:59
	/// </summary>
	public class TimeOfDayPicker : TextControl, ITimeOfDayPicker
	{
		public TimeSpan? Value
		{
			get
			{
				return (TimeSpan?) Get(nameof(Value));
			}
			set
			{
				Set(nameof(Value), value);
			}
		}

		public event EventHandler<TimeSpan?> ValueChanged
		{
			add
			{
				AddHybridEventHandler(nameof(ValueChanged), value);
			}
			remove
			{
				RemoveHybridEventHandler(nameof(ValueChanged), value);
			}
		}
	}
}