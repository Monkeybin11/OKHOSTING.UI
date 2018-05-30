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
		ITextBox txtTextPlaceholder;

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
			IStack stack = Platform.Create<IStack>();

			//Create an Label with text and height specific and adds it to the Stack.
			ILabel lblLabel = Platform.Create<ILabel>();
			lblLabel.Text = "Enter your name";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

			//Create an TextBox and adds it to the Stack
			ITextBox txtText = Platform.Create<ITextBox>();
			txtText.Value = "This is a TextBox";
			txtText.BorderColor = new Color(255, 255, 0, 0);
			txtText.BorderWidth = new Thickness(1, 2, 3, 4);
			txtText.ValueChanged += TxtText_ValueChanged;
			stack.Children.Add(txtText);
			
			//Create an TextBox and adds it to the Stack
			txtTextPlaceholder = Platform.Create<ITextBox>();
			txtTextPlaceholder.BorderColor = new Color(255, 255, 0, 0);
			txtTextPlaceholder.BorderWidth = new Thickness(1, 2, 3, 4);
			txtTextPlaceholder.Placeholder = "Enter some text..";
			txtTextPlaceholder.PlaceholderColor = new Color(255, 100, 100, 100);
			stack.Children.Add(txtTextPlaceholder);

			//Create the button cmdClose with specific text with the event also click and adds it to the stack.
			IButton cmdClose = Platform.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			stack.Children.Add(cmdClose);

			// Establishes the content and title of the page.
			Platform.Page.Title = "Test label";
			Platform.Page.Content = stack;
		}

		private void TxtText_ValueChanged(object sender, string e)
		{
			txtTextPlaceholder.Value = e;
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