using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// A form field that uses an autocomplete for data input
	/// <para xml:lang="es">Un campo de formulario que utiliza una función de autocompletar para la entrada de datos</para>
	/// </summary>
	public class AutocompleteEditor : Editor<IAutocomplete, string>
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
			if (value == null)
			{
				Control.Value = null;
			}
			else
			{
				Control.Value = value.ToString();
			}
		}
	}
}