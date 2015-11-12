using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Image : System.Windows.Forms.PictureBox, UI.Controls.IImage
	{
		public IPage Page
		{
			get
			{
				return (Page)base.FindForm();
			}
		}

		public void LoadFromFile(string filePath)
		{
			base.Image = System.Drawing.Image.FromFile(filePath);
		}

		public void LoadFromStream(Stream stream)
		{
			base.Image = System.Drawing.Image.FromStream(stream);
		}

		public void LoadFromUrl(string url)
		{
			using (var stream = new System.Net.WebClient().OpenRead(url))
			{
				base.Image = System.Drawing.Image.FromStream(stream);
			}
		}
	}
}