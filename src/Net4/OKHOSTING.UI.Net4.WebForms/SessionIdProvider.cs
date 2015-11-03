using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OKHOSTING.UI.Net4.WebForms
{
	public class SessionIdProvider: UI.Session.SessionIdProvider
	{
		protected static readonly Random Random = new Random();

		public override string GetCurrentSessionId()
		{
			//no longer rely on ASP.NET Session since it's not available on HttpContext.BeginRequest event, rely on cookies instead
			//if (HttpContext.Current != null && HttpContext.Current.Session != null && HttpContext.Current.Session.SessionID != null)
			//{
			//    //Web Application; Using the SessionID of Session Object
			//    id = HttpContext.Current.Session.SessionID;
			//}

			HttpCookie sessionCookie = HttpContext.Current.Request.Cookies["OKHOSTING.UI.Session.Id"];

			if (sessionCookie == null)
			{
				sessionCookie = new HttpCookie("OKHOSTING.UI.Session.Id", Random.Next().ToString());
				sessionCookie.Expires = DateTime.Now.AddMinutes(60);

				HttpContext.Current.Response.AppendCookie(sessionCookie);
			}

			return sessionCookie.Value;
		}

		public static void Setup()
		{
			UI.Session.IdProvider = new SessionIdProvider();
		}
	}
}