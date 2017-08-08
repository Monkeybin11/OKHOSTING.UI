using AVFoundation;
using CoreGraphics;
using Foundation;
using System;
using System.Drawing;
using System.IO;
using UIKit;

namespace OKHOSTING.UI.Xamarin.iOS.Media
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
			CoreMedia.CMTime actualTime;
			NSError outError;

			using (var asset = AVAsset.FromUrl(NSUrl.FromFilename(localFilePath)))
			using (var imageGen = new AVAssetImageGenerator(asset))
			using (var imageRef = imageGen.CopyCGImageAtTime(new CoreMedia.CMTime(1, 1), out actualTime, out outError))
			{
				if (imageRef == null)
					return null;
				var image = UIImage.FromImage(imageRef);

				return image.AsPNG().AsStream();
			}
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
			UIImage originalImage = new UIImage(NSData.FromStream(original));

			float oldWidth = (float) originalImage.Size.Width;
			float oldHeight = (float) originalImage.Size.Height;
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

			//create a 24bit RGB image
			using (CGBitmapContext context = new CGBitmapContext(IntPtr.Zero,
				(int)newWidth, (int)newHeight, 8,
				(int)(4 * newWidth), CGColorSpace.CreateDeviceRGB(),
				CGImageAlphaInfo.PremultipliedFirst))
			{

				RectangleF imageRect = new RectangleF(0, 0, newWidth, newHeight);

				// draw the image
				context.DrawImage(imageRect, originalImage.CGImage);

				UIImage resizedImage = UIImage.FromImage(context.ToImage());

				// save the image as a jpeg
				return resizedImage.AsJPEG((float) quality).AsStream();
			}
		}
	}
}