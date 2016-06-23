using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// It is a control that represents a LabelButton in a Xamarin.Forms.
	/// <para xml:lang="es">
	/// Es un control que representa un boton simple con una etiqueta de texto en un Xamarin.Forms.
	/// </para>
	/// </summary>
	public class LabelButton : Label, ILabelButton
	{
		/// <summary>
		/// Initializes a new instance of the LabelButton class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la calse LabelButton.
		/// </para>
		/// </summary>
		public LabelButton()
		{
			base.GestureRecognizers.Add(new global::Xamarin.Forms.TapGestureRecognizer
			{
				Command = new global::Xamarin.Forms.Command(() => OnLabelClicked()),
			});
		}

		/// <summary>
		/// Ons the label clicked.
		/// <para xml:lang="es">
		/// Lanza un evento al hacer clic en el labelbutton
		/// </para>
		/// </summary>
		/// <returns>The label clicked.</returns>
		private void OnLabelClicked()
		{
			if (Click != null)
			{
				Click(this, new EventArgs());
			}
		}

		/// <summary>
		/// Occurs when click.
		/// <para xml:lang="es">
		/// Ocurre cuando haces clic en el labelbutton.
		/// </para>
		/// </summary>
		public event EventHandler Click;
	}
}