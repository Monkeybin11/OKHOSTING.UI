using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class MenuItem : System.Windows.Controls.MenuItem, IMenuItem
	{
		protected readonly MenuItemList _Children;

		public new event EventHandler Click;

		public MenuItem()
		{
			base.Click += MenuItem_Click;
			_Children = new MenuItemList(base.Items);
		}

		public MenuItem(string text): this()
		{
			Text = text;
		}

		public MenuItem(string text, EventHandler onClick) : this(text)
		{
			Click += onClick;
		}

		public ICollection<IMenuItem> Children
		{
			get
			{
				return _Children;
			}
		}

		public string Text
		{
			get
			{
				return (string) base.Header;
			}
			set
			{
				base.Header = value;
			}
		}

		public override string ToString()
		{
			return Text ?? base.ToString();
		}

		protected virtual void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (sender == e.OriginalSource)
			{
				Click?.Invoke(sender, e);
			}
		}
	}
}
