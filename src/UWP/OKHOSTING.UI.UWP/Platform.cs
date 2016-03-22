using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.UI.UWP.Controls;
using OKHOSTING.UI.UWP.Controls.Layout;
using System;
using Windows.UI.Xaml;

namespace OKHOSTING.UI.UWP
{
	public class Platform : UI.Platform
	{
		public override void Finish()
		{
			base.Finish();
			Windows.UI.Xaml.Application.Current.Exit();
		}

		//virtual

		public virtual Color Parse(Windows.UI.Color color)
		{
			return new Color(color.A, color.R, color.G, color.B);
		}

		public virtual Windows.UI.Color Parse(Color color)
		{
			return Windows.UI.Color.FromArgb((byte)color.Alpha, (byte)color.Red, (byte)color.Green, (byte)color.Blue);
		}

		public virtual Windows.UI.Xaml.Thickness Parse(Thickness thickness)
		{
			Windows.UI.Xaml.Thickness nativeThickness = new Windows.UI.Xaml.Thickness();

			if (thickness.Left.HasValue) nativeThickness.Left = (int)thickness.Left;
			if (thickness.Top.HasValue) nativeThickness.Top = (int)thickness.Top;
			if (thickness.Right.HasValue) nativeThickness.Right = (int)thickness.Right;
			if (thickness.Bottom.HasValue) nativeThickness.Bottom = (int)thickness.Bottom;

			return nativeThickness;
		}

		public virtual Thickness Parse(Windows.UI.Xaml.Thickness nativeThickness)
		{
			return new Thickness(nativeThickness.Left, nativeThickness.Top, nativeThickness.Right, nativeThickness.Bottom);
		}

		public virtual HorizontalAlignment Parse(Windows.UI.Xaml.HorizontalAlignment horizontalAlignment)
		{
			switch (horizontalAlignment)
			{
				case Windows.UI.Xaml.HorizontalAlignment.Left:
					return HorizontalAlignment.Left;

				case Windows.UI.Xaml.HorizontalAlignment.Center:
					return HorizontalAlignment.Center;

				case Windows.UI.Xaml.HorizontalAlignment.Right:
					return HorizontalAlignment.Right;

				case Windows.UI.Xaml.HorizontalAlignment.Stretch:
					return HorizontalAlignment.Fill;
			}

			throw new ArgumentOutOfRangeException("horizontalAlignment");
		}

		public virtual Windows.UI.Xaml.HorizontalAlignment Parse(HorizontalAlignment horizontalAlignment)
		{
			switch (horizontalAlignment)
			{
				case HorizontalAlignment.Left:
					return Windows.UI.Xaml.HorizontalAlignment.Left;

				case HorizontalAlignment.Center:
					return Windows.UI.Xaml.HorizontalAlignment.Center;

				case HorizontalAlignment.Right:
					return Windows.UI.Xaml.HorizontalAlignment.Right;

				case HorizontalAlignment.Fill:
					return Windows.UI.Xaml.HorizontalAlignment.Stretch;
			}

			throw new ArgumentOutOfRangeException("horizontalAlignment");
		}

		public virtual VerticalAlignment Parse(Windows.UI.Xaml.VerticalAlignment verticalAlignment)
		{
			switch (verticalAlignment)
			{
				case Windows.UI.Xaml.VerticalAlignment.Top:
					return VerticalAlignment.Top;

				case Windows.UI.Xaml.VerticalAlignment.Center:
					return VerticalAlignment.Center;

				case Windows.UI.Xaml.VerticalAlignment.Bottom:
					return VerticalAlignment.Bottom;

				case Windows.UI.Xaml.VerticalAlignment.Stretch:
					return VerticalAlignment.Fill;
			}

			throw new ArgumentOutOfRangeException("horizontalAlignment");
		}

		public virtual Windows.UI.Xaml.VerticalAlignment Parse(VerticalAlignment verticalAlignment)
		{
			switch (verticalAlignment)
			{
				case VerticalAlignment.Top:
					return Windows.UI.Xaml.VerticalAlignment.Top;

				case VerticalAlignment.Center:
					return Windows.UI.Xaml.VerticalAlignment.Center;

				case VerticalAlignment.Bottom:
					return Windows.UI.Xaml.VerticalAlignment.Bottom;

				case VerticalAlignment.Fill:
					return Windows.UI.Xaml.VerticalAlignment.Stretch;
			}

			throw new ArgumentOutOfRangeException("verticalAlignment");
		}


		public HorizontalAlignment Parse(TextAlignment textAlignment)
		{
			switch (textAlignment)
			{
				case TextAlignment.Left:
					return HorizontalAlignment.Left;

				case TextAlignment.Center:
					return HorizontalAlignment.Center;

				case TextAlignment.Right:
					return HorizontalAlignment.Right;

				case TextAlignment.Justify:
					return HorizontalAlignment.Fill;
			}

			return HorizontalAlignment.Left;
		}

		public TextAlignment ParseTextAlignment(HorizontalAlignment alignment)
		{
			switch (alignment)
			{
				case HorizontalAlignment.Left:
					return TextAlignment.Left;

				case HorizontalAlignment.Center:
					return TextAlignment.Center;

				case HorizontalAlignment.Right:
					return TextAlignment.Right;

				case HorizontalAlignment.Fill:
					return TextAlignment.Justify;
			}

			return TextAlignment.Left;
		}

		//static

		public static new Platform Current
		{
			get
			{
				var platform = (Platform)UI.Platform.Current;

				if (platform == null)
				{
					platform = new Platform();
					UI.Platform.Current = platform;
				}

				return platform;
			}
		}
	}
}