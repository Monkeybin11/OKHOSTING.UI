using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using OKHOSTING.UI.Xamarin.Mac.Controls;
using OKHOSTING.UI.Xamarin.Mac.Controls.Layout;

namespace OKHOSTING.UI.Xamarin.Mac
{
	public class Platform
	{
		public override T Create<T>()
		{
			T control = null;

			if (typeof(T) == typeof(IAutocomplete))
			{
				control = new Autocomplete() as T;
			}
			else if (typeof(T) == typeof(IButton))
			{
				control = new Button() as T;
			}
			else if (typeof(T) == typeof(ICalendar))
			{
				control = new Calendar() as T;
			}
			else if (typeof(T) == typeof(ICheckBox))
			{
				control = new CheckBox() as T;
			}
			else if (typeof(T) == typeof(IHyperLink))
			{
				control = new HyperLink() as T;
			}
			else if (typeof(T) == typeof(IImage))
			{
				control = new Image() as T;
			}
			else if (typeof(T) == typeof(ILabel))
			{
				control = new Label() as T;
			}
			else if (typeof(T) == typeof(ILabelButton))
			{
				control = new LabelButton() as T;
			}
			else if (typeof(T) == typeof(IListPicker))
			{
				control = new ListPicker() as T;
			}
			else if (typeof(T) == typeof(IPasswordTextBox))
			{
				control = new PasswordTextBox() as T;
			}
			else if (typeof(T) == typeof(ITextArea))
			{
				control = new TextArea() as T;
			}
			else if (typeof(T) == typeof(ITextBox))
			{
				control = new TextBox() as T;
			}
			else if (typeof(T) == typeof(IGrid))
			{
				control = new Grid() as T;
			}
			else if (typeof(T) == typeof(IStack))
			{
				control = new Stack() as T;
			}

			return control;
		}

		public override void Finish()
		{
			base.Finish();
		}

		//virtual

		public virtual Color Parse(global::Xamarin.Mac.Color color)
		{
			return new Color((int) color.A, (int) color.R, (int) color.G, (int) color.B);
		}

		public virtual global::Xamarin.Mac.Color Parse(Color color)
		{
			return global::Xamarin.Mac.Color.FromRgba(color.Alpha, color.Red, color.Green, color.Blue);
		}

		public virtual HorizontalAlignment Parse(global::Xamarin.Mac.LayoutAlignment horizontalAlignment)
		{
			switch (horizontalAlignment)
			{
			case global::Xamarin.Mac.LayoutAlignment.Start:
				return HorizontalAlignment.Left;

			case global::Xamarin.Mac.LayoutAlignment.Center:
				return HorizontalAlignment.Center;

			case global::Xamarin.Mac.LayoutAlignment.End:
				return HorizontalAlignment.Right;

			case global::Xamarin.Mac.LayoutAlignment.Fill:
				return HorizontalAlignment.Fill;
			}

			return HorizontalAlignment.Left;
		}

		public virtual global::Xamarin.Mac.LayoutAlignment Parse(HorizontalAlignment horizontalAlignment)
		{
			switch (horizontalAlignment)
			{
			case HorizontalAlignment.Left:
				return global::Xamarin.Mac.LayoutAlignment.Start;

			case HorizontalAlignment.Center:
				return global::Xamarin.Mac.LayoutAlignment.Center;

			case HorizontalAlignment.Right:
				return global::Xamarin.Mac.LayoutAlignment.End;

			case HorizontalAlignment.Fill:
				return global::Xamarin.Mac.LayoutAlignment.Fill;
			}

			throw new ArgumentOutOfRangeException("horizontalAlignment");
		}

		public virtual VerticalAlignment ParseVerticalAlignment(global::Xamarin.Mac.LayoutAlignment verticalAlignment)
		{
			switch (verticalAlignment)
			{
			case global::Xamarin.Mac.LayoutAlignment.Start:
				return VerticalAlignment.Top;

			case global::Xamarin.Mac.LayoutAlignment.Center:
				return VerticalAlignment.Center;

			case global::Xamarin.Mac.LayoutAlignment.End:
				return VerticalAlignment.Bottom;

			case global::Xamarin.Mac.LayoutAlignment.Fill:
				return VerticalAlignment.Fill;
			}

			return VerticalAlignment.Top;
		}

		public virtual global::Xamarin.Mac.LayoutAlignment Parse(VerticalAlignment verticalAlignment)
		{
			switch (verticalAlignment)
			{
			case VerticalAlignment.Top:
				return global::Xamarin.Mac.LayoutAlignment.Start;

			case VerticalAlignment.Center:
				return global::Xamarin.Mac.LayoutAlignment.Center;

			case VerticalAlignment.Bottom:
				return global::Xamarin.Mac.LayoutAlignment.End;

			case VerticalAlignment.Fill:
				return global::Xamarin.Mac.LayoutAlignment.Fill;
			}

			return global::Xamarin.Mac.LayoutAlignment.Start;
		}

		public HorizontalAlignment Parse(global::Xamarin.Mac.TextAlignment textAlignment)
		{
			switch (textAlignment)
			{
			case global::Xamarin.Mac.TextAlignment.Start:
				return HorizontalAlignment.Left;

			case global::Xamarin.Mac.TextAlignment.Center:
				return HorizontalAlignment.Center;

			case global::Xamarin.Mac.TextAlignment.End:
				return HorizontalAlignment.Right;
			}

			return HorizontalAlignment.Left;
		}

		public global::Xamarin.Mac.TextAlignment ParseTextAlignment(HorizontalAlignment alignment)
		{
			switch (alignment)
			{
			case HorizontalAlignment.Left:
				return global::Xamarin.Mac.TextAlignment.Start;

			case HorizontalAlignment.Center:
				return global::Xamarin.Mac.TextAlignment.Center;

			case HorizontalAlignment.Right:
				return global::Xamarin.Mac.TextAlignment.End;

			case HorizontalAlignment.Fill:
				return global::Xamarin.Mac.TextAlignment.Start;
			}

			return global::Xamarin.Mac.TextAlignment.Start;
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