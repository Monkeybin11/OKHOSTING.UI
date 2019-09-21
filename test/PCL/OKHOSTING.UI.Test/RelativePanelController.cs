using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	/// <summary>
	/// Inspired by UWP and Xamarin.Forms RelativePanel's
	/// <para xml:lang="es">
	/// Un RelativePanel inspirado por WPF y Xamarin.Forms
	/// </para>
	/// </summary>
	public class RelativePanelController : Controller
	{
		/// <summary>
		/// The background image.
		/// <para xml:lang="es">
		/// Es una imagen que servira como fondo.
		/// </para>
		/// </summary>
		protected IImage BackgroundImage;

		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia una instancia de este objeto.
		/// </para>
		/// </summary>
		public override void Start()
		{
			base.Start();

			// Create an RelativePanel.
			IRelativePanel panel = Platform.Create<IRelativePanel>();

			//should be a background image
			BackgroundImage = Platform.Create<IImage>();
			BackgroundImage.LoadFromUrl(new Uri("http://okhosting.com/resources/uploads/2015/09/diseno-de-paginas-responsivas.png"));
			BackgroundImage.Width = Platform.Page.Width;
			BackgroundImage.Height = Platform.Page.Height;
			panel.Add(BackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			//Create the Label lblLabel with text, fontcolor, backgroundcolor and margin specific.
			ILabel lblLabel = Platform.Create<ILabel>();
			lblLabel.Text = "This label is centered";
			lblLabel.FontColor = new Color(255, 0, 0, 255);
			lblLabel.BackgroundColor = new Color(255, 255, 0, 0);
			lblLabel.Margin = new Thickness(20);
			panel.Add(lblLabel, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.CenterWith);

			//Create the Label lblLabel2 with text, Fontcolor, backgroundcolor and margin specific.
			ILabel lblLabel2 = Platform.Create<ILabel>();
			lblLabel2.Text = "This label is centered and below the first one";
			lblLabel2.FontColor = new Color(255, 0, 0, 255);
			lblLabel2.BackgroundColor = new Color(255, 0, 255, 0);
			lblLabel2.Margin = new Thickness(10);
			panel.Add(lblLabel2, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BelowOf, lblLabel);

			//Creates the Button cmdClose with text, fontcolor, backgroundcolor and margin specific, with the event also click and adds it to the stack.
			IButton cmdClose = Platform.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			cmdClose.FontColor = new Color(255, 0, 0, 0);
			cmdClose.BackgroundColor = new Color(255, 0, 255, 255);
			cmdClose.Margin = new Thickness(10);
			panel.Add(cmdClose, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.AboveOf, lblLabel);

			// Establishes the content and title of the page.
			Platform.Page.Title = "Test RelativePanel";
			Platform.Page.Content = panel;
		}

		/// <summary>
		/// Establishes measures the background image
		/// <para xml:lang="es">
		/// Establece las medidas de la imagen de fondo
		/// </para>
		/// </summary>
		public override void Resize()
		{
			base.Resize();

			BackgroundImage.Width = Platform.Page.Width;
			BackgroundImage.Height = Platform.Page.Height;
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