using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	public class HyperLinkController: Controller
	{
		public override void Start()
		{
			base.Start();

			IStack stack = Platform.Current.CreateControl<IStack>();

			ILabel lblLabel = Platform.Current.CreateControl<ILabel>();
			lblLabel.Text = "Visit";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

            IHyperLink hplUrl = Platform.Current.CreateControl<IHyperLink>();
            hplUrl.Text = "http://www.okhosting.com";
            hplUrl.Uri = new Uri("http://www.okhosting.com");
            hplUrl.Name = "okhosting.com";
            stack.Children.Add(hplUrl);

            IButton cmdClose = Platform.Current.CreateControl<IButton>();
            cmdClose.Text = "Close";
            cmdClose.Click += CmdClose_Click;
            stack.Children.Add(cmdClose);

            Platform.Current.Page.Title = "Test label";
			Platform.Current.Page.Content = stack;
		}

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}