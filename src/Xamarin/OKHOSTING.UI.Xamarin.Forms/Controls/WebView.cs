using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class WebView: Control<global::Xamarin.Forms.WebView>, IWebView
	{
		Uri _Source;

		public Uri Source
		{
			get
			{
				return _Source;
			}
			set
			{
				Content.Source = _Source = value;
			}
		}
	}
}