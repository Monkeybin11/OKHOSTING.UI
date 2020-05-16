using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// A field for selecting a date
	/// <para xml:lang="es">Un campo para seleccionar una fecha.</para>
	/// </summary>
	public class DateEditor : Editor<IDatePicker, DateTime?>
	{
		/// <summary>
		/// Format used to show and retrieve date value
		/// <para xml:lang="es">Formato utilizado para mostrar y recuperar datos de valor.</para>
		/// </summary>
		public string Format { get; set; }

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
			Control.Value = (DateTime?) value;
		}
	}
}