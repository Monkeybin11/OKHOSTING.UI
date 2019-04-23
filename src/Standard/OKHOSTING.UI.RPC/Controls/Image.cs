namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// Image.
	/// <para xml:lang="es">Una imagen a mostrar.</para>
	/// </summary>
	public class Image: Control
	{
		/// <summary>
		/// Loads the image from a Url
		/// <para xml:lang="es">
		/// Carga la imagen desde un Url.
		/// </para>
		/// </summary>
		void LoadFromUrl(System.Uri url)
		{
			base.Invoke(nameof(LoadFromUrl), new[] { url });
		}

		/// <summary>
		/// Loads the image from a local file
		/// <para xml:lang="es">
		/// Carga la imagen desde un archivo local
		/// </para>
		/// </summary>
		void LoadFromFile(string filePath)
		{
			base.Invoke(nameof(LoadFromFile), new[] { filePath });
		}

		/// <summary>
		/// Loads the image from a stream
		/// <para xml:lang="es">
		/// Carga la imagen desde un stream
		/// </para>
		/// </summary>
		void LoadFromStream(System.IO.Stream stream)
		{
			base.Invoke(nameof(LoadFromStream), new[] { stream });
		}
	}
}