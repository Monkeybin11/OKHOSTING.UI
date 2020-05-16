using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// A field for selecting a date
	/// <para xml:lang="es">Un campo para seleccionar una fecha.</para>
	/// </summary>
	public class TimeSpanEditor : Editor<IFlow, TimeSpan?>
	{
		public readonly ITextBox txtValue;
		public readonly IListPicker lstUnit;

		/// <summary>
		/// Creates the controls for displaying the field
		/// <para xml:lang="es">
		/// Crea los controles para visualizar el campo.
		/// </para>
		/// </summary>
		public TimeSpanEditor()
		{
			txtValue = Core.BaitAndSwitch.Create<ITextBox>();
			txtValue.InputType = ITextBoxInputType.Number;
			txtValue.Value = "0";
			
			lstUnit = Core.BaitAndSwitch.Create<IListPicker>();
			lstUnit.Items = new List<string>();

			foreach (Enum unit in Enum.GetValues(typeof(Core.TimeUnit.Unit)))
			{
				lstUnit.Items.Add(Translator.Translate(unit));
			}

			Control.Children.Add(txtValue);
			Control.Children.Add(lstUnit);
		}


		/// <summary>
		/// Gets the is valid.
		/// <para xml:lang="es">Determina si el formato del dato es valido.</para>
		/// </summary>
		/// <value>The is valid.</value>
		public override bool IsValid
		{
			get
			{
				return base.IsValid && int.TryParse(txtValue.Value, out _);
			}
		}

		/// <summary>
		/// Actually gets the value out of the editor Control
		/// </summary>
		/// <returns></returns>
		protected override object GetValue()
		{
			if (string.IsNullOrWhiteSpace(txtValue.Value))
			{
				return null;
			}

			double lenght;

			if (double.TryParse(txtValue.Value, out lenght))
			{
				Core.TimeUnit.Unit unit = (Core.TimeUnit.Unit)Translator.DeTranslate(lstUnit.Value, typeof(Core.TimeUnit.Unit));

				switch (unit)
				{
					case Core.TimeUnit.Unit.Second:
						return TimeSpan.FromSeconds(lenght);

					case Core.TimeUnit.Unit.Minute:
						return TimeSpan.FromMinutes(lenght);

					case Core.TimeUnit.Unit.Hour:
						return TimeSpan.FromHours(lenght);

					case Core.TimeUnit.Unit.Day:
						return TimeSpan.FromDays(lenght);

					case Core.TimeUnit.Unit.Week:
						return TimeSpan.FromDays(lenght * 7);

					case Core.TimeUnit.Unit.Month:
						return TimeSpan.FromDays(lenght * 30);

					case Core.TimeUnit.Unit.Year:
						return TimeSpan.FromDays(lenght * 365);

					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Sets the editor control with the given value
		/// </summary>
		protected override void SetValue(object value)
		{
			if (value == null)
			{
				txtValue.Value = string.Empty;
			}
			else
			{
				TimeSpan val = (TimeSpan)value;

				if (val.Hours == 0 && val.Minutes == 0 && val.Seconds == 0)
				{
					if (val.TotalDays % 365 == 0)
					{
						txtValue.Value = ((int)(val.TotalDays / 365)).ToString();
						lstUnit.Value = Translator.Translate(Core.TimeUnit.Unit.Year);
					}
					else if (val.TotalDays % 30 == 0)
					{
						txtValue.Value = ((int)(val.TotalDays / 30)).ToString();
						lstUnit.Value = Translator.Translate(Core.TimeUnit.Unit.Month);
					}
					else if (val.TotalDays % 7 == 0)
					{
						txtValue.Value = ((int)(val.TotalDays / 7)).ToString();
						lstUnit.Value = Translator.Translate(Core.TimeUnit.Unit.Week);
					}
					else
					{
						txtValue.Value = val.TotalDays.ToString();
						lstUnit.Value = Translator.Translate(Core.TimeUnit.Unit.Day);
					}
				}
				else if (val.Minutes == 0 && val.Seconds == 0)
				{
					txtValue.Value = val.TotalHours.ToString();
					lstUnit.Value = Translator.Translate(Core.TimeUnit.Unit.Hour);
				}
				else if (val.Seconds == 0)
				{
					txtValue.Value = val.TotalMinutes.ToString();
					lstUnit.Value = Translator.Translate(Core.TimeUnit.Unit.Minute);
				}
				else
				{
					txtValue.Value = val.TotalSeconds.ToString();
					lstUnit.Value = Translator.Translate(Core.TimeUnit.Unit.Second);
				}
			}
		}
	}
}