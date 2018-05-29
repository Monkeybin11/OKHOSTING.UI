using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Forms
{
	/// <summary>
	/// A field for selecting a date
	/// <para xml:lang="es">Un campo para seleccionar una fecha.</para>
	/// </summary>
	public class DateField : FormField
	{
		/// <summary>
		/// Initializes a new instance of the DateField class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase DateField</para>
		/// </summary>
		public DateField()
		{
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
				return ((IDatePicker) ValueControl).Value;
			}
			set
			{
				((IDatePicker) ValueControl).Value = (DateTime) value;
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
			ValueControl = Platform.Create<IDatePicker>();
		}
	}
}