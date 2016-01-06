using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Forms
{
	public class Page : global::Xamarin.Forms.ContentPage, IPage
	{
		public Page()
		{
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

		//void IDisposable.Dispose()
		//{
		//	Content.Dispose();
		//}
	}
}