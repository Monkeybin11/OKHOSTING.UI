using System;

namespace OKHOSTING.UI.Net4.WebForms
{
	public class Global : System.Web.HttpApplication
	{
		protected static int ControlCounter = 0;
		
		protected virtual void Application_Start(object sender, EventArgs e)
		{
			Core.BaitAndSwitch.PlatformSpecificModifiers.Add(new Tuple<Type, Func<object, object>>(typeof(UI.IControl), control =>
			{
				if (string.IsNullOrWhiteSpace(((IControl) control).Name))
				{
					((IControl) control).Name = $"ctr_{control.GetType().Name}_{ControlCounter++}";
				}

				return control;
			}));
		}

		protected virtual void Application_BeginRequest(object sender, EventArgs e)
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

		protected virtual void Application_PreRequestHandlerExecute(object sender, EventArgs e)
		{
		}

		protected virtual void Application_AuthenticateRequest(object sender, EventArgs e)
		{
		}

		protected virtual void Application_Error(object sender, EventArgs e)
		{
		}

		protected virtual void Session_End(object sender, EventArgs e)
		{
		}

		protected virtual void Application_End(object sender, EventArgs e)
		{
		}
	}
}