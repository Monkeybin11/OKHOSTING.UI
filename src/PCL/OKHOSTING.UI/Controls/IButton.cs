using System;

namespace OKHOSTING.UI.Controls
{
	public interface IButton: ITextControl
	{
		string Text
		{
			get; set;
		}

		event EventHandler Click;
	}
}