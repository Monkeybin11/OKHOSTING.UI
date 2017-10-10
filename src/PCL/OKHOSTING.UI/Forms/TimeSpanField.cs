using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Forms
{
	/// <summary>
	/// A field for selecting a date
	/// <para xml:lang="es">Un campo para seleccionar una fecha.</para>
	/// </summary>
	public class TimeSpanField : FormField
	{
		protected ITextBox txtValue;
		protected IListPicker lstUnit;

		/// <summary>
		/// Control that parses the value to web
		/// <para xml:lang="es">
		/// Control que convierte el valor a web.
		/// </para>
		/// </summary>
		protected new IFlow ValueControl
		{
			get
			{
				return (IFlow) base.ValueControl;
			}
			set
			{
				base.ValueControl = value;
			}
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// <para xml:lang="es">
		/// Crea los controles para visualizar el campo.
		/// </para>
		/// </summary>
		protected override void CreateValueControl()
		{
			//create a sinple TextBox
			ValueControl = Platform.Current.Create<IFlow>();
			
			txtValue = Platform.Current.Create<ITextBox>();
			txtValue.InputType = ITextBoxInputType.Number;
			txtValue.Value = "0";
			
			lstUnit = Platform.Current.Create<IListPicker>();
			lstUnit.Items = new List<string>();

			foreach (Enum unit in Enum.GetValues(typeof(Core.TimeUnit.Unit)))
			{
				lstUnit.Items.Add(Translator.Translate(unit));
			}

			ValueControl.Children.Add(txtValue);
			ValueControl.Children.Add(lstUnit);
		}

		/// <summary>
		/// Gets or sets the value.
		/// <para xml:lang="es">Obtiene o establece el valor del campo.</para>
		/// </summary>
		/// <value>The value.</value>
		public override object Value
		{
			get
			{
				if (string.IsNullOrWhiteSpace(txtValue.Value))
				{
					return null;
				}

				double lenght;
				
				if(double.TryParse(txtValue.Value, out lenght))
				{
					Core.TimeUnit.Unit unit = (Core.TimeUnit.Unit) Translator.DeTranslate(lstUnit.Value, typeof(Core.TimeUnit.Unit));

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
			set
			{
				if (value == null)
				{
					txtValue.Value = string.Empty;
				}
				else
				{
					TimeSpan val = (TimeSpan) value;

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

		/// <summary>
		/// Gets the type of the value.
		/// <para xml:lang="es">Obtiene o establece el tipo del valor</para>
		/// </summary>
		/// <value>The type of the value.</value>
		public override Type ValueType
		{
			get
			{
				return typeof(TimeSpan);
			}
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
				int test;
				return base.IsValid && int.TryParse(txtValue.Value, out test);
			}
		}
	}
}