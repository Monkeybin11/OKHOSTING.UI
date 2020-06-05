using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections;
using Native = System.Windows.Forms;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class ControlList : Data.ListBase<IControl>, IList<IControl>
	{
		public ControlList(Native.Control.ControlCollection innerList)
		{
			if (innerList == null)
			{
				throw new ArgumentNullException("innerList");
			}

			InnerList = innerList;
		}

		protected readonly Native.Control.ControlCollection InnerList;

		public override IControl this[int index]
		{
			get
			{
				return (IControl) InnerList[index];
			}
			set
			{
				((IList) InnerList)[index] = (Native.Control) value;
			}
		}

		public override int Count
		{
			get
			{
				return InnerList.Count;
			}
		}

		public override bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public override void Add(IControl item)
		{
			InnerList.Add((Native.Control) item);
		}

		public override void Clear()
		{
			InnerList.Clear();

		}

		public override bool Contains(IControl item)
		{
			return InnerList.Contains((Native.Control) item);
		}

		public override IEnumerator<IControl> GetEnumerator()
		{
			foreach (Native.Control view in InnerList)
			{
				yield return (IControl) view;
			}
		}

		public override int IndexOf(IControl item)
		{
			return InnerList.IndexOf((Native.Control) item);
		}

		public override void Insert(int index, IControl item)
		{
			((IList) InnerList).Insert(index, (Native.Control) item);
		}

		public override bool Remove(IControl item)
		{
			InnerList.Remove((Native.Control) item);

			return true;
		}

		public override void RemoveAt(int index)
		{
			InnerList.RemoveAt(index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}