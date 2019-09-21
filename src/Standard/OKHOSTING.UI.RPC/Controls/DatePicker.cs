using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// A control (not necesary a calendar, it might be a textbox) for date selection
	/// <para xml:lang="es">Un calendario para seleccion de fechas.</para>
	/// </summary>
	public class DatePicker : TextControl, IDatePicker
	{
		public DateTime? Value
		{
			get
			{
				return (DateTime?) Get(nameof(Value));
			}
			set
			{
				Set(nameof(Value), value);
			}
		}

		public event EventHandler<DateTime?> ValueChanged
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