using System;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	
	public class Image : Control<global::Xamarin.Forms.Image>, IImage
	//public class Image : FFImageLoading.Forms.CachedImage, IImage
	{
		public Image()
		{
			//base.DownsampleToViewSize = true;
			//base.CacheType = FFImageLoading.Cache.CacheType.Disk;
			//base.CacheDuration = new TimeSpan(6, 0, 0);
		}

		/// <summary>
		/// Load a image from URL.
		/// <para xml:lang="es">
		/// Carga una imagen desde un Url.
		/// </para>
		/// </summary>
		/// <param name="url">URL.
		/// <para xml:lang="es">El URL</para>
		/// </param>
		void IImage.LoadFromUrl(Uri url)
		{
			Content.Source = new global::Xamarin.Forms.UriImageSource
			{
				Uri = url,
				CachingEnabled = true,
				CacheValidity = new TimeSpan(0, 0, 1, 0)
			};
		}

		/// <summary>
		/// Load a image from file.
		/// <para xml:lang="es">
		/// Carga una imagen desde un archivo.
		/// </para>
		/// </summary>
		/// <returns>The file of the image.</returns>
		/// <param name="filePath">File path.
		/// <para xml:lang="es">La ruta del archivo</para>
		/// </param>
		void IImage.LoadFromFile(string filePath)
		{
			Content.Source = global::Xamarin.Forms.ImageSource.FromFile(filePath);
		}

		/// <summary>
		/// Load a image from stream.
		/// <para xml:lang="es">
		/// Carga una imagen desde un stream
		/// </para>
		/// </summary>
		/// <returns>The stream of the image.</returns>
		/// <param name="stream">Stream.
		/// <para xml:lang="es">El stream de la imagen</para>
		/// </param>
		void IImage.LoadFromStream(Stream stream)
		{
			Content.Source = global::Xamarin.Forms.ImageSource.FromStream(() => stream);
		}

		/// <summary>
		/// Load a image from an array of bytes
		/// <para xml:lang="es">
		/// Carga una imagen desde un arreglo de bytes
		/// </para>
		/// </summary>
		void IImage.LoadFromBytes(byte[] bytes)
		{
			((IImage) this).LoadFromStream(new MemoryStream(bytes));
		}
	}
}