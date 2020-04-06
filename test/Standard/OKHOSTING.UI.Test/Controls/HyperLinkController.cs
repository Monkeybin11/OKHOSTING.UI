using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test.Controls
{
	/// <summary>
	/// An hyperlink that will redirect you to any web URL
	/// <para xml:lang="es">
	/// Un hipervinculo que te redirige a cualquier URL Web.
	/// </para>
	/// </summary>
	public class HyperLinkController: Controller
	{
		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia esta instancia de objeto.
		/// </para>
		/// </summary>
		protected override void OnStart()
		{
			

			// Create an Stack
			IStack stack = Core.BaitAndSwitch.Create<IStack>();

			// Creates an Label with text and a specific size and adds it to the stack.
			ILabel lblLabel = Core.BaitAndSwitch.Create<ILabel>();
			lblLabel.Text = "Visit";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

			// Creates an HyperLink with an text, Url and name specific and adds it to the Stack
			IHyperLink hplUrl = Core.BaitAndSwitch.Create<IHyperLink>();
			hplUrl.Text = "http://www.okhosting.com";
			hplUrl.Uri = new Uri("http://www.okhosting.com");
			hplUrl.Name = "okhosting";
			stack.Children.Add(hplUrl);

			// Creates the Button cmdClose with text specific, with the event also click and adds it to the stack.
			IButton cmdClose = Core.BaitAndSwitch.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			stack.Children.Add(cmdClose);

			// Establishes the content and title of the page
			Page.Title = "Test label";
			Page.Content = stack;
		}

		/// <summary>
		/// It is the event where the value is changed checkbox and change the text of the Label.
		/// <para xml:lang="es">
		/// Es el evento donde se cambia el valor del checkbox y cambia el texto del Label.
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