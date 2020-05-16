using OKHOSTING.UI.Controls;
using System.Collections.Generic;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// A field for boolean values
	/// <para xml:lang="es">Un campo para valores boleanos</para>
	/// </summary>
	public class ListPickerBoolEditor : Editor<IListPicker, bool?>
	{
		public ListPickerBoolEditor()
		{
			Control.Items = new List<string>();
			Control.Items.Add(Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue);
			Control.Items.Add(Resources.Strings.OKHOSTING_UI_Controls_Forms_BoolField_True);
			Control.Items.Add(Resources.Strings.OKHOSTING_UI_Controls_Forms_BoolField_False);
		}

		/// <summary>
		/// Actually gets the value out of the editor Control
		/// </summary>
		/// <returns></returns>
		protected override object GetValue()
		{
			string val = Control.Value;

			if (string.IsNullOrWhiteSpace(val) || val == Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue)
			{
				return null;
			}
			else
			{
				return bool.Parse(val);
			}
		}

		/// <summary>
		/// Sets the editor control with the given value
		/// </summary>
		protected override void SetValue(object value)
		{
			if (value == null)
			{
				Control.Value = Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue;
			}
			else
			{
				Control.Value = ((bool) value).ToString();
			}
		}
	}
}