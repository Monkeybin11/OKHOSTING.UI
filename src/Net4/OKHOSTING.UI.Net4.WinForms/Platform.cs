using OKHOSTING.UI.Controls.Layout;
using System;
using System.Drawing;

namespace OKHOSTING.UI.Net4.WinForms
{
	public static class Platform
	{
		public static void Finish()
		{
			System.Windows.Forms.Application.Exit();
		}

		public static System.Windows.Forms.Padding Parse(Thickness thickness)
		{
			if (thickness == null)
			{
				return default;
			}

			System.Windows.Forms.Padding padding = new System.Windows.Forms.Padding();

			if (thickness.Left.HasValue) padding.Left = (int)thickness.Left;
			if (thickness.Top.HasValue) padding.Top = (int)thickness.Top;
			if (thickness.Right.HasValue) padding.Right = (int)thickness.Right;
			if (thickness.Bottom.HasValue) padding.Bottom = (int)thickness.Bottom;

			return padding;
		}

		public static Thickness Parse(System.Windows.Forms.Padding margin)
		{
			return new Thickness(margin.Left, margin.Top, margin.Right, margin.Bottom);
		}

		public static Tuple<HorizontalAlignment, VerticalAlignment> Parse(ContentAlignment alignment)
		{
			switch (alignment)
			{
				case ContentAlignment.BottomCenter:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);

				case ContentAlignment.BottomLeft:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);

				case ContentAlignment.BottomRight:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);

