using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI.Controllers
{
	public class TreeListPicker: Controller
	{
		public IListPicker ListPicker { get; protected set; }

		/// <summary>
		/// The items of this list picker
		/// </summary>
		public IEnumerable<Item> Items { get; set; }

		public string Value 
		{ 
			get 
			{
				return ListPicker?.Value?.TrimStart(' ', '-');
			} 
			set 
			{
				var item = ListPicker.Items.Where(i => i.EndsWith("-" + value)).SingleOrDefault();
				ListPicker.Value = item;
			} 
		}
		
		public override void Refresh()
		{
			Page.Content = null;

			ListPicker.Items = null;

			Item[] items = Items.ToArray();

			//set items
			for (int itemIndex = 0; itemIndex < items.Length; itemIndex++)
			{
				AddRow(items, itemIndex);
			}

			Page.Content = ListPicker;
		}

		protected internal override void OnStart()
		{
			ListPicker = BaitAndSwitch.Create<IListPicker>();
			Refresh();
		}

		protected void AddRow(Item[] items, int itemIndex)
		{
			Item item = items[itemIndex];

			ListPicker.Items.Add(item.Text);

			if (item.Children != null && item.Children.Any())
			{
				var childrenMargin = item.Text.Split(new[] { "-" }, StringSplitOptions.None).FirstOrDefault() ?? "";
				childrenMargin = childrenMargin + "    -";

				var children = item.Children.ToArray();

				for (int childrenIndex = 0; childrenIndex < children.Length; childrenIndex++)
				{
					children[childrenIndex].Text = childrenMargin + children[childrenIndex].Text;

					AddRow(children, childrenIndex);
				}
			}
		}

		/// <summary>
		/// Represents an item in a TreeListPicker, with optional children items
		/// </summary>
		public class Item
		{
			/// <summary>
			/// The text to be displayed for this item
			/// </summary>
			public string Text { get; set; }

			/// <summary>
			/// The children items of this item, will be displayed a little to the right of the parent
			/// </summary>
			public ICollection<Item> Children { get; set; }
		}
	}
}