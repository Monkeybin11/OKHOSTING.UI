using System.Web;

namespace OKHOSTING.UI.Net4.WebForms.Services
{
	/// <summary>
	/// Summary description for PageSize
	/// </summary>
	public class PageSize : IHttpHandler, System.Web.SessionState.IRequiresSessionState
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "application/json";

			//get provided page size
			double width = double.Parse(context.Request.QueryString["Width"]);
			double height = double.Parse(context.Request.QueryString["Height"]);

			var json = new System.Web.Script.Serialization.JavaScriptSerializer();
			var app = (App) HttpContext.Current.Session["App"];

			//refresh when this is the first load (session width is null) or when size has changed, so we can rearrange layout if we want to
			var refresh = app.Page.Width != width || app.Page.Height != height;
			var output = json.Serialize(new { Refresh = refresh });

			//save new page size in session
			HttpContext.Current.Session[typeof(Page) + ".Width"] = width;
			HttpContext.Current.Session[typeof(Page) + ".Height"] = height;

			if (refresh && app.Controller != null)
			{
				app.Controller.Resize();
			}

			context.Response.Write(output);
		}

		public bool IsReusable
		{
			get
			{
				return true;
			}
		}
	}
}