using System;

namespace OKHOSTING.UI.Controls
{
	public interface ILabelButton: ILabel
	{
		event EventHandler Click;
	}
}