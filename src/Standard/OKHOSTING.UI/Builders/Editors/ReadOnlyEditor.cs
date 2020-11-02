namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// A read-only field
	/// <para xml:lang="es">Un campo de solo lectura.</para>
	/// </summary>
	public class ReadOnlyEditor : Editor<Controls.ILabel, string>
	{
		public ReadOnlyEditor()
		{ 
		}

		public ReadOnlyEditor(string value)
		{
			SetValue(value);
		}

		/// <summary>
		/// Actually gets the value out of the editor Control
		/// </summary>
		/// <returns></returns>
		protected override object GetValue()
		{
			return Control.Text;
		}

		/// <summary>
		/// Sets the editor control with the given value
		/// </summary>
		protected override void SetValue(object value)
		{
			Control.Text = value?.ToString();
		}
	}
}