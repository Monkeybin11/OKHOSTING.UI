using System;

namespace OKHOSTING.UI.Net4.WebForms
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
		}

		protected void Session_Start(object sender, EventArgs e)
		{
			System.Web.HttpContext.Current.Session.Add("Platform", new Platform());
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			if (System.Web.HttpContext.Current.Request.FilePath.EndsWith(".axd"))
			{
				return;
			}

			if (System.IO.File.Exists(Server.MapPath(System.Web.HttpContext.Current.Request.FilePath)))
			{
				return;
			}

			System.Web.HttpContext.Current.RewritePath("Default.aspx");
		}

		void Application_PreRequestHandlerExecute(object sender, EventArgs e)
		{
			//var page = (Context.Handler as System.Web.UI.Page);
		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}