using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// Allows the user to choose a timespan value
	/// </summary>
	public class TimeSpanPicker : TextControl, ITimeSpanPicker
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