using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Android
{
	[Activity (Label = "OKHOSTING.UI.Xamarin.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class Page : Activity, IPage
	{
		protected IControl _Content;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			Platform.Current = new Platform(this);
			Platform.Current.Controller.Run();
		}

		public IControl Content
		{
			get
			{
				return _Content;
			}
			set
			{
				if (value != null)
				{
					base.AddContentView ((View) value, null);
					_Content = value;
				}
			}
		}
	}
}


