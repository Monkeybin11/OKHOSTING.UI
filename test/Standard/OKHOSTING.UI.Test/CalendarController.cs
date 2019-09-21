using System;
using System.Drawing;
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
	public class CalendarController : Controller
	{
		// Declare an Calendar.
		ICalendar calendar;
		// Declare an Label
		ILabel lblLabel;

		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia la instancia del objeto Calendar.
		/// </para>
		/// </summary>
		protected override void OnStart()
		{
			

			// Create an Stack
			IStack stack = Core.BaitAndSwitch.Create<IStack>();

			// Creates an Label with text and a specific size and adds it to the stack.
			lblLabel = Core.BaitAndSwitch.Create<ILabel>();
			lblLabel.Text = "Select 1 day";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

			// Creates an Calendar with text specific and adds it to the stack.
			calendar = Core.BaitAndSwitch.Create<ICalendar>();
			calendar.Name = "calendar";
			calendar.Bold = true;
			stack.Children.Add(calendar);

			// Creates the Button cmdChange with text specific, with the event also click and adds it to the stack.
			IButton cmdChange = Core.BaitAndSwitch.Create<IButton>();
			cmdChange.Text = "Change";
			cmdChange.Click += CmdChange_Click;
			stack.Children.Add(cmdChange);

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
			DateTime fecha = DateTime.Parse(calendar.Value.ToString());
			if(fecha == DateTime.Today)
			{
				lblLabel.Text = "Hoy es Lunes 7 de marzo";
				lblLabel.FontColor = Color.FromArgb(1, 0, 0, 0);
			}
			else if(fecha.Day == 13 && fecha.Month == 3)
			{
				lblLabel.Text = "Hoy es cumpleaños de Angel";
				lblLabel.FontColor = Color.FromArgb(1, 255, 0, 0);
			}
			else
			{
				lblLabel.Text = "Hoy es " + calendar.Value;
				lblLabel.FontColor = Color.FromArgb(1, 0, 0, 0);
			}
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