using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OKHOSTING.UI.Net4.Remote.Server
{
	/// <summary>
	/// Descripción breve de Handler
	/// </summary>
	public class Handler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "texto/normal";
			context.Response.Write("Hola a todos");
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}