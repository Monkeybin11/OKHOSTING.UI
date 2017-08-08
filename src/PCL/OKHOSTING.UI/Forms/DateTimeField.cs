using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Forms
{
	/// <summary>
	/// A field for selecting a date and time
	/// <para xml:lang="es">Un campo para la seleccion de una fecha y hora.</para>
	/// </summary>
	public class DateTimeField : TextBoxField
	{
		const string Format = "yyyy/MM/dd hh:mm";

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
				if (string.IsNullOrWhiteSpace(ValueControl.Value))
				{
					return null;
				}

				try
				{
					return DateTime.ParseExact(ValueControl.Value, Format, System.Globalization.CultureInfo.InvariantCulture);
				}
				catch
				{
					return null;
				}
			}
			set
			{
				if (value == null)
				{
					ValueControl.Value = string.Empty;
				}
				else
				{
					ValueControl.Value = ((DateTime) value).ToString(Format);
				}
			}
		}
		/// <summary>
		/// Creates the controls for displaying the field
		/// <para xml:lang="es">Crea los controles para visualizar el campo.</para>
		/// </summary>
		protected override void CreateValueControl()
		{
			//create date texbox from base
			base.CreateValueControl();

			//adjust controls width
			ValueControl.InputType = ITextBoxInputType.DateTime;
		}
	}
}