using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	public interface IMenuItem
	{
		string Text { get; set; }

		ICollection<IMenuItem> Children { get; set; }

		/// <summary>
		/// Raised after the user clicks on the item
		/// </summary>
		event EventHandler Click;
	}
}