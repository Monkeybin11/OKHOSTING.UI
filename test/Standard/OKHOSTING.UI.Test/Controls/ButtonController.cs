using System;
using System.Drawing;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test.Controls
{
	/// <summary>
	/// It is a control that represents a button.
	/// <para xml:lang="es">
	/// Es un control que representa un boton.
	/// </para>
	/// </summary>
	public class ButtonController: Controller
	{
		// Declare an button
		IButton cmdShow;
		// Declare an label
		ILabel lbltext;

		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia la instancia del boton.
		/// </para>
		/// </summary>
		protected override void OnStart()
		{
			// Create an stack
			IStack stack = Core.BaitAndSwitch.Create<IStack>();

			// Creates the button with text, size and specific color, with the event also click and adds it to the stack
			cmdShow = Core.BaitAndSwitch.Create<IButton>();
			cmdShow.Text = "Show/Hide";
			cmdShow.Click += CmdShow_Click;
			cmdShow.BackgroundColor = Color.FromArgb(1, 255, 0, 0);
			cmdShow.FontColor = Color.FromArgb(1, 255, 255, 255);
			stack.Children.Add(cmdShow);

			// Create an Label with text specific, not visible and adds it to the stack
			lbltext = Core.BaitAndSwitch.Create<ILabel>();
			lbltext.Text = "I'm visible, i want an ice-cream";
			lbltext.Visible = false;
			stack.Children.Add(lbltext);

			// Create another button with a specific text with your event click and adds it to the stack
			IButton cmdClose = Core.BaitAndSwitch.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			stack.Children.Add(cmdClose);

			// Establishes the content and title of the page
			Page.Title = "Test label";
			Page.Content = stack;
		}

		/// <summary>
		/// It is the button click event cmd Show, showing a lavel clicking on the.
		/// <para xml:lang="es">
		/// Es el evento click del boton cmdShow, que muestra un lavel al hacer clic en el.
		/// </para>
		/// </summary>
		/// <returns>The show click.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void CmdShow_Click(object sender, EventArgs e)
		{
			if (lbltext.Visible == true)
			{
				lbltext.Visible = false;
			}
			else
			{
				lbltext.Visible = true;
			}
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