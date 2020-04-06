using System;
using System.Drawing;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test.Controls
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
		protected override void OnStart()
		{
			Refresh();
		}

		public override void Refresh()
		{
			base.Refresh();

			// Create an RelativePanel.
			IRelativePanel panel = Core.BaitAndSwitch.Create<IRelativePanel>();
			panel.Width = Page.Width;
			panel.Height = Page.Height + 500;

			//should be a background image
			BackgroundImage = Core.BaitAndSwitch.Create<IImage>();
			BackgroundImage.LoadFromUrl(new Uri("http://okhosting.com/resources/uploads/2015/09/diseno-de-paginas-responsivas.png"));
			BackgroundImage.Width = Page.Width;
			BackgroundImage.Height = Page.Height;
			panel.Add(BackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			//Create the Label lblLabel with text, fontcolor, backgroundcolor and margin specific.
			ILabel lblLabel = Core.BaitAndSwitch.Create<ILabel>();
			lblLabel.Text = "This label is centered";
			lblLabel.FontColor = Color.FromArgb(255, 0, 0, 255);
			lblLabel.BackgroundColor = Color.FromArgb(255, 255, 0, 0);
			lblLabel.Width = 200;
			lblLabel.Height = 100;
			lblLabel.Margin = new Thickness(20);
			panel.Add(lblLabel, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.CenterWith);

			//Create the Label lblLabel2 with text, Fontcolor, backgroundcolor and margin specific.
			ILabel lblLabel2 = Core.BaitAndSwitch.Create<ILabel>();
			lblLabel2.Text = "This label is centered and below the first one";
			lblLabel2.FontColor = Color.FromArgb(255, 0, 0, 255);
			lblLabel2.BackgroundColor = Color.FromArgb(255, 0, 255, 0);
			lblLabel2.Margin = new Thickness(10);
			lblLabel2.Width = 250;
			lblLabel2.Height = 150;
			panel.Add(lblLabel2, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BelowOf, lblLabel);


			//Create the Label lblLabel2 with text, Fontcolor, backgroundcolor and margin specific.
			ILabel lblLabel3 = Core.BaitAndSwitch.Create<ILabel>();
			lblLabel3.Text = "This label is at the bottom right";
			lblLabel3.FontColor = Color.FromArgb(255, 0, 255, 0);
			lblLabel3.BackgroundColor = Color.FromArgb(255, 255, 255, 0);
			lblLabel3.Margin = new Thickness(10);
			lblLabel3.Width = 100;
			lblLabel3.Height = 100;
			panel.Add(lblLabel3, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.BottomWith);

			//Creates the Button cmdClose with text, fontcolor, backgroundcolor and margin specific, with the event also click and adds it to the stack.
			IButton cmdClose = Core.BaitAndSwitch.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			cmdClose.FontColor = Color.FromArgb(255, 0, 0, 0);
			cmdClose.BackgroundColor = Color.FromArgb(255, 0, 255, 255);
			cmdClose.Margin = new Thickness(10);
			cmdClose.Width = 100;
			cmdClose.Height = 100;
			panel.Add(cmdClose, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.AboveOf, lblLabel);

			// Establishes the content and title of the page.
			Page.Title = "Test RelativePanel";
			Page.Content = panel;
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