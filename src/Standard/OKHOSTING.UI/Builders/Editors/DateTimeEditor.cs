using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// A field for selecting a date and time
	/// <para xml:lang="es">Un campo para la seleccion de una fecha y hora.</para>
	/// </summary>
	public class DateTimeEditor : Editor<Controls.Layout.IFlow, DateTime?>
	{
		public DateTimeEditor()
		{
			DatePicker = Core.BaitAndSwitch.Create<IDatePicker>();
			DatePicker.Width = 90;
			DatePicker.ValueChanged += (sender, e) => OnValueChanged(sender, new EventArgs());

			TimePicker = Core.BaitAndSwitch.Create<ITimeOfDayPicker>();
			TimePicker.Width = 40;
			TimePicker.ValueChanged += (sender, e) => OnValueChanged(sender, new EventArgs());

			Control.Children.Add(DatePicker);
			Control.Children.Add(TimePicker);
		}

		public IDatePicker DatePicker { get; protected set; }

		public ITimeOfDayPicker TimePicker { get; protected set; }

		/// <summary>
		/// Actually gets the value out of the editor Control
		/// </summary>
		/// <returns></returns>
		protected override object GetValue()
		{
			if (DatePicker.Value != null && TimePicker.Value != null)
			{
				return DatePicker.Value.Value.Add(TimePicker.Value.Value);
			}
			else
			{
				return DatePicker.Value;
			}
		}

		/// <summary>
		/// Sets the editor control with the given value
		/// </summary>
		protected override void SetValue(object value)
		{
			if (value == null)
			{
				DatePicker.Value = null;
				TimePicker.Value = null;
			}
			else
			{
				DatePicker.Value = (DateTime) value;
				TimePicker.Value = ((DateTime) value).TimeOfDay;
			}
		}
	}
}