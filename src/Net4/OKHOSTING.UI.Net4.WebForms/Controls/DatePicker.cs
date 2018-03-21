using System;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// It is a control that represents a calendar
	/// <para xml:lang="es">Es un control que representa un calendario</para>
	/// </summary>
	public class DatePicker : TextBoxBase, IDatePicker, IWebInputControl
	{
		public DatePicker()
		{
			Attributes["pattern"] = @"(0[1-9]|1[0-9]|2[0-9]|3[01]).(0[1-9]|1[012]).[0-9]{4}";
			Attributes["placeholder"] = @"dd/mm/yyyy";
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

				if (DateTime.TryParseExact(base.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.AssumeLocal, out val))
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
					base.Text = value.Value.ToString("dd/MM/yyyy");
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

		#region IWebInputControl

		bool IWebInputControl.HandlePostBack()
		{
			DateTime date = DateTime.MinValue;
			string postedValue = Page.Request.Form[ID];

			if (DateTime.TryParse(postedValue, out date) && date != ((IDatePicker) this).Value)
			{
				((IDatePicker) this).Value = date;
				return true;
			}
			else
			{
				return false;
			}
		}

		void IWebInputControl.RaiseValueChanged()
		{
			ValueChanged?.Invoke(this, ((IDatePicker) this).Value);
		}

		#endregion
	}
}