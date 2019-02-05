using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Enums;
using Xabe.FFmpeg.Model;

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
			string output = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + FileExtensions.Png);
			IConversionResult result = Conversion.Snapshot(localVideoPath, output, TimeSpan.FromSeconds(0)).Start().Result;

			return File.Open(output, FileMode.Open);
		}
	}
}