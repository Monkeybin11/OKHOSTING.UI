using System;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class Image : System.Web.UI.WebControls.Image, UI.Controls.IImage
	{
		public string Name
		{
			get
			{
				return base.ID;
			}
			set
			{
				base.ID = value;
			}
		}

		IPage IControl.Page
		{
			get
			{
				return (Page) Page;
			}
		}

		public void LoadFromFile(string filePath)
		{
			if (!File.Exists(filePath))
			{
				throw new ArgumentOutOfRangeException("filePath", "The file does not exist");
			}

			//file is not located inside the web app, so we create a copy in a temp directory			
			if (!filePath.StartsWith(this.Page.MapPath("/")))
			{
				string tempDirectoryPath = Path.Combine(OKHOSTING.Core.Net4.DefaultPaths.Custom, "Temp");

				if (!Directory.Exists(tempDirectoryPath))
				{
					Directory.CreateDirectory(tempDirectoryPath);
				}

				string tempFilePath = Path.Combine(tempDirectoryPath, Path.GetFileName(filePath));
			}

			//we finally get the "relative" path of the file and load it as a url
			string url = filePath.Replace(this.Page.MapPath("/"), string.Empty);
			LoadFromUrl(url);
		}

		public void LoadFromStream(Stream stream)
		{
			//save the sream to a temp file, and load as file from there
			string tempDirectoryPath = Path.Combine(OKHOSTING.Core.Net4.DefaultPaths.Custom, "Temp");

			if (!Directory.Exists(tempDirectoryPath))
			{
				Directory.CreateDirectory(tempDirectoryPath);
			}

			string tempFilePath = Path.Combine(tempDirectoryPath, new Random().Next().ToString());
			using (var fileStream = File.OpenWrite(tempFilePath))
			{
				stream.CopyTo(fileStream);
			}
		}

		public void LoadFromUrl(string url)
		{
			base.ImageUrl = url;
		}
	}
}
