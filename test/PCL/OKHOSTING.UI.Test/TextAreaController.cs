using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	public class TextAreaController: Controller
	{
        ILabel lblcoment;
        ITextArea txtTextarea;

		public override void Start()
		{
			base.Start();

			IStack stack = Platform.Current.Create<IStack>();

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "Enter your comment";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

			txtTextarea = Platform.Current.Create<ITextArea>();
            txtTextarea.Value = "";
            txtTextarea.Width = 200;
            txtTextarea.Height = 100;
			stack.Children.Add(txtTextarea);

            IButton cmdPrint = Platform.Current.Create<IButton>();
            cmdPrint.Text = "Print your coment";
            cmdPrint.Click += CmdOpen_Click;
            stack.Children.Add(cmdPrint);

            lblcoment = Platform.Current.Create<ILabel>();
            lblcoment.Visible = false;
            lblcoment.Width = 200;
            stack.Children.Add(lblcoment);

            IButton cmdClose = Platform.Current.Create<IButton>();
            cmdClose.Text = "Close";
            cmdClose.Click += CmdClose_Click;
            stack.Children.Add(cmdClose);

            Platform.Current.Page.Title = "Test label";
			Platform.Current.Page.Content = stack;

            
		}

        private void CmdOpen_Click(object sender, EventArgs e)
        {
            lblcoment.Visible = true;
            lblcoment.Text = txtTextarea.Value;
            txtTextarea.Enabled = false;
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}