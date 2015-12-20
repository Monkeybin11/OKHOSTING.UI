using OKHOSTING.UI.Controls;
using System;
using Gtk;

namespace OKHOSTING.UI.Xamarin.Gtk
{
	public class Page: global::Gtk.Window, IPage
	{
		public Page () : base (Gtk.WindowType.Toplevel)
		{
			Build ();
		}

		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}

		public new IControl Content
		{
			get
			{
				return (IControl) base.Content;
			}
			set
			{
				base.Content = (global::Xamarin.Forms.View) value;
			}
		}

		double IPage.Height
		{
			get
			{
				return base.HeightRequest
			}
		}

		double IPage.Width
		{
			get
			{
				return Acr.DeviceInfo.DeviceInfo.Hardware.ScreenWidth;
			}
		}
	}
}