using System.Linq;
using System.Web;

namespace OKHOSTING.UI.Net4.WebForms.Services
{
	/// <summary>
	/// Summary description for PageSize
	/// </summary>
	public class Autocomplete : IHttpHandler, System.Web.SessionState.IRequiresSessionState
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "application/json";
			App app = (App) HttpContext.Current.Session["App"];
			Page page = (Page) HttpContext.Current.Session["Page"];

			//get provided page size
			var term = context.Request["term"];
			var count = int.Parse(context.Request["count"]);
			var controlId = context.Request["controlId"];

			if (count == 0) count = 20;

			//search on the main Page only (not on user controls)

			Controls.Autocomplete autocomplete = (Controls.Autocomplete) page.FindControl(controlId);
			var e = ((UI.Controls.IAutocomplete) autocomplete).OnSearching(term);
			context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(e.SearchResult));
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