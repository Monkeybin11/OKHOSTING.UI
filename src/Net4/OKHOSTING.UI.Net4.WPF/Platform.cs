using OKHOSTING.UI.Controls.Layout;
using System;
using System.Drawing;
using System.Windows;

namespace OKHOSTING.UI.Net4.WPF
{
	public static class Platform
	{
		public static void Finish()
		{
			Application.Current.Shutdown();
		}

		public static Color Parse(System.Windows.Media.Color color)
		{
			if (color == null)
			{
				return Color.FromArgb(255, 0, 0, 0);
			}

			return Color.FromArgb(color.A, color.R, color.G, color.B);
		}

		public static System.Windows.Media.Color Parse(Color color)
		{
			if (color == null)
			{
				return System.Windows.Media.Color.FromArgb(255, 0, 0, 0);
			}

			return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
		}

		public static System.Windows.Thickness Parse(Thickness thickness)
		{
			System.Windows.Thickness nativeThickness = new System.Windows.Thickness();

			nativeThickness.Left = (int)thickness.Left;
			nativeThickness.Top = (int)thickness.Top;
			nativeThickness.Right = (int)thickness.Right;
			nativeThickness.Bottom = (int)thickness.Bottom;

			return nativeThickness;
		}

		public static Thickness Parse(System.Windows.Thickness nativeThickness)
		{
			return new Thickness(nativeThickness.Left, nativeThickness.Top, nativeThickness.Right, nativeThickness.Bottom);
		}

		public static HorizontalAlignment Parse(System.Windows.HorizontalAlignment horizontalAlignment)
		{
			switch (horizontalAlignment)
			{
				case System.Windows.HorizontalAlignment.Left:
					return HorizontalAlignment.Left;

				case System.Windows.HorizontalAlignment.Center:
					return HorizontalAlignment.Center;

				case System.Windows.HorizontalAlignment.Right:
					return HorizontalAlignment.Right;

				case System.Windows.HorizontalAlignment.Stretch:
					return HorizontalAlignment.Fill;
			}

			throw new ArgumentOutOfRangeException("horizontalAlignment");
		}

		public static System.Windows.HorizontalAlignment Parse(HorizontalAlignment horizontalAlignment)
		{
			switch (horizontalAlignment)
			{
				case HorizontalAlignment.Left:
					return System.Windows.HorizontalAlignment.Left;

				case HorizontalAlignment.Center:
					return System.Windows.HorizontalAlignment.Center;

				case HorizontalAlignment.Right:
					return System.Windows.HorizontalAlignment.Right;

				case HorizontalAlignment.Fill:
					return System.Windows.HorizontalAlignment.Stretch;
			}

			throw new ArgumentOutOfRangeException("horizontalAlignment");
		}

		public static VerticalAlignment Parse(System.Windows.VerticalAlignment verticalAlignment)
		{
			switch (verticalAlignment)
			{
				case System.Windows.VerticalAlignment.Top:
					return VerticalAlignment.Top;

				case System.Windows.VerticalAlignment.Center:
					return VerticalAlignment.Center;

				case System.Windows.VerticalAlignment.Bottom:
					return VerticalAlignment.Bottom;

				case System.Windows.VerticalAlignment.Stretch:
					return VerticalAlignment.Fill;
			}

			throw new ArgumentOutOfRangeException("horizontalAlignment");
		}

		public static System.Windows.VerticalAlignment Parse(VerticalAlignment verticalAlignment)
		{
			switch (verticalAlignment)
			{
				case VerticalAlignment.Top:
					return System.Windows.VerticalAlignment.Top;

				case VerticalAlignment.Center:
					return System.Windows.VerticalAlignment.Center;

				case VerticalAlignment.Bottom:
					return System.Windows.VerticalAlignment.Bottom;

				case VerticalAlignment.Fill:
					return System.Windows.VerticalAlignment.Stretch;
			}

			throw new ArgumentOutOfRangeException("verticalAlignment");
		}

		public static HorizontalAlignment Parse(TextAlignment textAlignment)
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

		public static TextAlignment ParseTextAlignment(HorizontalAlignment alignment)
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

		public static void SetBackgroundImage(System.Windows.Controls.Panel control)
		{ 
			var backgroundImage = ((IContainer) control).BackgroundImage;
			var source = ((System.Windows.Controls.Image) backgroundImage)?.Source;

			if (((System.Windows.Media.ImageBrush) control.Background)?.ImageSource != source)
			{
				control.Background = new System.Windows.Media.ImageBrush(((System.Windows.Controls.Image) backgroundImage).Source);
			}
		}
	}
}