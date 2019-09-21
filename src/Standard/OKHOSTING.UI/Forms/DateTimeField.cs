using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Forms
{
	/// <summary>
	/// A field for selecting a date and time
	/// <para xml:lang="es">Un campo para la seleccion de una fecha y hora.</para>
	/// </summary>
	public class DateTimeField : FormField
	{
		public DateTimeField(Form form) : base(form)
		{
		}

		protected IDatePicker DatePicker;
		protected ITimeOfDayPicker TimePicker;

		public override Type ValueType
		{
			get
			{
				return typeof(DateTime);
			}
		}

		public override object Value
		{
			get
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
			set
			{
				DatePicker.Value = (DateTime) value;
				TimePicker.Value = ((DateTime) value).TimeOfDay;
			}
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// <para xml:lang="es">Crea los controles para visualizar el campo.</para>
		/// </summary>
		protected override void CreateValueControl()
		{
			DatePicker = Core.BaitAndSwitch.Create<IDatePicker>();
			TimePicker = Core.BaitAndSwitch.Create<ITimeOfDayPicker>();
			var flow = Core.BaitAndSwitch.Create<Controls.Layout.IFlow>();
			flow.Children.Add(DatePicker);
			flow.Children.Add(TimePicker);

			ValueControl = flow;
		}
	}
}