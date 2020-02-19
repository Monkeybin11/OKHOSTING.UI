using System.Linq;
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
			App app = (App) HttpContext.Current.Session["App"];
			Page page = (Page) HttpContext.Current.Session["Page"];

			if (page == null)
			{
				return;
			}

			//get provided page size
			double width = double.Parse(context.Request.QueryString["Width"]);
			double height = double.Parse(context.Request.QueryString["Height"]);

			var json = new System.Web.Script.Serialization.JavaScriptSerializer();

			//refresh when this is the first load (session width is null) or when size has changed, so we can rearrange layout if we want to
			var resized = page.Width != width || page.Height != height;
			var output = json.Serialize(new { Refresh = resized });

			//save new page size in session
			context.Session[typeof(Page) + ".Width"] = width;
			context.Session[typeof(Page) + ".Height"] = height;

			if (resized)
			{
				page.OnResized();
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