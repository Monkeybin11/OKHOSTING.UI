using System;
using System.Linq;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Remote.Client.Controls
{
	/// <summary>
	/// It represents a control where the user can click and select a value from a list of options
	/// <para xml:lang="es">Representa un control donde el usuario puede dar clic y seleccionar un valor de una lista de opciones</para>
	/// </summary>
	public class ListPicker : TextControl, IListPicker
	{
		public IList<string> Items
		{
			get;
			set;
		}

		public int SelectedIndex
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the value of the user input
		/// <para xml:lang="es">Obtiene o establece el valor de la entrada del usuario</para>
		/// </summary>
		/// <value>The value of the user imput.
		/// <para xml:lang="es">El valor de la entrada del usuario.</para>
		/// </value>
		public string Value
		{
			get;
			set;
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">Ocurre cuando es cambiado el valor.</para>
		/// </summary>
		public event EventHandler<string> ValueChanged;
	}
}