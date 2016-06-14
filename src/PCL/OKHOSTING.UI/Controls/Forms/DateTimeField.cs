using System;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A field for selecting a date and time
	/// <para xml:lang="es">Un campo para la seleccion de una fecha y hora.</para>
	/// </summary>
	public class DateTimeField : DateField
	{
		/// <summary>
		/// Initializes a new instance of the DateTimeField class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase DateTimeField y su formato.</para>
		/// </summary>
		public DateTimeField()
		{
			Format = "yyyy/MM/dd hh:mm";
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