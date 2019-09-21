using System;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// Allows the user to choose a time of day value, from 00:00:00 to 23:23:59
	/// </summary>
	public interface ITimeOfDayPicker : ITextControl, IInputControl<TimeSpan?>
	{
	}
}