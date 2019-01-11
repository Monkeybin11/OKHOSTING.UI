using System;

namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// Image button.
	/// <para xml:lang="es">
	/// Una imagen como un boton.
	/// </para>
	/// </summary>
	public class ImageButton: Image
	{
		/// <summary>
		/// Raises after the user clicked on the image
		/// <para xml:lang="es">
		/// Se lanza despues de que el usuario ha hecho clic en la imagen.
		/// </para>
		/// </summary>
		event EventHandler Click;
	}
}