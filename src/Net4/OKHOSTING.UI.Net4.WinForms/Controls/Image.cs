using OKHOSTING.UI.Controls;
using System.IO;
using System.Drawing;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Image : System.Windows.Forms.PictureBox, IImage
	{
		public Image()
		{
			SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		}

		public void LoadFromFile(string filePath)
		{
			Image = System.Drawing.Image.FromFile(filePath);
		}

		public void LoadFromStream(Stream stream)
		{
			Image = System.Drawing.Image.FromStream(stream);
		}

		public void LoadFromUrl(System.Uri url)
		{
			try
			{
				using (var stream = new System.Net.WebClient().OpenRead(url))
				{
					Image = System.Drawing.Image.FromStream(stream);
				}
			}
			catch { }
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

		#region IControl

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
					base.Width = (int)value;
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
					base.Height = (int)value;
				}
			}
		}

		/// <summary>
		/// Space that this control will set between itself and it's container
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre si mismo y su contenedor.
		/// </para>
		/// </summary>
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
		/// Space that this control will set between itself and it's own border
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre si mismo y su propio borde
		/// </para>
		/// </summary>
		Thickness IControl.Padding
		{
			get
			{
				return Platform.Parse(base.Padding);
			}
			set
			{
				base.Padding = Platform.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		Color IControl.BorderColor { get; set; }

		Thickness IControl.BorderWidth { get; set; }

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Platform.Parse(base.Anchor).Item1;
			}
			set
			{
				base.Anchor = Platform.ParseAnchor(value, ((IControl)this).VerticalAlignment);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Platform.Parse(base.Anchor).Item2;
			}
			set
			{
				base.Anchor = Platform.ParseAnchor(((IControl)this).HorizontalAlignment, value);
			}
		}

		#endregion

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
		{
			Platform.DrawBorders(this, pevent);
			base.OnPaint(pevent);
		}
	}
}