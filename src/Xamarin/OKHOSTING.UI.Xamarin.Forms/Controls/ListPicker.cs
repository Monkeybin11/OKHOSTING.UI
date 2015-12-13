using System;
using System.Linq;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class ListPicker : global::Xamarin.Forms.Picker, IListPicker
	{
		public IEnumerable<string> DataSource
		{
			get
			{
				return base.Items;
			}
			set
			{
				base.Items.Clear();
				
				foreach(string item in value)
				{
					base.Items.Add(item);
				}
			}
		}

		public string Name
		{
			get; set;
		}

		public string SelectedItem
		{
			get
			{
				return DataSource.ToArray()[base.SelectedIndex];
			}
			set
			{
				int index = DataSource.ToList().IndexOf(value);
				base.SelectedIndex = index;
			}
		}

		public bool Visible
		{
			get
			{
				return base.IsVisible;
			}
			set
			{
				base.IsVisible = value;
			}
		}

		public void Dispose()
		{
		}
	}
}