using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	public class CheckboxController: Controller
	{
		ICheckBox checkBox;
		ILabel lblLabel;

		public override void Start()
		{
			base.Start();

			IStack stack = Platform.Current.Create<IStack>();

			lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "Click on the checkbox";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

			checkBox = Platform.Current.Create<ICheckBox>();
			checkBox.Value = true;
			checkBox.ValueChanged += checkBox_ValueChanged;
			stack.Children.Add(checkBox);

			IButton cmdClose = Platform.Current.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			stack.Children.Add(cmdClose);

			Platform.Current.Page.Title = "Test checkbox";
			Platform.Current.Page.Content = stack;
		}

		private void checkBox_ValueChanged(object sender, bool e)
		{
			lblLabel.Text = "You changed the value to: " + ((ICheckBox) sender).Value;
		}

		private void CmdClose_Click(object sender, EventArgs e)
		{
			this.Finish();
		}
	}
}