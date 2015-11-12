using System;
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
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public IPage Page
		{
			get
			{
				return (IPage)App.Current.MainPage;
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