using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;
namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// An item on a menu, that can have subitems
	/// </summary>
	public class MenuItem : IMenuItem
	{
		public MenuItem()
		{
			Children = new List<IMenuItem>();
		}

		public MenuItem(string text)
		{
			Children = new List<IMenuItem>();
			Text = text;
		}

		public MenuItem(string text, EventHandler onClick)
		{
			Children = new List<IMenuItem>();
			Text = text;
			Click += onClick;
		}

		/// <summary>
		/// Text of the item
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// The sub items of this menu item
		/// </summary>
		public ICollection<IMenuItem> Children { get; protected set; }

		/// <summary>
		/// Raised after the user clicks on the item
		/// </summary>
		public event EventHandler Click;

		/// <summary>
		/// Raises the onclick event
		/// </summary>
		public void OnClick(EventArgs e)
		{
			Click?.Invoke(this, e);
		}

		public override string ToString()
		{
			return Text ?? base.ToString();
		}
	}
}