using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// Field for string values
	/// <para xml:lang="es">Un campo para valores de cadena.</para>
	/// </summary>
	public class TextBoxEditor<TValue> : Editor<ITextBox, TValue>
	{
		/// <summary>
		/// A regular expression pattern used for regex validation.
		/// If set to null, no regex validation is done.
		/// <para xml:lang="es">
		/// Un patron de exprecion regular utilizada para la validacion de expreciones regulares.
		/// Si se establece en nulo, ninguna validacion de expreciones regulares se realiza.
		/// </para>
		/// </summary>
		public string RegularExpression { get; set; }

		public TextBoxEditor()
		{
		}

		public TextBoxEditor(int maxLenght)
		{
			Control.MaxLength = maxLenght;
		}

		public TextBoxEditor(int maxLenght, string regularExpression)
		{
			Control.MaxLength = maxLenght;
			RegularExpression = regularExpression;
		}

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
					return base.IsValid && new Data.Validation.RegexValidator(RegularExpression).Validate(Value) == null;
				}
			}
		}

		/// <summary>
		/// Actually gets the value out of the editor Control
		/// </summary>
		/// <returns></returns>
		protected override object GetValue()
		{
			return Data.Convert.ChangeType<TValue>(Control.Value);
		}

		/// <summary>
		/// Sets the editor control with the given value
		/// </summary>
		protected override void SetValue(object value)
		{
			Control.Value = value?.ToString();
		}
	}
}