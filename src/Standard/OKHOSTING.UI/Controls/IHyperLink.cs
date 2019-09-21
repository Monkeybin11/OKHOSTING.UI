namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// An hyperlink that will redirect you to any web URL
	/// <para xml:lang="es">
	/// Un hipervinculo que te redirige a cualquier URL Web.
	/// </para>
	/// </summary>
	public interface IHyperLink: ITextControl
	{
		string Text { get; set; }
		System.Uri Uri { get; set; }
	}
}