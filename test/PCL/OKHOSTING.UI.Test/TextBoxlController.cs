using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	/// <summary>
	/// A single line textbox
	/// <para xml:lang="es">
	/// Un cuadro de texto de una sola linea.
	/// </para>
	/// </summary>
	public class TextBoxController: Controller
	{
		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia una instancia de este objeto.
		/// </para>
		/// </summary>
		public override void Start()
		{
			base.Start();

			//Create an Stack
			IStack stack = Platform.Current.Create<IStack>();

			//Create an Label with text and height specific and adds it to the Stack.
			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "Enter your name";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

			//Create an TextBox and adds it to the Stack
			ITextBox txtText = Platform.Current.Create<ITextBox>();
			txtText.Value = "Este es un TextBox";
			stack.Children.Add(txtText);

			//Create the button cmdClose with specific text with the event also click and adds it to the stack.
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