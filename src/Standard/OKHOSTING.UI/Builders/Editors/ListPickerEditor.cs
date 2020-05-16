using OKHOSTING.UI.Controls;
using System.Collections.Generic;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// Base class for all fields that uses a single ListPicker as Content
	/// <para xml:lang="es">La clase base para todos los campos que utilizan un solo ListPicker como control de valores.</para>
	/// </summary>
	public abstract class ListPickerEditor<TValue> : Editor<IListPicker, TValue>
	{
		/// <summary>
		/// Creates the controls for displaying the field
		/// <para xml:lang="es">Crea los controles para visualizar el campo.</para>
		/// </summary>
		public ListPickerEditor()
		{
			Control.Items = new List<string>();

			//Add null value to DropDwonList if not required
			if (!Required)
			{
				Control.Items.Insert(0, Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue);
			}
		}
	}
}