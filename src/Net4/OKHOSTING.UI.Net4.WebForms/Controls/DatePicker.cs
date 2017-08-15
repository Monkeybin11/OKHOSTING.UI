using System;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// It is a control that represents a calendar
	/// <para xml:lang="es">Es un control que representa un calendario</para>
	/// </summary>
	public class DatePicker : TextBoxBase, IDatePicker
	{
		public DatePicker()
		{
			base.Attributes["type"] = "date";
		}

		#region IInputControl

		/// <summary>
		/// Gets or sets the OKHOSTING . user interface . controls. II nput control< system. date time?>. value.
		/// </summary>
		/// <value>The OKHOSTING . user interface . controls. II nput control< system. date time?>. value.</value>
		DateTime? IInputControl<DateTime?>.Value
		{
			get
			{
				DateTime val;

				if (DateTime.TryParse(base.Text, out val))
				{
					return val;
				}
				else
				{
					return null;
				}
			}
			set
			{
				if (value.HasValue)
				{
					base.Text = value.Value.ToString();
				}
			}
		}

		/// <summary>
		/// Occurs when value changed.
		/// </summary>
		public event EventHandler<DateTime?> ValueChanged;

		/// <summary>
		/// Raises the value changed.
		/// </summary>
		/// <returns>The value changed.</returns>
		protected internal void RaiseValueChanged()
		{
			ValueChanged?.Invoke(this, ((IInputControl<DateTime?>) this).Value);
		}

		#endregion
	}
}