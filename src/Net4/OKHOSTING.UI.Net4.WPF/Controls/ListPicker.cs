using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class ListPicker : System.Windows.Controls.ComboBox, IListPicker
	{
		public IEnumerable<string> DataSource
		{
			get
			{
				return (IEnumerable<string>) base.ItemsSource;
			}
			set
			{
				base.ItemsSource = value;
			}
		}

		public bool Visible
		{
			get
			{
				return base.Visibility == System.Windows.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = System.Windows.Visibility.Visible;
				}
				else
				{
					base.Visibility = System.Windows.Visibility.Hidden;
				}
			}
		}

		string IListPicker.SelectedItem
		{
			get
			{
				return (string) base.SelectedItem;
			}

			set
			{
				base.SelectedItem = value;
			}
		}

		public void Dispose()
		{
		}
	}
}