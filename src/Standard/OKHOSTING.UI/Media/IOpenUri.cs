using System;

namespace OKHOSTING.UI.Media
{
	/// <summary>
	/// Represents a class that can locally open an URI in the default browser
	/// </summary>
	public interface IOpenUri
	{
		/// <summary>
		/// Locally opens a URI in the default browser
		/// </summary>
		void Open(Uri uri);
	}
}