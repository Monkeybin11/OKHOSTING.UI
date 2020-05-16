using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// A field for boolean values
	/// <para xml:lang="es">Un campo para valores boleanos</para>
	/// </summary>
	public class CheckBoxBoolEditor : Editor<ICheckBox, bool>
	{
		/// <summary>
		/// Actually gets the value out of the editor Control
		/// </summary>
		/// <returns></returns>
		protected override object GetValue()
		{
			return Control.Value;
		}

		/// <summary>
		/// Sets the editor control with the given value
		/// </summary>
		protected override void SetValue(object value)
		{
			Control.Value = (bool) value;
		}
	}
}