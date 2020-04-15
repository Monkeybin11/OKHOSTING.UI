using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A tree-menu control for navigation or similar purposes
	/// </summary>
	public interface IMenu : ITextControl
	{
		ICollection<MenuItem> Items { get; set; }
	}

	/// <summary>
	/// An item on a menu, that can have subitems
	/// </summary>
	public class MenuItem
	{
		public MenuItem()
		{
		}

		public MenuItem(string text)
		{
			Text = text;
		}

		public MenuItem(string text, EventHandler onClick)
		{
			Text = text;
			Click += onClick;
		}

		/// <summary>
		/// Text of the item
		/// </summary>
		public string Text { get; set; }

		public ICollection<MenuItem> Children { get; set; }

		/// <summary>
		/// Raised after the user clicks on the item
		/// </summary>
		public event EventHandler Click;

		public void OnClick(EventArgs e)
		{
			Click?.Invoke(this, e);
		}
	}
}