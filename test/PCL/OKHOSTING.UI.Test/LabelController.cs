using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	/// <summary>
	/// It represents an Label.
	/// <para xml:lang="es">
	/// Representa una etiqueta de texto.
	/// </para>
	/// </summary>
	public class LabelController: Controller
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

			// Create an Stack
			IStack stack = Platform.Create<IStack>();

			// Create an Label with text and size specific and adds it to the Stack.
			ILabel lblLabel = Platform.Create<ILabel>();
			lblLabel.Text = "This is a label";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

			// Create a textbox with a specific value, here can change the text of the label and adds it to the Stack.
			ITextBox txtText = Platform.Create<ITextBox>();
			txtText.Value = "Update label text here";
			txtText.ValueChanged += (object sender, string e) => lblLabel.Text = txtText.Value;
			stack.Children.Add(txtText);

			// Create a textbox with the specific items, here can change the fontfamily of the label and adds it to the Stack.
			IListPicker lstFont = Platform.Create<IListPicker>();
			lstFont.Items = new string[] { "Arial", "Verdana", "Times new roman", "Helvetica" };
			lstFont.ValueChanged += (object sender, string e) => lblLabel.FontFamily = lstFont.Value;
			stack.Children.Add(lstFont);

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