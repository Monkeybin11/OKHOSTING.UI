using System;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.UWP
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public class ThumbnailCreator
	{
		public static Stream ResizeImage(Stream imageData, float width, float height, int quality)
		{
			WriteableBitmap bitmap = PictureDecoder.DecodeJpeg(imageData, (int)width, (int)height);
			bitmap.SaveJpeg(streamOut, (int) width, (int) height, quality, 100);

			return streamOut;
		}

	}
}