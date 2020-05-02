using System;

namespace OKHOSTING.UI.Controllers.Forms
{
	/// <summary>
	/// Field for enum values
	/// <para xml:lang="es">Campo para valores de enumeracion.</para>
	/// </summary>
	public class EnumField : ListPickerField
	{
		/// <summary>
		/// Initializes a new instance of the EnumField class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase EnumField.</para>
		/// </summary>
		/// <param name="enumType">Enum type.
		/// <para xml:lang="es">Tipo de la enumeracion.</para>
		/// </param>
		public EnumField(Form form, Type enumType): base(form)
		{
			EnumType = enumType;
		}

		/// <summary>
		/// Gets or sets the value.
		/// <para xml:lang="es">Obtiene o establece el valor.</para>
		/// </summary>
		/// <value>The value.</value>
		public override object Value
		{
			get
			{
				if (ValueControl.Value == Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue)
				{
					return null;
				}
				else
				{
					try
					{
						return Enum.Parse(EnumType, ValueControl.Value);
					}
					catch
					{
						return null;
					}
				}
			}
			set
			{
				if (value == null && !Required)
				{
					ValueControl.Value = Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue;
				}
				else
				{
					ValueControl.Value = value.ToString();
				}
			}
		}

		/// <summary>
		/// The type of the enum.
		/// <para xml:lang="es">El tipo de la enumeracion.</para>
		/// </summary>
		protected readonly Type EnumType;

		public override Type ValueType
		{
			get
			{
				return EnumType;
			}
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// <para xml:lang="es">Crea los controles para visualizar el campo.</para>
		/// </summary>
		protected override void CreateValueControl()
		{
			//create listpicker and add empty value if not required
			base.CreateValueControl();

			//add every enum value
			foreach (System.Enum e in System.Enum.GetValues(ValueType))
			{
				//add item
				//ValueControl.Items.Add(Translator.Translate(e));
				ValueControl.Items.Add(e.ToString());
			}
		}
	}
}