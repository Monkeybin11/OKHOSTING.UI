using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Forms
{
	/// <summary>
	/// Field for string values
	/// <para xml:lang="es">Un campo para valores de cadena.</para>
	/// </summary>
	public class StringField : FormField
	{
		/// <summary>
		/// Gets or sets the value control.
		/// <para xml:lang="es">Obtiene o establece el valor del control.</para>
		/// </summary>
		public new IInputControl<string> ValueControl
		{
			get
			{
				return (IInputControl<string>) base.ValueControl;
			}

			protected set
			{
				base.ValueControl = value;
			}
		}

		/// <summary>
		/// Gets or sets the value.
		/// <para xml:lang="es">Obtiene o establece el valor del campo.</para>
		/// </summary>
		public override object Value
		{
			get
			{
				return ValueControl.Value;
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
		/// <para xml:lang="es">Obtiene el tipo del valor.</para>
		/// </summary>
		public override Type ValueType
		{
			get
			{
				return typeof(string);
			}
		}
		
		/// <summary>
		/// A regular expression pattern used for regex validation.
		/// If set to null, no regex validation is done.
		/// <para xml:lang="es">
		/// Un patron de exprecion regular utilizada para la validacion de expreciones regulares.
		/// Si se establece en nulo, ninguna validacion de expreciones regulares se realiza.
		/// </para>
		/// </summary>
		public string RegularExpression { get; set; }

		/// <summary>
		/// Maximum lenght allowed for the string Value. Zero means no limit.
		/// <para xml:lang="es">
		/// El valor maximo permitido para el valor de cadena. Cero significa que no hay limite.
		/// </para>
		/// </summary>
		public int MaxLenght { get; set; }

		public override bool IsValid
		{
			get
			{
				if (string.IsNullOrWhiteSpace(RegularExpression))
				{
					return base.IsValid;
				}
				else
				{
					return base.IsValid && new OKHOSTING.Data.Validation.RegexValidator(RegularExpression).Validate(Value) == null;
				}
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
			if (MaxLenght == 0)
			{
				ValueControl = App.Create<ITextArea>();
			}
			else
			{
				ValueControl = App.Create<ITextBox>();
			}
		}
	}
}