using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// List picker.
	/// <para xml:lang="es">
	/// Una lista de elementos donde el usuario puede seleccionar un elemento.
	/// </para>
	/// </summary>
	public interface IListPicker: ITextControl, IInputControl<string>
	{
		IList<string> Items { get; set; }
		int SelectedIndex { get; set; }
	}
}