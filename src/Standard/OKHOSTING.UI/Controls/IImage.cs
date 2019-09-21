namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// Image.
	/// <para xml:lang="es">Una imagen a mostrar.</para>
	/// </summary>
	public interface IImage: IControl
	{
		/// <summary>
		/// Loads the image from a Url
		/// <para xml:lang="es">
		/// Carga la imagen desde un Url.
		/// </para>
		/// </summary>
		void LoadFromUrl(System.Uri url);

		/// <summary>
		/// Loads the image from a local file
		/// <para xml:lang="es">
		/// Carga la imagen desde un archivo local
		/// </para>
		/// </summary>
		void LoadFromFile(string filePath);

		/// <summary>
		/// Loads the image from a stream
		/// <para xml:lang="es">
		/// Carga la imagen desde un stream
		/// </para>
		/// </summary>
		void LoadFromStream(System.IO.Stream stream);

		/// <summary>
		/// Loads the image from an array of bytes
		/// <para xml:lang="es">
		/// Carga la imagen desde un arreglo de bytes
		/// </para>
		/// </summary>
		void LoadFromBytes(byte[] bytes);
	}
}