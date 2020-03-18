using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A tree-menu control for navigation or similar purposes
	/// </summary>
	public interface IMenu: ITextControl
	{
		ICollection<IMenuItem> Items { get; set; }
	}

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