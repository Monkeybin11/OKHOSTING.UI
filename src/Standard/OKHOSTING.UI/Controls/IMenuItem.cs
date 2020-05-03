using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// An item on a menu, that can have subitems
	/// </summary>
	public interface IMenuItem
	{
		/// <summary>
		/// Text of the item
		/// </summary>
		string Text { get; set; }

		/// <summary>
		/// The sub items of this menu item
		/// </summary>
		ICollection<IMenuItem> Children { get; }

		/// <summary>
		/// Raised after the user clicks on the item
		/// </summary>
		event EventHandler Click;
	}
}