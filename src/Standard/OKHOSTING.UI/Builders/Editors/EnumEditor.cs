using System;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// Field for enum values
	/// <para xml:lang="es">Campo para valores de enumeracion.</para>
	/// </summary>
	public class EnumEditor : ListPickerEditor<Enum>
	{
		/// <summary>
		/// Initializes a new instance of the EnumField class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase EnumField.</para>
		/// </summary>
		/// <param name="enumType">Enum type.
		/// <para xml:lang="es">Tipo de la enumeracion.</para>
		/// </param>
		public EnumEditor(Type enumType)
		{
			EnumType = enumType;

			//add items
			foreach (Enum e in Enum.GetValues(EnumType))
			{
				//Content.Items.Add(Translator.Translate(e));
				Control.Items.Add(e.ToString());
			}
		}

		/// <summary>
		/// The type of the enum.
		/// <para xml:lang="es">El tipo de la enumeracion.</para>
		/// </summary>
		protected readonly Type EnumType;

		/// <summary>
		/// Actually gets the value out of the editor Control
		/// </summary>
		/// <returns></returns>
		protected override object GetValue()
		{
			if (Control.Value == Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue)
			{
				return null;
			}
			else
			{
				try
				{
					return (Enum)Enum.Parse(EnumType, Control.Value);
				}
				catch
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Sets the editor control with the given value
		/// </summary>
		protected override void SetValue(object value)
		{
			if (value == null && !Required)
			{
				Control.Value = Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue;
			}
			else
			{
				Control.Value = value.ToString();
			}
		}
	}
}