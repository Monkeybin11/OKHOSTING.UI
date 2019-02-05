namespace OKHOSTING.UI.Media
{
	/// <summary>
	/// Represents a class that can locally open a file (the file itself could be local or remote)
	/// </summary>
	public interface IOpenFile
	{
		/// <summary>
		/// Locally opens a file for the user to see or edit
		/// </summary>
		/// <param name="fullPath">Full path of the file</param>
		void Open(string fullPath);
	}
}