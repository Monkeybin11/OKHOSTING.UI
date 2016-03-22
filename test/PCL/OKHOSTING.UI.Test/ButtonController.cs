using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	public class ButtonController: Controller
	{
		IButton cmdShow;
		ILabel lbltext;

		public override void Start()
		{
			base.Start();

			IStack stack = Platform.Current.CreateControl<IStack>();

			cmdShow = Platform.Current.CreateControl<IButton>();
			cmdShow.Text = "Show/Hide";
			cmdShow.Click += CmdShow_Click;
			cmdShow.BackgroundColor = new Color(1, 255, 0, 0);
			cmdShow.FontColor = new Color(1, 255, 255, 255);
			stack.Children.Add(cmdShow);

			lbltext = Platform.Current.CreateControl<ILabel>();
			lbltext.Text = "I'm visible, i want an ice-cream";
			lbltext.Visible = false;
			
			stack.Children.Add(lbltext);

			IButton cmdClose = Platform.Current.CreateControl<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			stack.Children.Add(cmdClose);

			Platform.Current.Page.Title = "Test label";
			Platform.Current.Page.Content = stack;
		}

		private void CmdShow_Click(object sender, EventArgs e)
		{
			if (lbltext.Visible == true)
			{
				lbltext.Visible = false;
			}
			else
			{
				lbltext.Visible = true;
			}
		}

		private void CmdClose_Click(object sender, EventArgs e)
		{
			this.Finish();
		}
	}
}