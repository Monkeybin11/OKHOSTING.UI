using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// An hyperlink that will redirect you to any web URL
	/// <para xml:lang="es">
	/// Un hipervinculo que te redirige a cualquier URL Web.
	/// </para>
	/// </summary>
	public class HyperLink: TextControl, IHyperLink
	{
		public string Text { get; set; }
		public System.Uri Uri { get; set; }
	}
}