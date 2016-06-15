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

		void LoadFromFile(string filePath);

		void LoadFromStream(System.IO.Stream stream);
	}
}