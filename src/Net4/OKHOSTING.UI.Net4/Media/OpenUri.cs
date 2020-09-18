namespace OKHOSTING.UI.Net4.Media
{
	public class OpenFile : UI.Media.IOpenFile
	{
		/// <summary>
		/// Opens a file locally
		/// </summary>
		public void Open(string fullPath)
		{
			System.Diagnostics.Process.Start(fullPath);
		}
	}
}