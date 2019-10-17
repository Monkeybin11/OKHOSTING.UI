using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Forms;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.Security.InApp;
using System;

namespace OKHOSTING.UI.Security
{
	public class Register: SecureController
	{
		public Register()
		{
		}

		public Register(IPage page) : base(page)
		{
		}

		private Form Form;
		private ILabel lblMessage;

		protected override void OnStart()
		{
			IUserControl formContainer = Core.BaitAndSwitch.Create<IUserControl>();
			formContainer.App = Page.App;
			Form = new Form(formContainer);

			lblMessage = Core.BaitAndSwitch.Create<ILabel>();
			lblMessage.Text = Resources.Strings.OKHOSTING_UI_Security_LoginController_LoginError;
			lblMessage.FontColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
			lblMessage.Visible = false;

			StringField userName = new StringField(Form);
			userName.Name = "userName";
			userName.Required = true;
			userName.MaxLenght = 100;
			userName.CaptionControl.Text = Resources.Strings.OKHOSTING_UI_Security_LoginController_UserName;
			Form.Fields.Add(userName);

			PasswordField password = new PasswordField(Form);
			password.Name = "password";
			password.Required = true;
			password.CaptionControl.Text = Resources.Strings.OKHOSTING_UI_Security_LoginController_Password;
			Form.Fields.Add(password);

			Form.Start();

			IButton cmdRegister = Core.BaitAndSwitch.Create<IButton>();
			cmdRegister.Text = Resources.Strings.OKHOSTING_UI_Security_RegisterController_Register;
			cmdRegister.Click += cmdRegister_Click;

			IButton cmdCancel = Core.BaitAndSwitch.Create<IButton>();
			cmdCancel.Text = Resources.Strings.OKHOSTING_UI_Security_LoginController_Cancel;
			cmdCancel.Click += cmdCancel_Click; ;

			IStack stack = Core.BaitAndSwitch.Create<IStack>();
			stack.Children.Add(formContainer);
			stack.Children.Add(lblMessage);
			stack.Children.Add(cmdRegister);

			Page.Title = Resources.Strings.OKHOSTING_UI_Security_LoginController_Title;
			Page.Content = stack;
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Finish();
		}

		private void cmdRegister_Click(object sender, EventArgs e)
		{
			if (!Form.IsValid)
			{
				return;
			}

			string userName = (string) Form["userName"].Value;
			string password = (string) Form["password"].Value;

			User user = new User();
			user.UserName = userName;
			user.Password = password;

			Authentication.Register(user);

			Finish();
		}
	}
}