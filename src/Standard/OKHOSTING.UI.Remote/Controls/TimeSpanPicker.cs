using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Remote.Controls
{
	/// <summary>
	/// Allows the user to choose a timespan value
	/// </summary>
	public class TimeSpanPicker : TextControl, ITimeSpanPicker
	{
		public TimeSpan? Value { get; set; }

		public event EventHandler<TimeSpan?> ValueChanged;
	}
}