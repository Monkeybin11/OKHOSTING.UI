using System;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// It is a control that represents a ImageButton in a Xamarin.Forms.
	/// <para xml:lang="es">
	/// Es un control que representa un boton con una imagen en un Xamarin.Forms.
	/// </para>
	/// </summary>
	public class ImageButton : Image, IImageButton
	{
		/// <summary>
		/// Initializes a new instance of the ImageButton class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase ImageButton.
		/// </para>
		/// </summary>
		public ImageButton()
		{
			var profileTapRecognizer = new global::Xamarin.Forms.TapGestureRecognizer
			{
				Command = new global::Xamarin.Forms.Command(() => 
				{
					Click?.Invoke(this, new EventArgs());
				}),
				NumberOfTapsRequired = 1
			};

			base.GestureRecognizers.Add(profileTapRecognizer);
		}

		/// <summary>
		/// Occurs when click.
		/// <para xml:lang="es">
		/// Ocurre cuando haces clic al boton.
		/// </para>
		/// </summary>
		public event EventHandler Click;
	}
}
