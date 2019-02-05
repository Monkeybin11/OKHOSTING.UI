namespace OKHOSTING.UI.Net4.WebForms.Media
{
	public class OpenFile : UI.Media.IOpenFile
	{
		public void Open(string fullPath)
		{
			var localPath = System.Web.HttpContext.Current.Server.MapPath(fullPath);

			if (System.IO.File.Exists(localPath))
			{
				System.Web.HttpContext.Current.Response.TransmitFile(localPath);
			}
			else
			{
				System.Web.HttpContext.Current.Response.Redirect(fullPath);
			}
		}
	}
}