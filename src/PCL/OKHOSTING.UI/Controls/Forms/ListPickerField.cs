using System.Collections.Generic;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// Base class for all fields that uses a single ListPicker as ValueControl
	/// <para xml:lang="es">La clase base para todos los campos que utilizan un solo ListPicker como control de valores.</para>
	/// </summary>
	public abstract class ListPickerField : FormField
	{
		/// <summary>
		/// Control that parses the value to web
		/// <para xml:lang="es">Control que parse el valor a web.</para>
		/// </summary>
		public new IListPicker ValueControl
		{
			get
			{
				return (IListPicker) base.ValueControl;
			}
			protected set
			{
				base.ValueControl = value;
			}
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// <para xml:lang="es">Crea los controles para visualizar el campo.</para>
		/// </summary>
		protected override void CreateValueControl()
		{
			ValueControl = Platform.Current.Create<IListPicker>();
			ValueControl.Items = new List<string>();

			//Add null value to DropDwonList if not required
			if (!Required)
			{
				ValueControl.Items.Insert(0, Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue);
			}
		}
	}
}