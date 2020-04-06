using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test.Controls
{
	/// <summary>
	/// A multiline textbox
	/// <para xml:lang="es">
	/// Un cuadro de texto de multiples lineas.
	/// </para>
	/// </summary>
	public class TextAreaController: Controller
	{
		//Declare an Label.
		ILabel lblcoment;
		//Declare an TextArea.
		ITextArea txtTextarea;

		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia
		/// </para>
		/// </summary>
		protected override void OnStart()
		{
			

			//Create an Stack
			IStack stack = Core.BaitAndSwitch.Create<IStack>();

			//Create the Label lblLabel with text an height specific and adds it to the Stack.
			ILabel lblLabel = Core.BaitAndSwitch.Create<ILabel>();
			lblLabel.Text = "Enter your comment";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

			//Create an textArea with size specific and adds it to the Stack
			txtTextarea = Core.BaitAndSwitch.Create<ITextArea>();
			txtTextarea.Value = "";
			txtTextarea.Width = 200;
			txtTextarea.Height = 100;
			stack.Children.Add(txtTextarea);

			//Create the button cmdPrint with text specific with the event also click and adds it to the stack.
			IButton cmdPrint = Core.BaitAndSwitch.Create<IButton>();
			cmdPrint.Text = "Print your coment";
			cmdPrint.Click += CmdOpen_Click;
			stack.Children.Add(cmdPrint);

			//Create the Label lblcoment not visible and with width specific and adds it to the Stack
			lblcoment = Core.BaitAndSwitch.Create<ILabel>();
			lblcoment.Visible = false;
			lblcoment.Width = 200;
			stack.Children.Add(lblcoment);

			//Create the button cmdClose with specific text with the event also click and adds it to the stack.
			IButton cmdClose = Core.BaitAndSwitch.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			stack.Children.Add(cmdClose);

			// Establishes the content and title of the page.
			Page.Title = "Test label";
			Page.Content = stack;

			
		}

		/// <summary>
		/// Cmds the open click.
		/// <para xml:lang="es">
		/// Es el evento clic del boton cmdPrint, lo que hace es hacer visible el Label lblcoment y cambiarle el texto al mismo label.
		/// </para>
		/// </summary>
		/// <returns>The open click.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void CmdOpen_Click(object sender, EventArgs e)
		{
			lblcoment.Visible = true;
			lblcoment.Text = txtTextarea.Value;
			txtTextarea.Enabled = false;
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