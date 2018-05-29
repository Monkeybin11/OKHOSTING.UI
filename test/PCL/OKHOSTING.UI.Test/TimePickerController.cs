using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	/// <summary>
	/// It is a control that represents a calendar
	/// <para xml:lang="es">
	/// Es un control que representa un calendario.
	/// </para>
	/// </summary>
	public class TimePickerController : Controller
	{
		ITimeOfDayPicker picker;
		ILabel lblLabel;

		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia la instancia del objeto Calendar.
		/// </para>
		/// </summary>
		public override void Start()
		{
			base.Start();

			// Create an Stack
			IStack stack = Platform.Create<IStack>();

			// Creates an Label with text and a specific size and adds it to the stack.
			lblLabel = Platform.Create<ILabel>();
			lblLabel.Text = "Select a time of day";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

			// Creates an Calendar with text specific and adds it to the stack.
			picker = Platform.Create<ITimeOfDayPicker>();
			picker.Name = "timePicker";
			picker.Bold = true;
			stack.Children.Add(picker);

			// Creates the Button cmdChange with text specific, with the event also click and adds it to the stack.
			IButton cmdChange = Platform.Create<IButton>();
			cmdChange.Text = "Select";
			cmdChange.Click += CmdChange_Click;
			stack.Children.Add(cmdChange);

			// Creates the Button cmdClose with text specific, with the event also click and adds it to the stack.
			IButton cmdClose = Platform.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			stack.Children.Add(cmdClose);

			// Establishes the content and title of the page
			Platform.Page.Title = "Test date picker";
			Platform.Page.Content = stack;
		}

		/// <summary>
		/// It is the click event of the button cmd Change, showing a label with the date of the Calendar.
		/// <para xml:lang="es">
		/// Es el evento clic del boton cmdChange, que muestra un label con la fecha del Calendar.
		/// </para>
		/// </summary>
		/// <returns>The change click.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void CmdChange_Click(object sender, EventArgs e)
		{
			lblLabel.Text = "You choose " + picker.Value;
			lblLabel.FontColor = new Color(1, 0, 0, 0);
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
			Finish();
		}
	}
}