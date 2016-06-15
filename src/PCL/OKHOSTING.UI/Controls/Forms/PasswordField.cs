using System;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// Field for string values
	/// <para xml:lang="es">
	/// Un campo para valores de cadena.
	/// </para>
	/// </summary>
	public class PasswordField : FormField
	{
		/// <summary>
		/// Gets or sets the value control.
		/// <para xml:lang="es">
		/// Obtiene o establece el valor del control.
		/// </para>
		/// </summary>
		public new IPasswordTextBox ValueControl
		{
			get
			{
				return (IPasswordTextBox) base.ValueControl;
			}
			protected set
			{
				base.ValueControl = value;
			}
		}

		/// <summary>
		/// Gets or sets the value.
		/// <para xml:lang="es">
		/// Obtiene o establece el valor del campo.
		/// </para>
		/// </summary>
		/// <value>The value.</value>
		public override object Value
		{
			get
			{
				return ValueControl.Value;
			}
			set
			{
				ValueControl.Value = (string) value;
			}
		}

		/// <summary>
		/// Gets the type of the value.
		/// <para xml:lang="es">
		/// Obtiene el tipo del valor.
		/// </para>
		/// </summary>
		public override Type ValueType
		{
			get
			{
				return typeof(string);
			}
		}
		
		/// <summary>
		/// Creates the controls for displaying the field
		/// <para xml:lang="es">Crea los controles para visualizar el campo.</para>
		/// </summary>
		protected override void CreateValueControl()
		{
			ValueControl = Platform.Current.Create<IPasswordTextBox>();
		}
	}
}