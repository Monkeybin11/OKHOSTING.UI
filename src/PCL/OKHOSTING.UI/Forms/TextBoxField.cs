using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Forms
{
	/// <summary>
	/// Base class for all fields that uses a single TextBox as ValueControl
	/// <para xml:lang="es">
	/// La clase base para todos los campos que utilizan un unico cuadro de texto como un control de valores.
	/// </para>
	/// </summary>
	public abstract class TextBoxField : FormField
	{
		/// <summary>
		/// Control that parses the value to web
		/// <para xml:lang="es">
		/// Control que convierte el valor a web.
		/// </para>
		/// </summary>
		protected new ITextBox ValueControl
		{
			get
			{
				return (ITextBox) base.ValueControl;
			}
			set
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
		/// Creates the controls for displaying the field
		/// <para xml:lang="es">
		/// Crea los controles para visualizar el campo.
		/// </para>
		/// </summary>
		protected override void CreateValueControl()
		{
			//create a sinple TextBox
			ValueControl = Platform.Current.Create<ITextBox>();
		}
	}
}