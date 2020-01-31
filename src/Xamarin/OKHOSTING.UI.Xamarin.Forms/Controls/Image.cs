using System;
using System.Drawing;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// It is a control that represents a image in a Xamarin.Forms.
	/// <para xml:lang="es">
	/// Es un control que representa una imagen en un Xamarin.Forms.
	/// </para>
	/// </summary>
	public class Image : global::Xamarin.Forms.Image, IImage
	//public class Image : FFImageLoading.Forms.CachedImage, IImage
	{
		public Image()
		{
			//base.DownsampleToViewSize = true;
			//base.CacheType = FFImageLoading.Cache.CacheType.Disk;
			//base.CacheDuration = new TimeSpan(6, 0, 0);
		}

		/// <summary>
		/// Load a image from URL.
		/// <para xml:lang="es">
		/// Carga una imagen desde un Url.
		/// </para>
		/// </summary>
		/// <param name="url">URL.
		/// <para xml:lang="es">El URL</para>
		/// </param>
		void IImage.LoadFromUrl(Uri url)
		{
			Source = new global::Xamarin.Forms.UriImageSource
			{
				Uri = url,
				CachingEnabled = true,
				CacheValidity = new TimeSpan(0, 0, 1, 0)
			};
		}

		/// <summary>
		/// Load a image from file.
		/// <para xml:lang="es">
		/// Carga una imagen desde un archivo.
		/// </para>
		/// </summary>
		/// <returns>The file of the image.</returns>
		/// <param name="filePath">File path.
		/// <para xml:lang="es">La ruta del archivo</para>
		/// </param>
		void IImage.LoadFromFile(string filePath)
		{
			Source = global::Xamarin.Forms.ImageSource.FromFile(filePath);
		}

		/// <summary>
		/// Load a image from stream.
		/// <para xml:lang="es">
		/// Carga una imagen desde un stream
		/// </para>
		/// </summary>
		/// <returns>The stream of the image.</returns>
		/// <param name="stream">Stream.
		/// <para xml:lang="es">El stream de la imagen</para>
		/// </param>
		void IImage.LoadFromStream(Stream stream)
		{
			Source = global::Xamarin.Forms.ImageSource.FromStream(() => stream);
		}


		/// <summary>
		/// Load a image from an array of bytes
		/// <para xml:lang="es">
		/// Carga una imagen desde un arreglo de bytes
		/// </para>
		/// </summary>
		void IImage.LoadFromBytes(byte[] bytes)
		{
			((IImage) this).LoadFromStream(new MemoryStream(bytes));
		}

		/// <summary>
		/// The identifier dispose.
		/// <para xml:lang="es">
		/// El identificador dispose.
		/// </para>
		/// </summary>
		void IDisposable.Dispose()
		{
		}

		#region IControl

		/// <summary>
		/// Gets or sets the name of the control.
		/// <para xml:lang="es">
		/// Obtiene o establece el nombre del control.
		/// </para>
		/// </summary>
		string IControl.Name
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets wether the control is visible or not.
		/// <para xml:lang="es">
		/// Obtiene o establece si el control es visible o no.
		/// </para>
		/// </summary>
		bool IControl.Visible
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

		/// <summary>
		/// Gets or sets wether the control is enabled or not
		/// <para xml:lang="es">
		/// Obtiene o establece si el control es habilitado o no.
		/// </para>
		/// </summary>
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

		/// <summary>
		/// Gets or sets the width of the control.
		/// <para xml:lang="es">
		/// Obtiene o establece el ancho del control.
		/// </para>
		/// </summary>
		double? IControl.Width
		{
			get
			{
				return base.WidthRequest;
			}
			set
			{
				if (value.HasValue)
				{
					base.WidthRequest = value.Value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the height of the control.
		/// <para xml:lang="es">
		/// Obtiene o establece la altura del control.
		/// </para>
		/// </summary>
		double? IControl.Height
		{
			get
			{
				return base.HeightRequest;
			}
			set
			{
				if (value.HasValue)
				{
					base.HeightRequest = value.Value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the control margin.
		/// <para xml:lang="es">
		/// Obtiene o establece el margen del control.
		/// </para>
		/// </summary>
		Thickness IControl.Margin
		{
			get
			{
				return Forms.Platform.Parse(base.Margin);
			}
			set
			{
				base.Margin = Forms.Platform.Parse(value);
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

		/// <summary>
		/// Gets or sets the color of the Control background.
		/// <para xml:lang="es">
		/// Obtiene o establece el color de fondo del control.
		/// </para>
		/// </summary>
		Color IControl.BackgroundColor
		{
			get
			{
				return Forms.Platform.Parse(base.BackgroundColor);
			}
			set
			{
				base.BackgroundColor = Forms.Platform.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the color of the control border.
		/// <para xml:lang="es">
		/// Obtiene o establece el color del borde del control.
		/// </para>
		/// </summary>
		Color IControl.BorderColor
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the width of the control border.
		/// <para xml:lang="es">
		/// Obtiene o establece el ancho del borde del control.
		/// </para>
		/// </summary>
		Thickness IControl.BorderWidth
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the control horizontal alignment.
		/// <para xml:lang="es">
		/// Obtiene o establece la alineación horizontal del control.
		/// </para>
		/// </summary>
		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Forms.Platform.Parse(base.HorizontalOptions.Alignment);
			}
			set
			{
				base.HorizontalOptions = new global::Xamarin.Forms.LayoutOptions(Forms.Platform.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets the control vertical alignment.
		/// <para xml:lang="es">
		/// Obtiene o establece la alineación vertical del control.
		/// </para>
		/// </summary>
		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Forms.Platform.ParseVerticalAlignment(base.VerticalOptions.Alignment);
			}
			set
			{
				base.VerticalOptions = new global::Xamarin.Forms.LayoutOptions(Forms.Platform.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">
		/// Obtiene o establece un valor de objeto arbitrario que puede ser usado para almacenar informacion personalizada de este elemento.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">
		/// Devuelve el valor previsto. Esta propiedad no contiene un valor predeterminado.
		/// </para>
		/// </remarks>
		object IControl.Tag
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets a list of classes that define a control's style. 
		/// Exactly the same concept as in CSS. 
		/// </summary>
		string IControl.CssClass { get; set; }

		/// <summary>
		/// Control that contains this control, like a grid, or stack
		/// </summary>
		IControl IControl.Parent
		{
			get
			{
				return (IControl)base.Parent;
			}
		}

		#endregion
	}
}