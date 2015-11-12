using System;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class Image : global::Xamarin.Forms.Image, IImage
	{
		public string Name
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public IPage Page
		{
			get
			{
				return (IPage) App.Current.MainPage;
			}
		}

		public bool Visible
		{
			get
			{
				return base.IsVisible;
			}
			set
			{
				base.IsVisible = value;
			}
		}

		public void Dispose()
		{
		}

		public void LoadFromUrl(string url)
		{
			base.Source = global::Xamarin.Forms.ImageSource.FromUri(new Uri(url));
		}

		public void LoadFromFile(string filePath)
		{
			base.Source = global::Xamarin.Forms.ImageSource.FromFile(filePath);
		}

		public void LoadFromStream(Stream stream)
		{
			base.Source = global::Xamarin.Forms.ImageSource.FromStream(() => stream);
		}
	}
}
