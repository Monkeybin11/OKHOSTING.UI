using OKHOSTING.UI.Media;
using System;
using global::Xamarin.Essentials;

namespace OKHOSTING.UI.Xamarin.Forms.Media
{
	public class OpenUri : IOpenUri
	{
		public async void Open(Uri uri)
		{
			await Browser.OpenAsync(uri);
		}
	}
}