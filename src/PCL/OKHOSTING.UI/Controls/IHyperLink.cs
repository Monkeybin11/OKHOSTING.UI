namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// An hyperlink that will redirect you to any web URL
	/// </summary>
	public interface IHyperLink: IControl
	{
		string Text { get; set; }
		System.Uri Uri { get; set; }
	}
}