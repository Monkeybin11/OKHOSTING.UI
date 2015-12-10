using System.Web;

namespace OKHOSTING.UI.Net4.WebForms
{
	/// <summary>
	/// Summary description for PageSize
	/// </summary>
	public class PageSize : IHttpHandler, System.Web.SessionState.IRequiresSessionState
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "application/json";

			var json = new System.Web.Script.Serialization.JavaScriptSerializer();

			//refresh when this is the first load (session width is null) orwhen size has changed, so we can rearrange layout if we want
			var refresh = Session.Current[typeof(Page) + ".Width"] == null || ((double)Session.Current[typeof(Page) + ".Width"]) != double.Parse(context.Request.QueryString["Width"]);
            var output = json.Serialize(new { Refresh = refresh });
			context.Response.Write(output);

			Session.Current[typeof(Page) + ".Width"] = double.Parse(context.Request.QueryString["Width"]);
			Session.Current[typeof(Page) + ".Height"] = double.Parse(context.Request.QueryString["Height"]);
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