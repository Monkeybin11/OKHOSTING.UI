using OKHOSTING.UI.Controls;
using System;
using System.IO;

namespace OKHOSTING.UI.UWP.Controls
{
	public class ImageButton : Image, IImageButton
	{
		public ImageButton()
		{
			base.Tapped += ImageButton_Tapped;
		}

		public event EventHandler Click;

		private void ImageButton_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
		{
			Click?.Invoke(this, new EventArgs());
		}
	}
}
