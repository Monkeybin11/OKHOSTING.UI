using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Forms
{
	/// <summary>
	/// A field for decimal values
	/// <para xml:lang="es">Un campo para valores decimales.</para>
	/// </summary>
	public class DecimalField : TextBoxField
	{
		public DecimalField(Form form) : base(form)
		{
		}

		/// <summary>
		/// Gets or sets the value.
		/// <para xml:lang="es">Obtiene o establece el valor.</para>
		/// </summary>
		public override object Value
		{
			get
			{
				if (string.IsNullOrWhiteSpace(ValueControl.Value))
				{
					return 0M;
				}
				else
				{
					return decimal.Parse(ValueControl.Value);
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
					ValueControl.Value = (Convert.ToDecimal(value)).ToString();
				}
			}
		}

		/// <summary>
		/// Gets the type of the value.
		/// <para xml:lang="es">Obtiene o establece el tipo del valor.</para>
		/// </summary>
		public override Type ValueType
		{
			get
			{
				return typeof(decimal);
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

			ValueControl.InputType = ITextBoxInputType.Number;
		}

		/// <summary>
		/// Gets the is valid.
		/// <para xml:lang="es">Determina si es valido el formato del dato.</para>
		/// </summary>
		public override bool IsValid
		{
			get
			{
				decimal test;
				return base.IsValid && decimal.TryParse(ValueControl.Value, out test);
			}
		}
	}
}