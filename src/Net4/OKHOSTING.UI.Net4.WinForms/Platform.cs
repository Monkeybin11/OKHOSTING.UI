using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Net4.WinForms
{
	public class Platform : UI.Platform
	{
		public override void Finish()
		{
			base.Finish();
			System.Windows.Forms.Application.Exit();
		}

		public override T Create<T>()
		{
			var control = base.Create<T>() as System.Windows.Forms.Control;

			//control.Anchor = ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			//| System.Windows.Forms.AnchorStyles.Left)
			//| System.Windows.Forms.AnchorStyles.Right));

			return control as T;
		}

		//virtual

		public virtual Color Parse(System.Drawing.Color color)
		{
			if (color == null)
			{
				return new Color(255, 0, 0, 0);
			}

			return new Color(color.A, color.R, color.G, color.B);
		}

		public virtual System.Drawing.Color Parse(Color color)
		{
			if (color == null)
			{
				return default(System.Drawing.Color);
			}

			return System.Drawing.Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue);
		}

		public virtual System.Windows.Forms.Padding Parse(Thickness thickness)
		{
			if (thickness == null)
			{
				return default(System.Windows.Forms.Padding);
			}

			System.Windows.Forms.Padding padding = new System.Windows.Forms.Padding();

			if (thickness.Left.HasValue) padding.Left = (int)thickness.Left;
			if (thickness.Top.HasValue) padding.Top = (int)thickness.Top;
			if (thickness.Right.HasValue) padding.Right = (int)thickness.Right;
			if (thickness.Bottom.HasValue) padding.Bottom = (int)thickness.Bottom;

			return padding;
		}

		public virtual Thickness Parse(System.Windows.Forms.Padding margin)
		{
			return new Thickness(margin.Left, margin.Top, margin.Right, margin.Bottom);
		}

		public virtual Tuple<HorizontalAlignment, VerticalAlignment> Parse(System.Drawing.ContentAlignment alignment)
		{
			switch (alignment)
			{
				case System.Drawing.ContentAlignment.BottomCenter:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);

				case System.Drawing.ContentAlignment.BottomLeft:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);
				case
				System.Drawing.ContentAlignment.BottomRight:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);

				case System.Drawing.ContentAlignment.MiddleCenter:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);

				case System.Drawing.ContentAlignment.MiddleLeft:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);

				case System.Drawing.ContentAlignment.MiddleRight:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);

				case System.Drawing.ContentAlignment.TopLeft:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);
				case System.Drawing.ContentAlignment.TopCenter:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);
				case System.Drawing.ContentAlignment.TopRight:
					return new Tuple<HorizontalAlignment, VerticalAlignment>(HorizontalAlignment.Center, VerticalAlignment.Bottom);
			}

			throw new ArgumentOutOfRangeException("alignment");
		}

		public virtual System.Drawing.ContentAlignment ParseContentAlignment(HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment)
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

		public virtual Tuple<HorizontalAlignment, VerticalAlignment> Parse(System.Windows.Forms.AnchorStyles anchor)
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

		public virtual System.Windows.Forms.AnchorStyles ParseAnchor(HorizontalAlignment horizontal, VerticalAlignment vertical)
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

		public virtual HorizontalAlignment Parse(System.Windows.Forms.HorizontalAlignment textAlign)
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

		public virtual System.Windows.Forms.HorizontalAlignment Parse(HorizontalAlignment horizontalAlign)
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

		//static

		public static new Platform Current
		{
			get
			{
				var platform = (Platform) UI.Platform.Current;

				if (platform == null)
				{
					platform = new Platform();
					UI.Platform.Current = platform;
				}

				return platform;
			}
		}

		public virtual void DrawBorders(System.Windows.Forms.Control control, System.Windows.Forms.PaintEventArgs pevent)
		{
			//calculate the 4 points or coordinates of the border
			System.Drawing.Point p1 = control.Bounds.Location; //top left

			System.Drawing.Point p2 = control.Bounds.Location;
			p2.Offset(control.Width, 0); //top right

			System.Drawing.Point p3 = control.Bounds.Location; //bottom left
			p2.Offset(0, control.Height * -1); //top right

			System.Drawing.Point p4 = control.Bounds.Location; //bottom right
			p2.Offset(control.Width, control.Height * -1); //top right

			//draw custom border here
			if (((IControl) control).BorderColor != null && ((IControl) control).BorderWidth != null)
			{
				pevent.Graphics.DrawLine(new System.Drawing.Pen(Platform.Current.Parse(((IControl)control).BorderColor), (float)((IControl)control).BorderWidth.Left), p4, p1); //left
				pevent.Graphics.DrawLine(new System.Drawing.Pen(Platform.Current.Parse(((IControl)control).BorderColor), (float)((IControl)control).BorderWidth.Left), p1, p2); //top
				pevent.Graphics.DrawLine(new System.Drawing.Pen(Platform.Current.Parse(((IControl)control).BorderColor), (float)((IControl)control).BorderWidth.Left), p2, p3); //right
				pevent.Graphics.DrawLine(new System.Drawing.Pen(Platform.Current.Parse(((IControl)control).BorderColor), (float)((IControl)control).BorderWidth.Left), p3, p4); //bottom
			}
		}
	}
}