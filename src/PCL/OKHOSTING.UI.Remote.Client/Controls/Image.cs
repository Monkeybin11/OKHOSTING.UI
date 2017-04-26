using System;
using System.Linq;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Remote.Client.Controls
{
	/// <summary>
	/// It represents an image to which we can give you design through its properties.
	/// <para xml:lang="es">Representa una imagen a la cual le podemos dar diseño por medio de sus propiedades.</para>
	/// </summary>
	public class Image : Control, IImage
	{
		public byte[] Content { get; set; }
		public string File { get; set; }
		public Uri Uri { get; set; }

		/// <summary>
		/// Loads from file.
		/// <para xml:lang="es">Carga la imagen del control desde una ruta de archivo.</para>
		/// </summary>
		/// <returns>The from file.
		/// <para xml:lang="es">El archivo.</para>
		/// </returns>
		/// <param name="filePath">File path.
		/// <para xml:lang="es">La ruta del archivo.</para>
		/// </param>
		public void LoadFromFile(string filePath)
		{
			File = filePath;
		}

		public void LoadFromStream(Stream stream)
		{
			BinaryReader br = new BinaryReader(stream);
			Content = br.ReadBytes((int) stream.Length);
		}

		/// <summary>
		/// Loads from URL.
		/// <para xml:lang="es">Carga la imagen desde una direccion de internet.</para>
		/// </summary>
		/// <returns>The from URL.
		/// <para xml:lang="es">La url de la imagen</para>
		/// </returns>
		/// <param name="url">URL.</param>
		public void LoadFromUrl(System.Uri url)
		{
			Uri = url;
		}
	}
}
