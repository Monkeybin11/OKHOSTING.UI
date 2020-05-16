using OKHOSTING.UI.Controls;
using static OKHOSTING.Core.StringExtensions;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// Field for binary values (byte[])
	/// <para xml:lang="es">Campo para valores binarios (byte[]).</para>
	/// </summary>
	public class BinaryEditor: Editor<ITextArea, byte[]>
	{
		/// <summary>
		/// Actually gets the value out of the editor Control
		/// </summary>
		/// <returns></returns>
		protected override object GetValue()
		{
			return Control.Value.FromBase64ToBytes();
		}

		/// <summary>
		/// Sets the editor control with the given value
		/// </summary>
		protected override void SetValue(object value)
		{
			if (value == null)
			{
				Control.Value = null;
			}
			else
			{
				Control.Value = ((byte[]) value).FromBytesToBase64();
			}
		}
	}
}