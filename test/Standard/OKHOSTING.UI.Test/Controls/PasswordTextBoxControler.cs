using System;
using System.Drawing;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test.Controls
{
	/// <summary>
	/// Password text box.
	/// <para xml:lang="es">
	/// Es un cuadro de texto que visiblemente enmascara la entrada del usuario.
	/// </para>
	/// </summary>
	class PasswordTextBoxControler: Controller
	{
		ILabel lblPasword;

		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia una instancia de este objeto.
		/// </para>
		/// </summary>
		protected override void OnStart()
		{
			

			// Create an Stack.
			IStack stack = Core.BaitAndSwitch.Create<IStack>();

			// Create an Label with text and size specific and adds it to the Stack.
			lblPasword = Core.BaitAndSwitch.Create<ILabel>();
			lblPasword.VerticalAlignment = VerticalAlignment.Bottom;
			lblPasword.Text = "Enter your password";
			lblPasword.Height = 30;
			stack.Children.Add(lblPasword);

			// Create an PaswordTextBox with backgroundcolor, width and bordercolor specific, aligned center and adds it to the Stack.
			IPasswordTextBox txtBox = Core.BaitAndSwitch.Create<IPasswordTextBox>();
			txtBox.Name = "Password";
			txtBox.BackgroundColor = Color.FromArgb(255, 230, 200, 135);
			txtBox.BorderColor = Color.FromArgb(255, 229, 238, 125);
			txtBox.Width = 100;
			txtBox.BorderWidth = new Thickness(5);
			txtBox.VerticalAlignment = VerticalAlignment.Center;
			txtBox.ValueChanged += TxtBox_ValueChanged;
			stack.Children.Add(txtBox);

			// Creates the Button cmdClose with text specific, with the event also click and adds it to the stack.
			IButton cmdClose = Core.BaitAndSwitch.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			stack.Children.Add(cmdClose);

			// Establishes the content and title of the page.
			Page.Title = "Test Autocomplete";
			Page.Content = stack;
		}

		private void TxtBox_ValueChanged(object sender, string e)
		{
			lblPasword.Text = "Your password's lenght is:" + e.Length;
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
