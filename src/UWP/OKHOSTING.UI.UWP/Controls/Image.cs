using OKHOSTING.UI.Controls;
using System;
using System.IO;

namespace OKHOSTING.UI.UWP.Controls
{
	public class Image : Windows.UI.Xaml.Controls.Panel, IImage
	{
		protected Windows.UI.Xaml.Controls.Image InnerImage = new Windows.UI.Xaml.Controls.Image();

		public IPage Page
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool Visible
		{
			get
			{
				return base.Visibility == Windows.UI.Xaml.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = Windows.UI.Xaml.Visibility.Visible;
				}
				else
				{
					base.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
				}
			}
		}

		public void Dispose()
		{
		}

		public void LoadFromFile(string filePath)
		{
			InnerImage.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(filePath));
        }

		public void LoadFromStream(Stream stream)
		{
			InnerImage.Source = new Windows.UI.Xaml.Media.Imaging.str
		}

		public void LoadFromUrl(string url)
		{
			throw new NotImplementedException();
		}
	}
}
