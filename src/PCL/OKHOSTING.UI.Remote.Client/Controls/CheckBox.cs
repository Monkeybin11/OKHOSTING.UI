using System;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Remote.Client.Controls
{
	/// <summary>
	/// It is a control that represents a checkbox
	/// <para xml:lang="es">Es un control que representa un checkbox</para>
	/// </summary>
	public class CheckBox : TextControl, ICheckBox
	{
		/// <summary>
		/// Gets or sets the input value of the checkbox
		/// <para xml:lang="es">Obtiene o establece el valor de entrada del checkbox</para>
		/// </summary>
		/// <value>The value of the checkbox.
		/// <para xml:lang="es">El valor del checkbox</para>
		/// </value>
		public bool Value
		{
			get;
			set;
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">Se produce cuando cambia el valor</para>
		/// </summary>
		public event EventHandler<bool> ValueChanged;
	}
}