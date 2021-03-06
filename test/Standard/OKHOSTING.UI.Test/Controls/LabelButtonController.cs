﻿using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;

namespace OKHOSTING.UI.Test.Controls
{
	public class LabelButtonController: Controller
	{
		ILabelButton lblLabel;

		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia una instancia de este objeto.
		/// </para>
		/// </summary>
		protected override void OnStart()
		{
			

			// Create an Stack
			IStack stack = Core.BaitAndSwitch.Create<IStack>();

			// Create an Label with text and size specific and adds it to the Stack.
			lblLabel = Core.BaitAndSwitch.Create<ILabelButton>();
			lblLabel.Click += LblLabel_Click;
			lblLabel.Text = "Click me!";
			stack.Children.Add(lblLabel);

			// Creates the Button cmdClose with text specific, with the event also click and adds it to the stack.
			IButton cmdClose = Core.BaitAndSwitch.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			stack.Children.Add(cmdClose);

			// Establishes the content and title of the page.
			Page.Title = "Test label";
			Page.Content = stack;
		}

		private void LblLabel_Click(object sender, EventArgs e)
		{
			lblLabel.Text += "\nThanks for clicking!";
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