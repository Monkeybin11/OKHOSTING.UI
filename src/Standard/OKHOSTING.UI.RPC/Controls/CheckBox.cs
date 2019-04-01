using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// A ckeckbox to select one or more options.
	/// <para xml:lang="es">Un ckeckbox para seleccionar una o mas opciones.</para>
	/// </summary>
	public class CheckBox : Control, ICheckBox
	{
		public bool Value
		{
			get;
			set;
		}

		public event EventHandler<bool> ValueChanged;


		#region IWebInputControl

		bool IWebInputControl.HandlePostBack()
		{
			string postedValue = Page.Request.Form[ID];
			bool value = postedValue == "on";

			if (value != ((ICheckBox)this).Value)
			{
				((ICheckBox)this).Value = value;
				return true;
			}
			else
			{
				return false;
			}
		}

		void IWebInputControl.RaiseValueChanged()
		{
			ValueChanged?.Invoke(this, ((ICheckBox)this).Value);
		}

		#endregion
	}
}