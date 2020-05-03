using System;
using System.Drawing;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test.Controls
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
		protected override void OnStart()
		{
			

			// Create a Stack
			IStack Stack = Core.BaitAndSwitch.Create<IStack>();

			// Creates an Label with text and a specific size and adds it to the stack.
			ILabel lblLabel = Core.BaitAndSwitch.Create<ILabel>();
			lblLabel.Text = "Tis is my team";
			lblLabel.Height = 50;
			lblLabel.FontSize = 20;
			Stack.Children.Add(lblLabel);

			// Create an Autocomplete with a size and type text color and size specific and adds it to the stack.
			IAutocomplete txtBox = Core.BaitAndSwitch.Create<IAutocomplete>();
			txtBox.Name = "Team";
			txtBox.FontColor = Color.FromArgb(255, 36, 24, 130);
			txtBox.BorderColor = Color.FromArgb(1, 229, 238, 0);
			txtBox.Width = 150;
			txtBox.Height = 30;
			txtBox.FontFamily = "Times new roman";
			txtBox.FontSize = 20;
			txtBox.Searching += TxtBox_Searching;
			Stack.Children.Add(txtBox);

			// Creates a button with your event Click and adds it to the stack.
			IButton cmdClose = Core.BaitAndSwitch.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			Stack.Children.Add(cmdClose);

			// Establishes the content and title of the page
			Page.Title = "Test Autocomplete";
			Page.Content = Stack;
		}

		private void TxtBox_Searching(object sender, AutocompleteSearchEventArgs e)
		{
			e.SearchResult = new[] { "Pedro", "Donaciana", "Muñoz", "Mata", "Lozano" };
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