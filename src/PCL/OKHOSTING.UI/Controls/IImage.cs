using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Controls
{
	public interface IImage: IControl
	{
		/// <summary>
		/// Loads the image from a Url
		/// </summary>
		void LoadFromUrl(string url);

		void LoadFromFile(string filePath);

		void LoadFromStream(System.IO.Stream stream);
	}
}