using System;

namespace OKHOSTING.UI.Net4.Media
{
	public class OpenUri : UI.Media.IOpenUri
	{
		/// <summary>
		/// Opens a file locally
		/// </summary>
		public void Open(Uri uri)
		{
			System.Diagnostics.Process.Start(uri.ToString());
		}
	}
}