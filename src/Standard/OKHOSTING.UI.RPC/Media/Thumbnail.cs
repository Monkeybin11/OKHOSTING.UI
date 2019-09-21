using OKHOSTING.UI.Media;
using System.IO;

namespace OKHOSTING.UI.RPC.Media
{
	/// <summary>
	/// Faciliates the creation of thumbnails for both videos and images
	/// </summary>
	public class Thumbnail: OKHOSTING.RPC.Bidireccional.ServerObject, IThumbnail
	{
		/// <summary>
		/// Creates a thumbnail image from a local video
		/// </summary>
		/// <param name="localVideoPath">Full path of the video file, that should exist in the local storage</param>
		/// <returns>A stream containing the thumbnail bitmap</returns>
		public Stream CreateVideoThumbnail(string localVideoPath)
		{
			return (Stream) Invoke(nameof(CreateVideoThumbnail), localVideoPath);
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
			return (Stream) Invoke(nameof(CreateImageThumbnail), original, width, height, quality);
		}
	}
}