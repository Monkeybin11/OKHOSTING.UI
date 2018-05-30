using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	/// <summary>
	/// It is a control that represents a checkbox.
	/// <para xml:lang="es">
	/// Es un control que representa un checkbox.
	/// </para>
	/// </summary>
	public class CheckboxController: Controller
	{
		// Declare an CheckBox.
		ICheckBox checkBox;
		// Declare an Label.
		ILabel lblLabel;

		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia la instancia del objeto CheckBox.
		/// </para>
		/// </summary>
		public override void Start()
		{
			base.Start();

			// Create a Stack
			IStack stack = App.Create<IStack>();

			// Creates an Label with text and a specific size and adds it to the stack.
			lblLabel = App.Create<ILabel>();
			lblLabel.Text = "Click on the checkbox";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

			// Creates an CheckBox selected with the event also click and adds it to the stack.
			checkBox = App.Create<ICheckBox>();
			checkBox.Value = true;
			checkBox.ValueChanged += checkBox_ValueChanged;
			stack.Children.Add(checkBox);

			// Creates the Button cmdClose with text specific, with the event also click and adds it to the stack.
			IButton cmdClose = App.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			stack.Children.Add(cmdClose);

			// Establishes the content and title of the page
			App.Page.Title = "Test checkbox";
			App.Page.Content = stack;
		}

		/// <summary>
		/// It is the event where the value is changed checkbox and change the text of the Label
		/// <para xml:lang="es">
		/// Es el evento donde se cambia el valor del checkbox y cambia el texto del Label.
		/// </para>
		/// </summary>
		/// <returns>The box value changed.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void checkBox_ValueChanged(object sender, bool e)
		{
			lblLabel.Text = "You changed the value to: " + ((ICheckBox) sender).Value;
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