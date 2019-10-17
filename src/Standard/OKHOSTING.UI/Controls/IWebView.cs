namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// Shows the content of a web page
	/// </summary>
	public interface IWebView: IControl
	{
		/// <summary>
		/// Source of the content to show
		/// </summary>
		System.Uri Source { get; set; }
	}
}