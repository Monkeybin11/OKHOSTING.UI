using System;

namespace OKHOSTING.UI.Xamarin.Android
{
	public class Button: global::Android.Widget.Button, UI.Controls.IButton
	{
		public Button(global::Android.Content.Context context): base(context)
		{
		}

		public string Name 
		{
			get;
			set;
		}

		public bool Visible
		{
			get 
			{
				return base.Visibility == global::Android.Views.ViewStates.Visible;
			}
			set
			{
				if (value) 
				{
					base.Visibility = global::Android.Views.ViewStates.Visible;
				} 
				else 
				{
					base.Visibility = global::Android.Views.ViewStates.Invisible;
				}
			}
		}

		public IPage Page
		{
			get
			{
				return null;//(Page) global::Android.Content.Context.;
			}
		}
	}
}