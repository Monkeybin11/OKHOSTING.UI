using System;

namespace OKHOSTING.UI.Controls
{
	public interface ICalendar: ITextControl
	{
		DateTime? SelectedDate { get; set; }
	}
}