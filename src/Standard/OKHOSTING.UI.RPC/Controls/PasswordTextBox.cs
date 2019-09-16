using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// Password text box.
	/// <para xml:lang="es">
	/// Es un cuadro de texto que visiblemente enmascara la entrada del usuario.
	/// </para>
	/// </summary>
	public class PasswordTextBox : Control, IInputControl<string>
	{
		public string Value
		{
			get
			{
				return (string) Get(nameof(Value));
			}
			set
			{
				Set(nameof(Value), value);
			}
		}

		public event EventHandler<string> ValueChanged
		{
			add
			{
				AddHybridEventHandler(nameof(ValueChanged), value);
			}
			remove
			{
				RemoveHybridEventHandler(nameof(ValueChanged), value);
			}
		}
	}
}