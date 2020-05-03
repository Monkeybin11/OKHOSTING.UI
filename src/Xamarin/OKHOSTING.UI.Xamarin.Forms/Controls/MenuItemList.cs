using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections;
using Native = global::Xamarin.Forms.MenuItem;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class MenuItemList : IList<IMenuItem>
	{
		public MenuItemList(System.Collections.ObjectModel.ObservableCollection<Native> innerList)
		{
			if (innerList == null)
			{
				throw new ArgumentNullException("innerList");
			}

			InnerList = innerList;
		}

		protected readonly System.Collections.ObjectModel.ObservableCollection<Native> InnerList;

		public IMenuItem this[int index]
		{
			get
			{
				return (IMenuItem) InnerList[index];
			}
			set
			{
				InnerList[index] = (MenuItem) value;
			}
		}

		public int Count
		{
			get
			{
				return InnerList.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public void Add(IMenuItem item)
		{
			InnerList.Add((MenuItem) item);
		}

		public void Clear()
		{
			InnerList.Clear();

		}

		public bool Contains(IMenuItem item)
		{
			return InnerList.Contains((MenuItem) item);
		}

		public void CopyTo(IMenuItem[] array, int arrayIndex)
		{
			InnerList.CopyTo((MenuItem[]) array, arrayIndex);
		}

		public IEnumerator<IMenuItem> GetEnumerator()
		{
			foreach (MenuItem view in InnerList)
			{
				yield return view;
			}
		}

		public int IndexOf(IMenuItem item)
		{
			return InnerList.IndexOf((MenuItem) item);
		}

		public void Insert(int index, IMenuItem item)
		{
			InnerList.Insert(index, (MenuItem) item);
		}

		public bool Remove(IMenuItem item)
		{
			InnerList.Remove((MenuItem) item);

			return true;
		}

		public void RemoveAt(int index)
		{
			InnerList.RemoveAt(index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}