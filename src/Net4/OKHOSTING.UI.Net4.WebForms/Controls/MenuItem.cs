using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class MenuItem : IMenuItem
	{
		public System.Web.UI.WebControls.MenuItem NativeItem { get; set; }
		public string Text { get; set; }
		public ICollection<IMenuItem> Children { get; set; }

		public event EventHandler Click;

		public void DataBind()
		{
			NativeItem = new System.Web.UI.WebControls.MenuItem()
			{
				Text = Text,
			};

			foreach (MenuItem item in Children)
			{
				item.DataBind();
				NativeItem.ChildItems.Add(item.NativeItem);
			}
		}

		internal void OnClick()
		{
			Click?.Invoke(this, new EventArgs());
		}
	}
}