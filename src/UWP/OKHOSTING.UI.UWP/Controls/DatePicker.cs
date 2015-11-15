using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.UWP.Controls
{
	public class DatePicker : Windows.UI.Xaml.Controls.DatePicker, IDatePicker
	{
		public IPage Page
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

		public DateTime SelectedDate
		{
			get
			{
				return base.Date.DateTime;
			}
			set
			{
				base.Date = value;
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
