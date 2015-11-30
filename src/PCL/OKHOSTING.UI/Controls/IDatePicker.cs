using System;

namespace OKHOSTING.UI.Controls
{
	public interface IDatePicker: ITextControl
	{
		DateTime SelectedDate { get; set; }
	}
}