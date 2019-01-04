using OKHOSTING.Security.InApp;

namespace OKHOSTING.UI.Security
{
	public class Authorization: OKHOSTING.Security.InApp.Authorization
	{
		public App App { get; set; }

		protected override void Authentication_LoggedIn(object sender, UserSession e)
		{
			App.ControllerStarting += App_ControllerStarting;
		}

		private void App_ControllerStarting(object sender, ControllerEventArgs e)
		{
			Authorize(e.Controller.GetType());
		}

		protected override void Authentication_LoggedOut(object sender, UserSession e)
		{
			App.ControllerStarting -= App_ControllerStarting;
		}
	}
}