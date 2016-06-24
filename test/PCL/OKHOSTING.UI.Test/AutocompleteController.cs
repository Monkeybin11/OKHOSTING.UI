using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	/// <summary>
	/// Represents a control that is autocomplete.
	/// <para xml:lang="es">
	/// Representa un control que es autocomplete.
	/// </para>
	/// </summary>
	public class AutocompleteController: Controller
	{
		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia la instancia del Autocomplete.
		/// </para>
		/// </summary>
		public override void Start()
		{
			base.Start();

			// Create a Stack
			IStack Stack = Platform.Current.Create<IStack>();

			// Creates an Label with text and a specific size and adds it to the stack.
			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "Tis is my team";
			lblLabel.Height = 50;
			lblLabel.FontSize = 20;
			Stack.Children.Add(lblLabel);

			// Create an Autocomplete with a size and type text color and size specific and adds it to the stack.
			IAutocomplete txtBox = Platform.Current.Create<IAutocomplete>();
			txtBox.Name = "Team";
			txtBox.FontColor = new Color(1, 36, 24, 130);
			txtBox.BorderColor = new Color(1, 229, 238, 0);
			txtBox.Width = 100;
			txtBox.Height = 80;
			txtBox.FontFamily = "Times new roman";
			txtBox.FontSize = 20;
			Stack.Children.Add(txtBox);

			// Creates a button with your event Click and adds it to the stack.
			IButton cmdClose = Platform.Current.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			Stack.Children.Add(cmdClose);

			// Establishes the content and title of the page
			Platform.Current.Page.Title = "Test Autocomplete";
			Platform.Current.Page.Content = Stack;
		}

		/// <summary>
		/// It is the button click event that it does is end this instance.
		/// <para xml:lang="es">
		/// Es el evento clic del boton que lo que hace es finalizar esta instancia.
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