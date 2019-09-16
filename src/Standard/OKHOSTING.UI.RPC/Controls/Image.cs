using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// Image.
	/// <para xml:lang="es">Una imagen a mostrar.</para>
	/// </summary>
	public class Image: Control, IImage
	{
		/// <summary>
		/// Loads the image from a Url
		/// <para xml:lang="es">
		/// Carga la imagen desde un Url.
		/// </para>
		/// </summary>
		public void LoadFromUrl(System.Uri url)
		{
			Invoke(nameof(LoadFromUrl), url);
		}

		/// <summary>
		/// Loads the image from a local file
		/// <para xml:lang="es">
		/// Carga la imagen desde un archivo local
		/// </para>
		/// </summary>
		public void LoadFromFile(string filePath)
		{
			Invoke(nameof(LoadFromFile), filePath);
		}

		/// <summary>
		/// Loads the image from a stream
		/// <para xml:lang="es">
		/// Carga la imagen desde un stream
		/// </para>
		/// </summary>
		public void LoadFromStream(Stream stream)
		{
			Invoke(nameof(LoadFromStream), stream);
		}

		/// <summary>
		/// Load a image from an array of bytes
		/// <para xml:lang="es">
		/// Carga una imagen desde un arreglo de bytes
		/// </para>
		/// </summary>
		public void LoadFromBytes(byte[] bytes)
		{
			Invoke(nameof(LoadFromBytes), bytes);
		}
	}
}