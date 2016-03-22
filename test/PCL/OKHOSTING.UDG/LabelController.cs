using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Test
{
	public class LabelController: Controller
	{
		public override void Start()
		{
			base.Start();

			IStack stack = Platform.Current.Create<IStack>();

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "This is a label";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

			ITextBox txtText = Platform.Current.Create<ITextBox>();
			txtText.Value = "Update label text here";
			txtText.ValueChanged += (object sender, string e) => lblLabel.Text = txtText.Value;
			stack.Children.Add(txtText);

			IListPicker lstFont = Platform.Current.Create<IListPicker>();
			lstFont.Items = new string[] { "Arial", "Verdana", "Times new roman", "Helvetica" };
			lstFont.ValueChanged += (object sender, string e) => lblLabel.FontFamily = lstFont.Value;
			stack.Children.Add(lstFont);

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