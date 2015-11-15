namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// An hyperlink that will redirect you to any web URL
	/// </summary>
	public interface IHyperLink: IControl
	{
		System.Uri Uri { get; set; }
	}
}