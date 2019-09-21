using System;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A control (not necesary a calendar, it might be a textbox) for date selection
	/// <para xml:lang="es">Un calendario para seleccion de fechas.</para>
	/// </summary>
	public interface IDatePicker: ITextControl, IInputControl<DateTime?>
	{
	}
}