using System;
using System.Drawing;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class Image : System.Windows.Controls.Image, IImage
	{
		public void LoadFromFile(string filePath)
		{
			LoadFromUrl(new Uri(filePath));
		}

		public void LoadFromStream(Stream stream)
		{
			var bitmap = new System.Windows.Media.Imaging.BitmapImage();
			bitmap.BeginInit();
			bitmap.StreamSource = stream;
			bitmap.EndInit();

			Source = bitmap;
		}

		public void LoadFromUrl(Uri url)
		{
			if(url == null)
			{
				return;
			}

			var bitmap = new System.Windows.Media.Imaging.BitmapImage(url);
			Source = bitmap;
		}

		public void Dispose()
		{
		}

		#region IControl

		bool IControl.Visible
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

		bool IControl.Enabled
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

		double? IControl.Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				if (value.HasValue)
				{
					base.Width = value.Value;
				}
			}
		}

		double? IControl.Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				if (value.HasValue)
				{
					base.Height = value.Value;
				}
			}
		}

		Thickness IControl.Margin
		{
			get
			{
				return Platform.Parse(base.Margin);
			}
			set
			{
				base.Margin = Platform.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				throw new NotImplementedException();
				//return Platform.Parse(((System.Windows.Media.SolidColorBrush) base.Background).Color);
			}
			set
			{
				//base.Background = new System.Windows.Media.SolidColorBrush(Platform.Parse(value));
			}
		}

		Color IControl.BorderColor
		{
			get; set;
		}

		Thickness IControl.BorderWidth
		{
			get; set;
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Platform.Parse(base.HorizontalAlignment);
			}
			set
			{
				base.HorizontalAlignment = Platform.Parse(value);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Platform.Parse(base.VerticalAlignment);
			}
			set
			{
				base.VerticalAlignment = Platform.Parse(value);
			}
		}

		#endregion
	}
}