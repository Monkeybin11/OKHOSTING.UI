using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
				return (Page)Page;
			}
		}

		public void LoadFromFile(string filePath)
		{
			throw new NotImplementedException();
		}

		public void LoadFromStream(Stream stream)
		{
			throw new NotImplementedException();
		}

		public void LoadFromUrl(string url)
		{
			base.ImageUrl = url;
		}
	}
}
