using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A tree-menu control for navigation or similar purposes
	/// </summary>
	public interface IMenu : ITextControl
	{
		ICollection<IMenuItem> Items { get; }
	}

	public static class IMenuExtensions
	{
		public static IEnumerable<IMenuItem> GetAllItems(this IMenu menu)
		{
			if (menu?.Items == null)
			{
				yield break;
			}

			foreach (var item in menu.Items)
			{
				yield return item;

				foreach (var subItem in item.GetAllItems())
				{
					yield return subItem;
				}
			}
		}

		public static IEnumerable<IMenuItem> GetAllItems(this IMenuItem item)
		{
			if (item?.Children == null)
			{
				yield break;
			}

			foreach (var child in item.Children)
			{
				yield return child;

				foreach (var subChild in child.GetAllItems())
				{
					yield return subChild;
				}
			}
		}
	}
}