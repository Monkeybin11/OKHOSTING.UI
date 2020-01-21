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

		/// <summary>
		/// Load a image from an array of bytes
		/// <para xml:lang="es">
		/// Carga una imagen desde un arreglo de bytes
		/// </para>
		/// </summary>
		void IImage.LoadFromBytes(byte[] bytes)
		{
			LoadFromStream(new MemoryStream(bytes));
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

		/// <summary>
		/// Space that this control will set between its content and its border
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre su contenido y su borde
		/// </para>
		/// </summary>
		Thickness IControl.Padding
		{
			get;
			set;
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return Color.Transparent;
				//throw new NotImplementedException();
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

		/// <summary>
		/// Gets or sets a list of classes that define a control's style. 
		/// Exactly the same concept as in CSS. 
		/// </summary>
		string IControl.CssClass { get; set; }

		#endregion
	}
}