using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Forms;
using OKHOSTING.UI.Controls.Layout;
using System;

namespace OKHOSTING.UI.Security
{
	public class ChangePassword : SecureController
	{
		public ChangePassword()
		{
		}

		public ChangePassword(IPage page) : base(page)
		{
		}

		private Form Form;
		private ILabel lblMessage;

		protected override void OnStart()
		{
			IUserControl formContainer = Core.BaitAndSwitch.Create<IUserControl>();
			Form = new Form(formContainer);

			lblMessage = Core.BaitAndSwitch.Create<ILabel>();
			lblMessage.Text = Resources.Strings.OKHOSTING_UI_Security_LoginController_LoginError;
			lblMessage.FontColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
			lblMessage.Visible = false;

			StringField currentPassword = new StringField(Form);
			currentPassword.Name = "currentPassword";
			currentPassword.Required = true;
			currentPassword.CaptionControl.Text = Resources.Strings.OKHOSTING_UI_Security_User_Current;
			Form.Fields.Add(currentPassword);

			PasswordField newPassword = new PasswordField(Form);
			newPassword.Name = "newPassword";
			newPassword.Required = true;
			newPassword.CaptionControl.Text = Resources.Strings.OKHOSTING_UI_Security_Controllers_ChangePassword_NewPassword;
			Form.Fields.Add(newPassword);

			PasswordField newPassword2 = new PasswordField(Form);
			newPassword2.Name = "newPassword2";
			newPassword2.Required = true;
			newPassword2.CaptionControl.Text = Resources.Strings.OKHOSTING_UI_Security_Controllers_ChangePassword_NewPassword2;
			Form.Fields.Add(newPassword2);

			Form.Start();

			IButton cmdChange = Core.BaitAndSwitch.Create<IButton>();
			cmdChange.Text = Resources.Strings.OKHOSTING_UI_Security_Controllers_ChangePassword_Title;
			cmdChange.Click += cmdChange_Click;

			IButton cmdCancel = Core.BaitAndSwitch.Create<IButton>();
			cmdCancel.Text = Resources.Strings.OKHOSTING_UI_Security_LoginController_Cancel;
			cmdCancel.Click += cmdCancel_Click; ;

			IStack stack = Core.BaitAndSwitch.Create<IStack>();
			stack.Children.Add(formContainer);
			stack.Children.Add(lblMessage);
			stack.Children.Add(cmdChange);

			Page.Title = Resources.Strings.OKHOSTING_UI_Security_Controllers_ChangePassword_Title;
			Page.Content = stack;
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Finish();
		}

		private void cmdChange_Click(object sender, EventArgs e)
		{
			string userName = Authentication.CurrentSession.User.UserName;
			string currentPassword = (string) Form["newPassword"].Value;
			string newPassword = (string) Form["newPassword"].Value;
			string newPassword2 = (string) Form["newPassword"].Value;

			throw new NotImplementedException();

			//bool result = User.Login(userName, currentPassword);

			//if (result)
			//{
			//	Finish();
			//}
			//else
			//{
			//	lblMessage.Visible = true;
			//}
		}
	}
}