using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;


namespace OKHOSTING.UI.Test
{
	class PasswordTextBoxControler: Controller
	{
		public override void Start()
		{
			base.Start();

			IStack stack = Platform.Current.CreateControl<IStack>();

			ILabel lblPasword = Platform.Current.CreateControl<ILabel>();
			lblPasword.VerticalAlignment = VerticalAlignment.Bottom;
			lblPasword.Text = "Enter your password";
			lblPasword.Height = 30;
			stack.Children.Add(lblPasword);

			IPasswordTextBox txtBox = Platform.Current.CreateControl<IPasswordTextBox>();
			txtBox.Name = "Password";
			txtBox.BackgroundColor = new Color(1, 230, 200, 135);
			txtBox.BorderColor = new Color(1, 229, 238, 125);
			txtBox.Width = 100;
			txtBox.BorderWidth = new Thickness(5);
			txtBox.VerticalAlignment = VerticalAlignment.Center;
			stack.Children.Add(txtBox);

			IButton cmdClose = Platform.Current.CreateControl<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			stack.Children.Add(cmdClose);

			Platform.Current.Page.Title = "Test Autocomplete";
			Platform.Current.Page.Content = stack;
		}

		private void CmdClose_Click(object sender, EventArgs e)
		{
			this.Finish();
		}
	}
}
