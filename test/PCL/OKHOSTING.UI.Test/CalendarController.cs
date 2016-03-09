using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	public class CalendarController : Controller
	{
        ICalendar calendar;
        ILabel lblLabel;

        public override void Start()
		{
			base.Start();

			IStack stack = Platform.Current.Create<IStack>();

			lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "Select 1 day";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

            calendar = Platform.Current.Create<ICalendar>();
            calendar.Name = "calendar";
            //calendar.BackgroundColor = new Color(1,0,0,255);
            calendar.Bold = true;
            stack.Children.Add(calendar);

            IButton cmdChange = Platform.Current.Create<IButton>();
            cmdChange.Text = "Change";
            cmdChange.Click += CmdChange_Click;
            stack.Children.Add(cmdChange);

            IButton cmdClose = Platform.Current.Create<IButton>();
            cmdClose.Text = "Close";
            cmdClose.Click += CmdClose_Click;
            stack.Children.Add(cmdClose);

            Platform.Current.Page.Title = "Test label";
			Platform.Current.Page.Content = stack;
		}

 

        private void CmdChange_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(calendar.Value.ToString());
            if(fecha == DateTime.Today)
            {
                lblLabel.Text = "Hoy es Lunes 7 de marzo";
                lblLabel.FontColor = new Color(1, 0, 0, 0);
            }
            else if(fecha.Day == 13 && fecha.Month == 3)
            {
                lblLabel.Text = "Hoy es cumpleaños de Angel";
                lblLabel.FontColor = new Color(1, 255, 0, 0);
            }
            else
            {
                lblLabel.Text = "Hoy es " + calendar.Value;
                lblLabel.FontColor = new Color(1, 0, 0, 0);
            }
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}