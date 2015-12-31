using System;

namespace OKHOSTING.UI.Controls
{
	public interface ICalendar: ITextControl
	{
		DateTime? SelectedDate { get; set; }

		/// <summary>
		/// Raises after the value has changed by the user. Chages made in code will not raise this event.
		/// </summary>
		event EventHandler ValueChanged;
	}
}