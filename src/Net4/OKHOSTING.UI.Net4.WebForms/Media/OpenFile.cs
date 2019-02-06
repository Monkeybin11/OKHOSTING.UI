namespace OKHOSTING.UI.Net4.WebForms.Media
{
	public class OpenFile : UI.Media.IOpenFile
	{
		public void Open(string fullPath)
		{
			if (System.IO.Path.IsPathRooted(fullPath) && System.IO.File.Exists(fullPath))
			{
				System.Web.HttpContext.Current.Response.AddHeader("Content-Type", "application/octet-stream");
				System.Web.HttpContext.Current.Response.AddHeader("Content-Transfer-Encoding", "Binary");
				System.Web.HttpContext.Current.Response.AddHeader("Content-disposition", $"attachment; filename=\"{System.IO.Path.GetFileName(fullPath)}\"");
				System.Web.HttpContext.Current.Response.WriteFile(fullPath);
				System.Web.HttpContext.Current.Response.End();
			}
			else
			{
				System.Web.HttpContext.Current.Response.Redirect(fullPath);
			}
		}
	}
}