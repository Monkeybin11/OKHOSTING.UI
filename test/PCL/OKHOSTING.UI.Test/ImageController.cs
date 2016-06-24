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
			IStack stack = Platform.Current.Create<IStack>();

			// Create an Label with text and size specific and adds it to the Stack.
			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "View an image from Url";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

			// Create an image with size specific indicated the URL of the image and adds it to the Stack.
			IImage imgPicture = Platform.Current.Create<IImage>();
			imgPicture.LoadFromUrl(new Uri("http://www.patycantu.com/wp-content/uploads/2014/07/91.jpg"));
			imgPicture.Height = 250;
			imgPicture.Width = 600;
			stack.Children.Add(imgPicture);

			// Creates the Button cmdClose with text specific, with the event also click and adds it to the stack.
			IButton cmdClose = Platform.Current.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			stack.Children.Add(cmdClose);

			// Establishes the content and title of the page.
			Platform.Current.Page.Title = "Test label";
			Platform.Current.Page.Content = stack;
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