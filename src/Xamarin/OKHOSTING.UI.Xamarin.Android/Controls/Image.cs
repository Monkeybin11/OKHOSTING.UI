using System;
using System.Collections.Generic;
using System.IO;
using Android.Content;
using Android.Widget;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Android.Controls
{
	public class Image: ImageView, IImage
	{
		public Image(Context context) : base(context)
		{
		}

		public string Name
		{
			get;
			set;
		}

		public bool Visible
		{
			get
			{
				return base.Visibility == global::Android.Views.ViewStates.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = global::Android.Views.ViewStates.Visible;
				}
				else
				{
					base.Visibility = global::Android.Views.ViewStates.Invisible;
				}
			}
		}

		public Thickness Margin
		{
			get
			{
				return new Thickness(base.PaddingLeft, base.PaddingTop, base.PaddingRight, base.PaddingBottom);
			}
			set
			{
				base.SetPadding((int) (value.Left ?? 0), (int) (value.Top ?? 0), (int) (value.Right ?? 0), (int) (value.Bottom ?? 0));
			}
		}

		Color _BackgroundColor;

		public Color BackgroundColor
		{
			get
			{
				return _BackgroundColor;
			}
			set
			{
				_BackgroundColor = value;

				if (value == null)
				{
					base.SetBackgroundColor(Platform.Parse(new Color(0, 0, 0, 0)));
				}
				else
				{
					base.SetBackgroundColor(Platform.Parse(value));
				}
			}
		}

		public Color BorderColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Thickness BorderWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public HorizontalAlignment HorizontalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public VerticalAlignment VerticalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		double? IControl.Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		double? IControl.Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		object IControl.Tag { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void LoadFromFile(string filePath)
		{
			throw new NotImplementedException();
		}

		public void LoadFromStream(Stream stream)
		{
			throw new NotImplementedException();
		}

		public void LoadFromUrl(Uri url)
		{
		}

		public void LoadFromVideoFile(string filePath)
		{
			throw new NotImplementedException();
		}
	}
}