using System;
using System.Drawing;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class VideoPlayer : Media.IVideoPlayer
	{
		public Color BackgroundColor
		{
			get;
			set;
		}

		public Color BorderColor
		{
			get;
			set;
		}

		public Thickness BorderWidth
		{
			get;
			set;
		}

		public bool Enabled
		{
			get;
			set;
		}

		public double? Height
		{
			get;
			set;
		}

		public HorizontalAlignment HorizontalAlignment
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the control margin.
		/// <para xml:lang="es">Obtiene o establece el margen del control.</para>
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
		/// Space that this control will set between itself and it's own border
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre si mismo y su propio borde
		/// </para>
		/// </summary>
		Thickness IControl.Padding
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string Source
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

		public object Tag
		{
			get;
			set;
		}

		public VerticalAlignment VerticalAlignment
		{
			get;
			set;
		}

		public bool Visible
		{
			get;
			set;
		}

		public double? Width
		{
			get;
			set;
		}

		public void Dispose()
		{
		}

		public void Pause()
		{
			throw new NotImplementedException();
		}

		public void Play()
		{
			throw new NotImplementedException();
		}

		public void Stop()
		{
			throw new NotImplementedException();
		}
	}
}