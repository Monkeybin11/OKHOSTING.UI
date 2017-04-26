using System;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Remote.Client.Controls
{
	/// <summary>
	/// It is a control that represents a button.
	/// <para xml:lang="es">Es un control que representa un boton</para>
	/// </summary>
	public class Button : TextControl, IButton
	{
		public string Text
		{
			get;
			set;
		}

		/// <summary>
		/// Occurs when click.
		/// <para xml:lang="es">Ocurre cuando hay un evento clic de un boton.</para>
		/// </summary>
		public event EventHandler Click;
	}
}