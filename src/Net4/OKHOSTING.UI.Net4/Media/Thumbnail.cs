using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace OKHOSTING.UI.Net4.Media
{
	public class Thumbnail : UI.Media.IThumbnail
	{
		public Stream CreateImageThumbnail(Stream original, int width, int height, int quality)
		{
			Stream result = new MemoryStream();
			Image image = new Bitmap(original);
			image.GetThumbnailImage(width, height, null, new IntPtr()).Save(result, ImageFormat.Jpeg);

			return result;
		}

		public Stream CreateVideoThumbnail(string localVideoPath)
		{
			Stream result = new MemoryStream();
			var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
			ffMpeg.GetVideoThumbnail(localVideoPath, result, 5);

			return result;
		}
	}
}