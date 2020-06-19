using System;
using System.Collections;

namespace OKHOSTING.UI.Xamarin.iOS
{
	public static class Platform
	{
		public static UIKit.UITextAlignment Parse(HorizontalAlignment value)
		{
			switch (value)
			{
				case HorizontalAlignment.Center:
					return UIKit.UITextAlignment.Center;
				
				case HorizontalAlignment.Fill:
					return UIKit.UITextAlignment.Justified;

				case HorizontalAlignment.Left:
					return UIKit.UITextAlignment.Left;

				case HorizontalAlignment.Right:
					return UIKit.UITextAlignment.Right;

				default:
					throw new ArgumentOutOfRangeException(nameof(value));
			}
		}

		public static HorizontalAlignment Parse(UIKit.UITextAlignment value)
		{
			switch (value)
			{
				case UIKit.UITextAlignment.Center:
					return HorizontalAlignment.Center;

				case UIKit.UITextAlignment.Justified:
					return HorizontalAlignment.Fill;

				case UIKit.UITextAlignment.Left:
					return HorizontalAlignment.Left;

				case UIKit.UITextAlignment.Right:
					return HorizontalAlignment.Right;

				default:
					throw new ArgumentOutOfRangeException(nameof(value));
			}
		}
	}
}