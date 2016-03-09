namespace OKHOSTING.UI.Controls
{
	public interface IImage: IControl
	{
		/// <summary>
		/// Loads the image from a Url
		/// </summary>
		void LoadFromUrl(System.Uri url);

		void LoadFromFile(string filePath);

		void LoadFromStream(System.IO.Stream stream);
    }
}