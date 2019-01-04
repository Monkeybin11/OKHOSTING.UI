using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Remote.Controls
{
	/// <summary>
	/// Password text box.
	/// <para xml:lang="es">
	/// Es un cuadro de texto que visiblemente enmascara la entrada del usuario.
	/// </para>
	/// </summary>
	public class PasswordTextBox : Control, IInputControl<string>
	{
		public string Value { get; set; }

		public event EventHandler<string> ValueChanged;
	}
}