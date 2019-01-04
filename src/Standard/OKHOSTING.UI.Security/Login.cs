using OKHOSTING.Security.InApp;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.UI.Forms;
using System;

namespace OKHOSTING.UI.Security
{
	public class Login : SecureController
	{
		public Login()
		{
		}

		public Login(IPage page) : base(page)
		{
		}

		private Form Form;
		private ILabel lblMessage;

		public Controller NextController
		{
			get; set;
		}

		protected override void OnStart()
		{
			IUserControl formContainer = Core.BaitAndSwitch.Create<IUserControl>();
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
			password.CaptionControl.Text = Resources.Strings.OKHOSTING_UI_Security_LoginController_Password;
			Form.Fields.Add(password);

			Form.Start();

			IButton cmdLogin = Core.BaitAndSwitch.Create<IButton>();
			cmdLogin.Text = Resources.Strings.OKHOSTING_UI_Security_LoginController_Login;
			cmdLogin.Click += cmdLogin_Click;

			IButton cmdRegister = Core.BaitAndSwitch.Create<IButton>();
			cmdRegister.Text = Resources.Strings.OKHOSTING_UI_Security_RegisterController_Register;
			cmdRegister.Click += cmdRegister_Click; ;

			IStack stack = Core.BaitAndSwitch.Create<IStack>();
			stack.Children.Add(formContainer);
			stack.Children.Add(lblMessage);
			stack.Children.Add(cmdLogin);
			stack.Children.Add(cmdRegister);

			Page.Title = Resources.Strings.OKHOSTING_UI_Security_LoginController_Title;
			Page.Content = stack;
		}

		private void cmdRegister_Click(object sender, EventArgs e)
		{
			Finish();
			new Register().Start();
		}

		private void cmdLogin_Click(object sender, EventArgs e)
		{
			User user = new User()
			{
				UserName = (string) Form["userName"].Value,
				Password = (string) Form["password"].Value,
			};

			UserSession session = Authentication.Login(user);
			
			if (session != null)
			{
				Finish();
				NextController.Page = Page;
				NextController.Start();
			}
			else
			{
				lblMessage.Visible = true;
			}
		}
	}
}