namespace OKHOSTING.UI.Builders.Editors
{
	public class LongStringEditor : TextAreaEditor<string>
	{
		protected override object GetValue()
		{
			return Control.Value;
		}

		protected override void SetValue(object value)
		{
			Control.Value = value?.ToString();
		}
	}
}