using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// A field for decimal values
	/// <para xml:lang="es">Un campo para valores decimales.</para>
	/// </summary>
	public class DecimalEditor : TextBoxEditor<decimal?>
	{
		public DecimalEditor()
		{
			Control.InputType = ITextBoxInputType.Number;
		}

		/// <summary>
		/// Gets the is valid.
		/// <para xml:lang="es">Determina si es valido el formato del dato.</para>
		/// </summary>
		public override bool IsValid
		{
			get
			{
				return base.IsValid && decimal.TryParse(Control.Value, out _);
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
				return decimal.Parse(Control.Value);
			}
		}

		/// <summary>
		/// Sets the editor control with the given value
		/// </summary>
		protected override void SetValue(object value)
		{
			if (value == null)
			{
				Control.Value = string.Empty;
			}
			else
			{
				Control.Value = Convert.ToDecimal(value).ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
			}
		}
	}
}