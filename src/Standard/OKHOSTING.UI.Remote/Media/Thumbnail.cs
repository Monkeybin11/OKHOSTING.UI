using OKHOSTING.UI.Media;
using System.IO;

namespace OKHOSTING.UI.Remote.Media
{
	/// <summary>
	/// Faciliates the creation of thumbnails for both videos and images
	/// </summary>
	public class Thumbnail: IThumbnail
	{
		/// <summary>
		/// Creates a thumbnail image from a local video
		/// </summary>
		/// <param name="localVideoPath">Full path of the video file, that should exist in the local storage</param>
		/// <returns>A stream containing the thumbnail bitmap</returns>
		public Stream CreateVideoThumbnail(string localVideoPath)
		{
			throw new System.NotImplementedException();
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
			throw new System.NotImplementedException();
		}
	}
}