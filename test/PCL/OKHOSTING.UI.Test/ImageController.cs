using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System.IO;

namespace OKHOSTING.UI.Test
{
	/// <summary>
	/// It represents an image.
	/// <para xml:lang="es">
	/// Representa una imagen
	/// </para>
	/// </summary>
	public class ImageController: Controller
	{
		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia la instancia de este objeto.
		/// </para>
		/// </summary>
		public override void Start()
		{
			base.Start();

			// Create an Stack.
			IStack stack = Platform.Create<IStack>();

			// Create an Label with text and size specific and adds it to the Stack.
			ILabel lblLabel = Platform.Create<ILabel>();
			lblLabel.Text = "View an image from Url";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

			// Create an image with size specific indicated the URL of the image and adds it to the Stack.
			IImage imgPicture = Platform.Create<IImage>();
			imgPicture.LoadFromUrl(new Uri("https://www.merriam-webster.com/assets/mw/images/gallery/gal-wap-slideshow-slide/aztec-2666-4b768308b161027e77ae775f6abea503@1x.jpg"));
			imgPicture.Height = 250;
			imgPicture.Width = 600;
			stack.Children.Add(imgPicture);

			// Creates the Button cmdClose with text specific, with the event also click and adds it to the stack.
			IButton cmdClose = Platform.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			stack.Children.Add(cmdClose);

			// Establishes the content and title of the page.
			Platform.Page.Title = "Test label";
			Platform.Page.Content = stack;
		}

		/// <summary>
		/// It is the button click event cmdClose, what it does is end this instance.
		/// <para xml:lang="es">
		/// Es el evento clic del boton cmdClose, lo que hace es finalizar esta instancia.
		/// </para>
		/// </summary>
		/// <returns>The close click.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void CmdClose_Click(object sender, EventArgs e)
		{
			this.Finish();
		}
	}
}