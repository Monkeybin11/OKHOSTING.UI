using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Remote.Controls
{
	/// <summary>
	/// Label.
	/// <para xml:lang="es">
	/// Una etiqueta de texto.
	/// </para>
	/// </summary>
	public class Label: TextControl, ILabel
	{
		public string Text { get; set; }
	}
}
