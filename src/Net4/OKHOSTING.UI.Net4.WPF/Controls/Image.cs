using System;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class Image : System.Windows.Controls.Panel, IImage
	{
		protected readonly System.Windows.Controls.Image InnerImage;

		public Image()
		{
			InnerImage = new System.Windows.Controls.Image();
		}

		public void LoadFromFile(string filePath)
		{
			var bitmap = new System.Windows.Media.Imaging.BitmapImage();
			bitmap.BeginInit();
			bitmap.UriSource = new Uri(filePath);
			bitmap.EndInit();

			InnerImage.Source = bitmap;
		}

		public void LoadFromStream(Stream stream)
		{
			var bitmap = new System.Windows.Media.Imaging.BitmapImage();
			bitmap.BeginInit();
			bitmap.StreamSource = stream;
			bitmap.EndInit();

			InnerImage.Source = bitmap;
		}

		public void LoadFromUrl(string url)
		{
			var bitmap = new System.Windows.Media.Imaging.BitmapImage();
			bitmap.BeginInit();
			bitmap.UriSource = new Uri(url);
			bitmap.EndInit();

			InnerImage.Source = bitmap;
		}

		public Color BackgroundColor
		{
			get
			{
				return Page.Parse(((System.Windows.Media.SolidColorBrush) base.Background).Color);
			}
			set
			{
				base.Background = new System.Windows.Media.SolidColorBrush(Page.Parse(value));
			}
		}

		public Color BorderColor
		{
			get
			{
				return Page.Parse(((System.Windows.Media.SolidColorBrush) base.BorderBrush).Color);
			}
			set
			{
				base.BorderBrush = new System.Windows.Media.SolidColorBrush(Page.Parse(value));
			}
		}

		public double BorderWidth
		{
			get
			{
				return base.BorderThickness.Bottom;
			}
			set
			{
				base.BorderThickness = new System.Windows.Thickness(value);
			}
		}

		public bool Enabled
		{
			get
			{
				return base.IsEnabled;
			}
			set
			{
				base.IsEnabled = value;
			}
		}
		
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
	}
}