using System;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class Image : System.Windows.Controls.Image, IImage
	{
		public bool Visible
		{
			get
			{
				return base.Visibility == System.Windows.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = System.Windows.Visibility.Visible;
				}
				else
				{
					base.Visibility = System.Windows.Visibility.Hidden;
				}
			}
		}

		public void Dispose()
		{
		}

		public void LoadFromFile(string filePath)
		{
			var bitmap = new System.Windows.Media.Imaging.BitmapImage();
			bitmap.BeginInit();
			bitmap.UriSource = new Uri(filePath);
			bitmap.EndInit();

			base.Source = bitmap;
		}

		public void LoadFromStream(Stream stream)
		{
			var bitmap = new System.Windows.Media.Imaging.BitmapImage();
			bitmap.BeginInit();
			bitmap.StreamSource = stream;
			bitmap.EndInit();

			base.Source = bitmap;
		}

		public void LoadFromUrl(string url)
		{
			var bitmap = new System.Windows.Media.Imaging.BitmapImage();
			bitmap.BeginInit();
			bitmap.UriSource = new Uri(url);
			bitmap.EndInit();

			base.Source = bitmap;
		}
	}
}