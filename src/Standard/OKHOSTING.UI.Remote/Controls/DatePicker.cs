using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Remote.Controls
{
	/// <summary>
	/// A control (not necesary a calendar, it might be a textbox) for date selection
	/// <para xml:lang="es">Un calendario para seleccion de fechas.</para>
	/// </summary>
	public class DatePicker : TextControl, IDatePicker
	{
		public DateTime? Value { get; set; }

		public event EventHandler<DateTime?> ValueChanged;
	}
}