using System;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// Password text box.
	/// <para xml:lang="es">
	/// Es un cuadro de texto que visiblemente enmascara la entrada del usuario.
	/// </para>
	/// </summary>
	public interface IPasswordTextBox: ITextControl, IInputControl<string>
	{
	}
}