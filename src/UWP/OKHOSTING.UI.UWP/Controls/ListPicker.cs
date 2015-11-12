using OKHOSTING.UI.Controls;
using System;
using System.IO;
using System.Collections.Generic;

namespace OKHOSTING.UI.UWP.Controls
{
	public class ListPicker : Windows.UI.Xaml.Controls.Panel, IListPicker
	{
		protected Windows.UI.Xaml.Controls.ListPickerFlyout InnerListPicker = new Windows.UI.Xaml.Controls.ListPickerFlyout();

		public IEnumerable<string> DataSource
		{
			get
			{
				return (IEnumerable<string>) InnerListPicker.ItemsSource;
			}
			set
			{
				InnerListPicker.ItemsSource = value;
			}
		}

		public IPage Page
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool Visible
		{
			get
			{
				return base.Visibility == Windows.UI.Xaml.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = Windows.UI.Xaml.Visibility.Visible;
				}
				else
				{
					base.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
				}
			}
		}

		public void Dispose()
		{
		}
	}
}
