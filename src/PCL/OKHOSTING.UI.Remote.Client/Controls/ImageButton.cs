using System;
using System.Linq;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Remote.Client.Controls
{
	/// <summary>It represents a button with a background image
	/// <para xml:lang="es">Representa un boton con una imagen de fondo</para>
	/// </summary>
	public class ImageButton : Image, IImageButton
	{
		/// <summary>
		/// Occurs when click.
		/// <para xml:lang="es">Se produce este evento al hacer clic en el control.</para>
		/// </summary>
		public event EventHandler Click;
	}
}
