using OKHOSTING.UI.Controls;
namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// A field for integer values
	/// <para xml:lang="es">Un campo para valores enteros.</para>
	/// </summary>
	public class IntegerEditor : TextBoxEditor<int?>
	{
		public IntegerEditor()
		{ 
			Control.InputType = ITextBoxInputType.Number;
		}

		/// <summary>
		/// Gets the is valid.
		/// <para xml:lang="es">
		/// Determina si el valor es valido.
		/// </para>
		/// </summary>
		/// <value>The is valid.</value>
		public override bool IsValid
		{
			get
			{
				return base.IsValid && int.TryParse(Control.Value, out _);
			}
		}

		/// <summary>
		/// Actually gets the value out of the editor Control
		/// </summary>
		/// <returns></returns>
		protected override object GetValue()
		{
			if (string.IsNullOrWhiteSpace(Control.Value))
			{
				return null;
			}
			else
			{
				return int.Parse(Control.Value);
			}
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