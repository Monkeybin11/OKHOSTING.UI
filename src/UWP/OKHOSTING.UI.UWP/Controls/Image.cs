using OKHOSTING.UI.Controls;
using System;
using System.IO;

namespace OKHOSTING.UI.UWP.Controls
{
	public class Image : Windows.UI.Xaml.Controls.Panel, IImage
	{
		protected Windows.UI.Xaml.Controls.Image InnerImage = new Windows.UI.Xaml.Controls.Image();

		void IImage.LoadFromFile(string filePath)
		{
			InnerImage.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(filePath));
        }

		void IImage.LoadFromStream(Stream stream)
		{
			//var image = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
			//image.SetSource(Windows.Storage.Streams.RandomAccessStream.);
			//InnerImage.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage();

			throw new NotImplementedException();
		}

		void IImage.LoadFromUrl(Uri url)
		{
			InnerImage.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(url);
		}

		void IDisposable.Dispose()
		{
		}

		#region IControl

		bool IControl.Visible
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

		bool IControl.Enabled
		{
			get
			{
				return true;
			}
			set
			{
				//do nothing
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
				//do nothing
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
				return App.Current.Parse(base.Margin);
			}
			set
			{
				base.Margin = App.Current.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return App.Current.Parse(((Windows.UI.Xaml.Media.SolidColorBrush)base.Background).Color);
			}
			set
			{
				base.Background = new Windows.UI.Xaml.Media.SolidColorBrush(App.Current.Parse(value));
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
				return App.Current.Parse(base.HorizontalAlignment);
			}
			set
			{
				base.HorizontalAlignment = App.Current.Parse(value);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return App.Current.Parse(base.VerticalAlignment);
			}
			set
			{
				base.VerticalAlignment = App.Current.Parse(value);
			}
		}

		#endregion
	}
}
