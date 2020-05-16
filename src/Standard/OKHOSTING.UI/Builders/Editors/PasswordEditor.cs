namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// Field for string values
	/// <para xml:lang="es">
	/// Un campo para valores de cadena.
	/// </para>
	/// </summary>
	public class PasswordEditor : Editor<Controls.IPasswordTextBox, string>
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
			Control.Value = (string) value;
		}
	}
}