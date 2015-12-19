using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Test
{
	public class LoginController : Controller
	{
		protected ILabel lblUserName;
		protected ITextBox txtUserName;
		protected ILabel lblPassword;
		protected IPasswordTextBox txtPassword;
		protected IButton cmdLogin;
		protected ILabel lblMessage;

		public override void Start()
		{
			base.Start();

			//IGrid grid = CurrentPage.Create<IGrid>();
			IGrid grid = App.Current.CreateControl<IGrid>();
			grid.ColumnCount = 2;
			grid.RowCount = 3;

			lblUserName = App.Current.CreateControl<ILabel>();
			lblUserName.Text = "Username";
			grid.SetContent(0, 0, lblUserName);

			txtUserName = App.Current.CreateControl<ITextBox>();
			grid.SetContent(0, 1, txtUserName);

			lblPassword = App.Current.CreateControl<ILabel>();
			lblPassword.Text = "Password";
			grid.SetContent(1, 0, lblPassword);

			txtPassword = App.Current.CreateControl<IPasswordTextBox>();
			grid.SetContent(1, 1, txtPassword);

			cmdLogin = App.Current.CreateControl<IButton>();
			cmdLogin.Text = "Login";
			cmdLogin.Click += CmdLogin_Click;
			grid.SetContent(2, 0, cmdLogin);

			lblMessage = App.Current.CreateControl<ILabel>();
			lblMessage.Text = "Wrong data";
			lblMessage.Visible = false;
			grid.SetContent(2, 1, lblMessage);

			App.Current.Page.Title = "Please login";
			App.Current.Page.Content = grid;
		}

		private void CmdLogin_Click(object sender, EventArgs e)
		{
			if (txtUserName.Text == "yo" && txtPassword.Text == "mero")
			{
				lblMessage.Visible = false;
				Finish();

				new DashboardController().Start();
			}
			else
			{
				lblMessage.Visible = true;
			}
		}
	}
}