				case ContentAlignment.MiddleCenter:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);

				case ContentAlignment.MiddleLeft:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);

				case ContentAlignment.MiddleRight:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);

				case ContentAlignment.TopLeft:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);
				case ContentAlignment.TopCenter:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);
				case ContentAlignment.TopRight:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);
			}

			throw new ArgumentOutOfRangeException("alignment");
		}

		public static ContentAlignment ParseContentAlignment(HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment)
		{
			if (verticalAlignment == VerticalAlignment.Bottom && horizontalAlignment == HorizontalAlignment.Fill) return System.Drawing.ContentAlignment.BottomCenter;
			if (verticalAlignment == VerticalAlignment.Bottom && horizontalAlignment == HorizontalAlignment.Center) return System.Drawing.ContentAlignment.BottomCenter;
			if (verticalAlignment == VerticalAlignment.Bottom && horizontalAlignment == HorizontalAlignment.Left) return System.Drawing.ContentAlignment.BottomLeft;
			if (verticalAlignment == VerticalAlignment.Bottom && horizontalAlignment == HorizontalAlignment.Right) return System.Drawing.ContentAlignment.BottomRight;

			if (verticalAlignment == VerticalAlignment.Center && horizontalAlignment == HorizontalAlignment.Fill) return System.Drawing.ContentAlignment.MiddleCenter;
			if (verticalAlignment == VerticalAlignment.Center && horizontalAlignment == HorizontalAlignment.Center) return System.Drawing.ContentAlignment.MiddleCenter;
			if (verticalAlignment == VerticalAlignment.Center && horizontalAlignment == HorizontalAlignment.Left) return System.Drawing.ContentAlignment.MiddleLeft;
			if (verticalAlignment == VerticalAlignment.Center && horizontalAlignment == HorizontalAlignment.Right) return System.Drawing.ContentAlignment.MiddleRight;

			if (verticalAlignment == VerticalAlignment.Top && horizontalAlignment == HorizontalAlignment.Fill) return System.Drawing.ContentAlignment.TopCenter;
			if (verticalAlignment == VerticalAlignment.Top && horizontalAlignment == HorizontalAlignment.Center) return System.Drawing.ContentAlignment.TopCenter;
			if (verticalAlignment == VerticalAlignment.Top && horizontalAlignment == HorizontalAlignment.Left) return System.Drawing.ContentAlignment.TopLeft;
			if (verticalAlignment == VerticalAlignment.Top && horizontalAlignment == HorizontalAlignment.Right) return System.Drawing.ContentAlignment.TopRight;

			if (verticalAlignment == VerticalAlignment.Fill && horizontalAlignment == HorizontalAlignment.Fill) return System.Drawing.ContentAlignment.MiddleCenter;
			if (verticalAlignment == VerticalAlignment.Fill && horizontalAlignment == HorizontalAlignment.Center) return System.Drawing.ContentAlignment.MiddleCenter;
			if (verticalAlignment == VerticalAlignment.Fill && horizontalAlignment == HorizontalAlignment.Left) return System.Drawing.ContentAlignment.MiddleLeft;
			if (verticalAlignment == VerticalAlignment.Fill && horizontalAlignment == HorizontalAlignment.Right) return System.Drawing.ContentAlignment.MiddleRight;

			throw new ArgumentOutOfRangeException("horizontalAlignment");
		}

		public static Tuple<HorizontalAlignment, VerticalAlignment> Parse(System.Windows.Forms.AnchorStyles anchor)
		{
			if (anchor == (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top)) return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Left, VerticalAlignment.Top);
			if (anchor == (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom)) return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Left, VerticalAlignment.Bottom);
			if (anchor == (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.None)) return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Left, VerticalAlignment.Center);
			if (anchor == (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)) return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Left, VerticalAlignment.Fill);

			if (anchor == (System.Windows.Forms.AnchorStyles.None | System.Windows.Forms.AnchorStyles.Top)) new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Top);
			if (anchor == (System.Windows.Forms.AnchorStyles.None | System.Windows.Forms.AnchorStyles.Bottom)) return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);
			if (anchor == (System.Windows.Forms.AnchorStyles.None | System.Windows.Forms.AnchorStyles.None)) return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Center);
			if (anchor == (System.Windows.Forms.AnchorStyles.None | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)) return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Fill);

			if (anchor == (System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top)) return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Right, VerticalAlignment.Top);
			if (anchor == (System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom)) return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Right, VerticalAlignment.Bottom);
			if (anchor == (System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.None)) return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Right, VerticalAlignment.Center);
			if (anchor == (System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)) return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Right, VerticalAlignment.Fill);

			if (anchor == (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top)) return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Fill, VerticalAlignment.Top);
			if (anchor == (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom)) return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Fill, VerticalAlignment.Bottom);
			if (anchor == (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.None)) return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Fill, VerticalAlignment.Center);
			if (anchor == (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)) return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Fill, VerticalAlignment.Fill);

			return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Left, VerticalAlignment.Top);
		}

		public static System.Windows.Forms.AnchorStyles ParseAnchor(HorizontalAlignment horizontal, VerticalAlignment vertical)
		{
			if (horizontal == HorizontalAlignment.Left && vertical == VerticalAlignment.Top) return System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
			if (horizontal == HorizontalAlignment.Left && vertical == VerticalAlignment.Bottom) return System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom;
			if (horizontal == HorizontalAlignment.Left && vertical == VerticalAlignment.Center) return System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.None;
			if (horizontal == HorizontalAlignment.Left && vertical == VerticalAlignment.Fill) return System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;

			if (horizontal == HorizontalAlignment.Center && vertical == VerticalAlignment.Top) return System.Windows.Forms.AnchorStyles.None | System.Windows.Forms.AnchorStyles.Top;
			if (horizontal == HorizontalAlignment.Center && vertical == VerticalAlignment.Bottom) return System.Windows.Forms.AnchorStyles.None | System.Windows.Forms.AnchorStyles.Bottom;
			if (horizontal == HorizontalAlignment.Center && vertical == VerticalAlignment.Center) return System.Windows.Forms.AnchorStyles.None | System.Windows.Forms.AnchorStyles.None;
			if (horizontal == HorizontalAlignment.Center && vertical == VerticalAlignment.Fill) return System.Windows.Forms.AnchorStyles.None | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;

			if (horizontal == HorizontalAlignment.Right && vertical == VerticalAlignment.Top) return System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
			if (horizontal == HorizontalAlignment.Right && vertical == VerticalAlignment.Bottom) return System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
			if (horizontal == HorizontalAlignment.Right && vertical == VerticalAlignment.Center) return System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.None;
			if (horizontal == HorizontalAlignment.Right && vertical == VerticalAlignment.Fill) return System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;

			if (horizontal == HorizontalAlignment.Fill && vertical == VerticalAlignment.Top) return System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
			if (horizontal == HorizontalAlignment.Fill && vertical == VerticalAlignment.Bottom) return System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
			if (horizontal == HorizontalAlignment.Fill && vertical == VerticalAlignment.Center) return System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.None;
			if (horizontal == HorizontalAlignment.Fill && vertical == VerticalAlignment.Fill) return System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;

			return System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
		}

		public static HorizontalAlignment Parse(System.Windows.Forms.HorizontalAlignment textAlign)
		{
			switch (textAlign)
			{
				case System.Windows.Forms.HorizontalAlignment.Center:
					return HorizontalAlignment.Center;

				case System.Windows.Forms.HorizontalAlignment.Left:
					return HorizontalAlignment.Left;

				case System.Windows.Forms.HorizontalAlignment.Right:
					return HorizontalAlignment.Right;
			}

			return HorizontalAlignment.Left;
		}

		public static System.Windows.Forms.HorizontalAlignment Parse(HorizontalAlignment horizontalAlign)
		{
			switch (horizontalAlign)
			{
				case HorizontalAlignment.Center:
					return System.Windows.Forms.HorizontalAlignment.Center;

				case HorizontalAlignment.Left:
					return System.Windows.Forms.HorizontalAlignment.Left;

				case HorizontalAlignment.Right:
					return System.Windows.Forms.HorizontalAlignment.Right;

				case HorizontalAlignment.Fill:
					return System.Windows.Forms.HorizontalAlignment.Left;
			}

			return System.Windows.Forms.HorizontalAlignment.Left;
		}

		public static void DrawBorders(System.Windows.Forms.Control control, System.Windows.Forms.PaintEventArgs pevent)
		{
			if (((IControl)control).BorderWidth == null)
			{
				return;
			}

			var color = ((IControl) control).BorderColor;

			if (color == null)
			{
				return;
			}

			//calculate the 4 points or coordinates of the border
			Point p1 = control.Bounds.Location; //top left

			Point p2 = control.Bounds.Location;
			p2.Offset(control.Width, 0); //top right

			Point p3 = control.Bounds.Location;
			p3.Offset(control.Width, control.Height); //bottom right

			Point p4 = control.Bounds.Location;
			p4.Offset(0, control.Height); //bottom left

			//draw custom border here
			pevent.Graphics.DrawLine(new Pen(color, (float) ((IControl) control).BorderWidth.Top), p1, p2); //top
			pevent.Graphics.DrawLine(new Pen(color, (float) ((IControl) control).BorderWidth.Right), p2, p3); //right
			pevent.Graphics.DrawLine(new Pen(color, (float) ((IControl) control).BorderWidth.Bottom), p3, p4); //bottom
			pevent.Graphics.DrawLine(new Pen(color, (float) ((IControl) control).BorderWidth.Left), p4, p1); //left
		}

		public static void SetBackgroundImage(System.Windows.Forms.Control control, System.Windows.Forms.PaintEventArgs pevent)
		{
			var backgroundImage = ((IContainer) control).BackgroundImage;
			var image = ((System.Windows.Forms.PictureBox) backgroundImage)?.Image;

			if (control.BackgroundImage != image)
			{
				control.BackgroundImage = image;
			}
		}
	}
}