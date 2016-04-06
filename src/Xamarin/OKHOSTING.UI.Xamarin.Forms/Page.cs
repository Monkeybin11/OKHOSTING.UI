using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Forms
{
	public class Page : global::Xamarin.Forms.ContentPage, IPage
	{
		private readonly global::Xamarin.Forms.ScrollView Scroll;

		public Page()
		{
			Scroll = new global::Xamarin.Forms.ScrollView();
			base.Content = Scroll;
		}

		public new IControl Content
		{
			get
			{
				return (IControl) Scroll.Content;
			}
			set
			{
                Scroll.Content = (global::Xamarin.Forms.View) value;
			}
		}

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (Platform.Current.Controller != null)
            {
                Platform.Current.Controller.Resize();
            }
        }
    }
}