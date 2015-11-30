using OKHOSTING.UI.Controls;
using System.IO;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Image : System.Windows.Forms.PictureBox, IImage
	{
		public void LoadFromFile(string filePath)
		{
			base.Image = System.Drawing.Image.FromFile(filePath);
		}

		public void LoadFromStream(Stream stream)
		{
			base.Image = System.Drawing.Image.FromStream(stream);
		}

		public void LoadFromUrl(string url)
		{
			using (var stream = new System.Net.WebClient().OpenRead(url))
			{
				base.Image = System.Drawing.Image.FromStream(stream);
			}
		}

		public Color BackgroundColor
		{
			get
			{
				return Page.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = Page.Parse(value);
			}
		}

		double IControl.Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				base.Width = (int)value;
			}
		}

		double IControl.Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = (int)value;
			}
		}

		public Color BorderColor { get; set; }

		public double BorderWidth { get; set; }

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
		{
			//draw custom border here
			pevent.Graphics.DrawRectangle(new System.Drawing.Pen(Page.Parse(BorderColor), (int)BorderWidth), base.Bounds);

			base.OnPaint(pevent);
		}
	}
}