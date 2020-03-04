using OKHOSTING.UI.Media;
using OKHOSTING.UI.RPC.Controls;

namespace OKHOSTING.UI.RPC.Media
{
	/// <summary>
	/// Represents a class that can locally open a file (the file itself could be local or remote)
	/// </summary>
	public class OpenFile : Control, IOpenFile
	{
		/// <summary>
		/// Locally opens a file for the user to see or edit
		/// </summary>
		/// <param name="fullPath">Full path of the file</param>
		public void Open(string fullPath)
		{
			Invoke(nameof(Open), fullPath);
		}
	}
}