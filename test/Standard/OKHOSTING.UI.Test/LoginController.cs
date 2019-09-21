using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

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

		protected override void OnStart()
		{
			//IGrid grid = CurrentPage.Create<IGrid>();
			IGrid grid = Core.BaitAndSwitch.Create<IGrid>();
			grid.ColumnCount = 2;
			grid.RowCount = 3;

			lblUserName = Core.BaitAndSwitch.Create<ILabel>();
			lblUserName.Text = "Username";
			grid.SetContent(0, 0, lblUserName);

			txtUserName = Core.BaitAndSwitch.Create<ITextBox>();
			grid.SetContent(0, 1, txtUserName);

			lblPassword = Core.BaitAndSwitch.Create<ILabel>();
			lblPassword.Text = "Password";
			grid.SetContent(1, 0, lblPassword);

			txtPassword = Core.BaitAndSwitch.Create<IPasswordTextBox>();
			grid.SetContent(1, 1, txtPassword);

			cmdLogin = Core.BaitAndSwitch.Create<IButton>();
			cmdLogin.Text = "Login";
			cmdLogin.Click += cmdLogin_Click;
			grid.SetContent(2, 0, cmdLogin);

			lblMessage = Core.BaitAndSwitch.Create<ILabel>();
			lblMessage.Text = "Wrong data";
			lblMessage.Visible = false;
			grid.SetContent(2, 1, lblMessage);

			Page.Title = "Please login";
			Page.Content = grid;
		}

		private void cmdLogin_Click(object sender, EventArgs e)
		{
			if (txtUserName.Value == "yo" && txtPassword.Value == "mero")
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