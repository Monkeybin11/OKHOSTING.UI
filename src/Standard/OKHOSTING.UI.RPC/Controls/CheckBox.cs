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

		private event EventHandler<bool> _ValueChanged;

		public event EventHandler<bool> ValueChanged
		{
			add
			{
				_ValueChanged += value;
			}
			remove
			{
				_ValueChanged -= value;
			}
		}

		public void OnValueChanged(bool e)
		{
			_ValueChanged?.Invoke(this, e);
		}
	}
}