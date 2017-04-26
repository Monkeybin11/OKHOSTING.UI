using System;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Remote.Client.Controls
{
	/// <summary>
	/// It is a control that represents a calendar
	/// <para xml:lang="es">Es un control que representa un calendario</para>
	/// </summary>
	public class Calendar : TextControl, ICalendar
	{
		/// <summary>
		/// Gets or sets the OKHOSTING . user interface . controls. II nput control< system. date time?>. value.
		/// </summary>
		/// <value>The OKHOSTING . user interface . controls. II nput control< system. date time?>. value.</value>
		DateTime? IInputControl<DateTime?>.Value
		{
			get;
			set;
		}

		/// <summary>
		/// Occurs when value changed.
		/// </summary>
		public event EventHandler<DateTime?> ValueChanged;
	}
}