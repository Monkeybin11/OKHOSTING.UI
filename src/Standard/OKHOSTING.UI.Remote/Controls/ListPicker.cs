using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Remote.Controls
{
	/// <summary>
	/// List picker.
	/// <para xml:lang="es">
	/// Una lista de elementos donde el usuario puede seleccionar un elemento.
	/// </para>
	/// </summary>
	public class ListPicker: TextControl, IListPicker
	{
		public IList<string> Items { get; set; }
		public int SelectedIndex { get; set; }
		public string Value { get; set; }

		public event EventHandler<string> ValueChanged;
	}
}