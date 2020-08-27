namespace OKHOSTING.UI.Net4.WebForms.Media
{
	public class OpenFile : UI.Media.IOpenFile
	{
		public void Open(string fullPath)
		{
			var response = System.Web.HttpContext.Current.Response;

			if (System.IO.Path.IsPathRooted(fullPath) && System.IO.File.Exists(fullPath))
			{
				response.AddHeader("Content-Type", "application/octet-stream");
				response.AddHeader("Content-Transfer-Encoding", "Binary");
				response.AddHeader("Content-disposition", $"attachment; filename=\"{System.IO.Path.GetFileName(fullPath)}\"");
				response.WriteFile(fullPath);
				response.End();
			}
			else
			{
				response.Redirect(fullPath);
			}
		}
	}
}