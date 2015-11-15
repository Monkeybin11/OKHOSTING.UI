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
			//IGrid grid = CurrentPage.Create<IGrid>();
			IGrid grid = CurrentPage.Create<IGrid>();
			grid.ColumnCount = 2;
			grid.RowCount = 3;

			lblUserName = CurrentPage.Create<ILabel>();
			lblUserName.Text = "Username";
			grid.SetContent(0, 0, lblUserName);

			txtUserName = CurrentPage.Create<ITextBox>();
			grid.SetContent(0, 1, txtUserName);

			try
			{
				lblPassword = CurrentPage.Create<ILabel>();
				lblPassword.Text = "Password";
				grid.SetContent(1, 0, lblPassword);

				txtPassword = CurrentPage.Create<IPasswordTextBox>();
				grid.SetContent(1, 1, txtPassword);
			}
			catch (Exception e)
			{
			}

			cmdLogin = CurrentPage.Create<IButton>();
			cmdLogin.Text = "Login";
			cmdLogin.Click += CmdLogin_Click;
			grid.SetContent(2, 0, cmdLogin);

			lblMessage = CurrentPage.Create<ILabel>();
			lblMessage.Text = "Wrong data";
			lblMessage.Visible = false;
			grid.SetContent(2, 1, lblMessage);

			CurrentPage.Title = "Please login";
			CurrentPage.Content = grid;
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