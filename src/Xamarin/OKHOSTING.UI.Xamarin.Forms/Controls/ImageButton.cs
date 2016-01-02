using System;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class ImageButton : Image, IImageButton
	{
		public ImageButton()
		{
			var profileTapRecognizer = new global::Xamarin.Forms.TapGestureRecognizer
			{
				Command = new global::Xamarin.Forms.Command(() => 
				{
					if (Click != null)
					{
						Click(this, new EventArgs());
					}
				}),
				NumberOfTapsRequired = 1
			};
		}

		public event EventHandler Click;
	}
}
