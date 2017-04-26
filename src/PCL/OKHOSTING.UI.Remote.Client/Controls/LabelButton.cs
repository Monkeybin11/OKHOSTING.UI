using System;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Remote.Client.Controls
{
	/// <summary>
	/// It is a control that represents a single button with a text label
	/// <para xml:lang="es">Es un control que representa un boton sencillo con una etiqueta de texto</para>
	/// </summary>
	public class LabelButton : Label, ILabelButton
	{
		/// <summary>
		/// Occurs when click.
		/// <para xml:lang="es">Se produce cuando se hace clic en el contol.</para>
		/// </summary>
		public event EventHandler Click;
	}
}