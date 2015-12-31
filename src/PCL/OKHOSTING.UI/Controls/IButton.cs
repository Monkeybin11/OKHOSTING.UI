using System;

namespace OKHOSTING.UI.Controls
{
	public interface IButton: ITextControl
	{
		string Text
		{
			get; set;
		}

		/// <summary>
		/// Raises after the user clicked on the button
		/// </summary>
		event EventHandler Click;
	}
}