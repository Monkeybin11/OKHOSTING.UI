using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// List picker.
	/// <para xml:lang="es">
	/// Una lista de elementos donde el usuario puede seleccionar un elemento.
	/// </para>
	/// </summary>
	public class ListPicker: TextControl, IListPicker
	{
		public IList<string> Items
		{
			get
			{
				return (IList<string>) Get(nameof(Items));
			}
			set
			{
				Set(nameof(Items), value);
			}
		}

		public int SelectedIndex
		{
			get
			{
				return (int)Get (nameof(SelectedIndex));
			}
			set
			{
				Set(nameof(SelectedIndex), value);
			}
		}

		public string Value
		{
			get
			{
				return (string) Get(nameof(Value));
			}
			set
			{
				Set(nameof(Value), value);
			}
		}

		public event EventHandler<string> ValueChanged;
	}
}