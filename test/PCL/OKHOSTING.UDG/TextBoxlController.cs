using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Test
{
	public class TextBoxController: Controller
	{
		public override void Start()
		{
			base.Start();

			IStack stack = Platform.Current.Create<IStack>();

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "Enter your name";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

			ITextBox txtText = Platform.Current.Create<ITextBox>();
			txtText.Value = "";
			stack.Children.Add(txtText);

			IButton cmdPrint = Platform.Current.Create<IButton>();

			IButton cmdClose = Platform.Current.Create<IButton>();
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