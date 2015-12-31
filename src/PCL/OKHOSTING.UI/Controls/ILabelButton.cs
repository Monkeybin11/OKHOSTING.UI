using System;

namespace OKHOSTING.UI.Controls
{
	public interface ILabelButton: ILabel
	{
		/// <summary>
		/// Raises after the value has changed by the user. Chages made in code will not raise this event.
		/// </summary>
		event EventHandler Click;
	}
}