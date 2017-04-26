using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Remote.Client.Controls
{
	/// <summary>
	/// Its a control that represents a HiperLink
	/// <para xml:lang="es">Es un control que representa un hiperlink</para>
	/// </summary>
	public class HyperLink : Label, IHyperLink
	{
		/// <summary>
		/// Gets or sets the address that will reference the hyperlink.
		/// <para xml:lang="es">Obtiene o establece la direccion a la que hara referencia el hiperlink.</para>
		/// </summary>
		public Uri Uri
		{
			get;
			set;
		}
	}
}