using OKHOSTING.UI.Controls;
using System.IO;
using System;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Image : System.Windows.Forms.PictureBox, IImage
	{
		public Image()
		{
			base.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		}

		public void LoadFromFile(string filePath)
		{
			base.Image = System.Drawing.Image.FromFile(filePath);
		}

		public void LoadFromStream(Stream stream)
		{
			base.Image = System.Drawing.Image.FromStream(stream);
		}

		public void LoadFromUrl(System.Uri url)
		{
			try
			{
				using (var stream = new System.Net.WebClient().OpenRead(url))
				{
					base.Image = System.Drawing.Image.FromStream(stream);
				}
			}
			catch { }
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

		Thickness IControl.Margin
		{
			get
			{
				return App.Parse(base.Margin);
			}
			set
			{
				base.Margin = App.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return App.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = App.Parse(value);
			}
		}

		Color IControl.BorderColor { get; set; }

		Thickness IControl.BorderWidth { get; set; }

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return App.Parse(base.Anchor).Item1;
			}
			set
			{
				base.Anchor = App.ParseAnchor(value, ((IControl)this).VerticalAlignment);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return App.Parse(base.Anchor).Item2;
			}
			set
			{
				base.Anchor = App.ParseAnchor(((IControl)this).HorizontalAlignment, value);
			}
		}

		#endregion

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
		{
			App.DrawBorders(this, pevent);
			base.OnPaint(pevent);
		}
	}
}