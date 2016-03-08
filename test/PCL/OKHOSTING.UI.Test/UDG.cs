using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Test
{
    public class UDG : Controller
    {
        public override void Start()
        {
            base.Start();

            IStack Stack = Platform.Current.Create<IStack>();

            ILabel lblLabel = Platform.Current.Create<ILabel>();
            lblLabel.Text = "Radio Universidad De Guadalajara";
            lblLabel.Height = 80;
            lblLabel.FontSize = 20;
            lblLabel.BackgroundColor = new Color(1, 255, 0, 255);
            lblLabel.TextHorizontalAlignment = HorizontalAlignment.Center;
            Stack.Children.Add(lblLabel);

            IButton cmdClose = Platform.Current.Create<IButton>();
            cmdClose.Text = "Close";
            cmdClose.Click += CmdClose_Click;
            Stack.Children.Add(cmdClose);

            Platform.Current.Page.Title = "Test Autocomplete";
            Platform.Current.Page.Content = Stack;
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}
