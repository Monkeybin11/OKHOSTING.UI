using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Forms
{
	/// <summary>
	/// A field for integer values
	/// <para xml:lang="es">Un campo para valores enteros.</para>
	/// </summary>
	public class IntegerField : TextBoxField
	{
		public IntegerField(Form form) : base(form)
		{
		}

		/// <summary>
		/// Gets or sets the value.
		/// <para xml:lang="es">
		/// Obtiene o establece el valor del campo.
		/// </para>
		/// </summary>
		public override object Value
		{
			get
			{
				if (string.IsNullOrWhiteSpace(ValueControl.Value))
				{
					return null;
				}
				else
				{
					return int.Parse(ValueControl.Value);
				}
			}
			set
			{
				if (value == null)
				{
					ValueControl.Value = null;
				}
				else
				{
					ValueControl.Value = value.ToString();
				}
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
				return typeof(int);
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
			base.CreateValueControl();
			ValueControl.InputType = ITextBoxInputType.Number;
		}

		/// <summary>
		/// Gets the is valid.
		/// <para xml:lang="es">
		/// Determina si el valor es valido.
		/// </para>
		/// </summary>
		/// <value>The is valid.</value>
		public override bool IsValid
		{
			get
			{
				int test;
				return base.IsValid && int.TryParse(ValueControl.Value, out test);
			}
		}
	}
}