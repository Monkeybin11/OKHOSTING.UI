using System;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A field for selecting a date
	/// <para xml:lang="es">Un campo para seleccionar una fecha.</para>
	/// </summary>
	public class DateField : TextBoxField
	{
		/// <summary>
		/// Initializes a new instance of the DateField class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase DateField</para>
		/// </summary>
		public DateField()
		{
			Format = "yyyy/MM/dd";
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
				ValueControl.Value = ((DateTime) value).ToString(Format);
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
				return typeof(DateTime);
			}
		}

		/// <summary>
		/// Format used to show and retrieve date value
		/// <para xml:lang="es">Formato utilizado para mostrar y recuperar datos de valor.</para>
		/// </summary>
		public string Format { get; set; }

		/// <summary>
		/// Creates the controls for displaying the field
		/// <para xml:lang="es">Crea los controles para visualizar el campo.</para>
		/// </summary>
		protected override void CreateValueControl()
		{
			//create date texbox from base
			base.CreateValueControl();

			ValueControl.InputType = ITextBoxInputType.Date;
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
				DateTime test;
				return base.IsValid && DateTime.TryParseExact(ValueControl.Value, Format, null, System.Globalization.DateTimeStyles.None, out test);
			}
		}
	}
}