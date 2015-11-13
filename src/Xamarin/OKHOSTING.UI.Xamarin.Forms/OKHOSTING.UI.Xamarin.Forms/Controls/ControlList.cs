using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;
using Native = global::Xamarin.Forms;
using System.Collections;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class ControlList : IList<IControl>
	{
		public ControlList(IList<Native.View> innerList)
		{
			if (innerList == null)
			{
				throw new ArgumentNullException("innerList");
			}

			InnerList = innerList;
		}

		protected readonly IList<Native.View> InnerList;

		public IControl this[int index]
		{
			get
			{
				return (IControl) InnerList[index];
			}
			set
			{
				InnerList[index] = (Native.View) value;
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

		public void Add(IControl item)
		{
			InnerList.Add((Native.View) item);
		}

		public void Clear()
		{
			InnerList.Clear();
		}

		public bool Contains(IControl item)
		{
			return InnerList.Contains((Native.View) item);
		}

		public void CopyTo(IControl[] array, int arrayIndex)
		{
			InnerList.CopyTo((Native.View[]) array, arrayIndex);
		}

		public IEnumerator<IControl> GetEnumerator()
		{
			foreach (Native.View view in InnerList)
			{
				yield return (IControl) view;
			}
		}

		public int IndexOf(IControl item)
		{
			return InnerList.IndexOf((Native.View) item);
		}

		public void Insert(int index, IControl item)
		{
			InnerList.Insert(index, (Native.View) item);
		}

		public bool Remove(IControl item)
		{
			return InnerList.Remove((Native.View) item);
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