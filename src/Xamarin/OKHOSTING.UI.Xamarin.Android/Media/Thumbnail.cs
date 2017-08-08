using Android.Graphics;
using System.IO;
using System;

namespace OKHOSTING.UI.Xamarin.Android.Media
{

	/// <summary>
	/// Faciliates the creation of thumbnails for both videos and images
	/// </summary>
	public class Thumbnail: UI.Media.IThumbnail
	{
		/// <summary>
		/// Creates a thumbnail image from a local video
		/// </summary>
		/// <param name="localVideoPath">Full path of the video file, that should exist in the local storage</param>
		/// <returns>A stream containing the thumbnail bitmap</returns>
		public Stream CreateVideoThumbnail(string localFilePath)
		{
			var thumb = global::Android.Media.ThumbnailUtils.CreateVideoThumbnail(localFilePath, global::Android.Provider.ThumbnailKind.FullScreenKind);
			var stream = new MemoryStream();

			thumb.Compress(Bitmap.CompressFormat.Png, 0, stream);
			stream.Seek(0, SeekOrigin.Begin);

			return stream;
		}

		/// <summary>
		/// Creates a thumbnail image from an image
		/// </summary>
		/// <param name="original">Original image</param>
		/// <param name="width">Width of the new thumbnail</param>
		/// <param name="height">Height of the new thumbnail</param>
		/// <param name="quality">JPEG quality needed</param>
		/// <returns>A stream containing the thumbnail bitmap</returns>
		public Stream CreateImageThumbnail(Stream original, int width, int height, int quality)
		{
			// Load the bitmap
			Bitmap originalImage = BitmapFactory.DecodeStream(original);

			float oldWidth = originalImage.Width;
			float oldHeight = originalImage.Height;
			float scaleFactor = 0f;

			if (oldWidth > oldHeight)
			{
				scaleFactor = width / oldWidth;
			}
			else
			{
				scaleFactor = height / oldHeight;
			}

			float newHeight = oldHeight * scaleFactor;
			float newWidth = oldWidth * scaleFactor;

			Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)newWidth, (int)newHeight, false);

			MemoryStream ms = new MemoryStream();
			resizedImage.Compress(Bitmap.CompressFormat.Jpeg, quality, ms);

			return ms;
		}
	}
}