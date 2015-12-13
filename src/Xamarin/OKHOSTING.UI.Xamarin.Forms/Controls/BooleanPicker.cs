using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class BooleanPicker : global::Xamarin.Forms.Switch, IBooleanPicker
	{
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

		public bool SelectedValue
		{
			get
			{
				return base.IsToggled;
			}
			set
			{
				base.IsToggled = value;
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