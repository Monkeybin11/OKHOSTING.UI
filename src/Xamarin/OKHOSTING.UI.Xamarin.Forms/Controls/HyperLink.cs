using System;
using System.Drawing;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// It is a control that represents a HyperLink in a Xamarin.Forms.
	/// <para xml:lang="es">
	/// Es un control que representa un HyperLink en un Xamarin.Forms.
	/// </para>
	/// </summary>
	public class HyperLink : LabelButton, IHyperLink
	{
		/// <summary>
		/// Initializes a new instance of the HyperLink class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase HyperLink.
		/// </para>
		/// </summary>
		public HyperLink()
		{
		}

		/// <summary>
		/// Hypers the link clicked.
		/// <para xml:lang="es">
		/// Reaccion al hacer clic en el enlace.
		/// </para>
		/// </summary>
		protected override void OnLabelClicked()
		{
			global::Xamarin.Forms.Device.OpenUri(((IHyperLink) this).Uri);
		}

		/// <summary>
		/// Gets or sets the Hyperlink URI.
		/// <para xml:lang="es">
		/// Obtiene o establece la URL del hiperlink.
		/// </para>
		/// </summary>
		Uri IHyperLink.Uri
		{
			get
			{
				return new Uri(Content.Text);
			}
			set
			{
				Content.Text = value.ToString();
			}
		}
	}
}