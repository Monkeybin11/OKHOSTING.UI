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
            IGrid grid = Platform.Current.Create<IGrid>();
            grid.ColumnCount = 2;
            grid.RowCount = 3;

            lblUserName = Platform.Current.Create<ILabel>();
            lblUserName.Text = "Username";
            grid.SetContent(0, 0, lblUserName);

            txtUserName = Platform.Current.Create<ITextBox>();
            grid.SetContent(0, 1, txtUserName);

            lblPassword = Platform.Current.Create<ILabel>();
            lblPassword.Text = "Password";
            grid.SetContent(1, 0, lblPassword);

            txtPassword = Platform.Current.Create<IPasswordTextBox>();
            grid.SetContent(1, 1, txtPassword);

            cmdLogin = Platform.Current.Create<IButton>();
            cmdLogin.Text = "Login";
            cmdLogin.Click += CmdLogin_Click;
            grid.SetContent(2, 0, cmdLogin);

            lblMessage = Platform.Current.Create<ILabel>();
            lblMessage.Text = "Wrong data";
            lblMessage.Visible = false;
            grid.SetContent(2, 1, lblMessage);

            Platform.Current.Page.Title = "Please login";
            Platform.Current.Page.Content = grid;
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