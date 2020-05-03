using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class MenuItem : global::Xamarin.Forms.MenuItem, IMenuItem
	{
		public event EventHandler Click;

		public MenuItem()
		{
			base.Clicked += MenuItem_Clicked;
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
			get;
			protected set;
		}

		public override string ToString()
		{
			return Text ?? base.ToString();
		}

		private void MenuItem_Clicked(object sender, EventArgs e)
		{
			Click?.Invoke(sender, e);
		}
	}
}
