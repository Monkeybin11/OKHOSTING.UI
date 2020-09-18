using System;

namespace OKHOSTING.UI.Net4.WebForms.Media
{
	public class OpenUri : UI.Media.IOpenUri
	{
		public void Open(Uri uri)
		{
			var response = System.Web.HttpContext.Current.Response;

			response.Redirect(uri.ToString());
		}
	}
}