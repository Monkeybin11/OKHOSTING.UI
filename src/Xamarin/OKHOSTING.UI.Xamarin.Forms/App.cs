using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using OKHOSTING.UI.Xamarin.Forms.Controls;
using OKHOSTING.UI.Xamarin.Forms.Controls.Layouts;
using System;

namespace OKHOSTING.UI.Xamarin.Forms
{
	public class App : UI.App
	{
		public App()
		{
			Page = new Page();
		}

		public override void Finish()
		{
			base.Finish();
		}

		public override T CreateControl<T>()
		{
			T result = null;

			if (typeof(T) == typeof(IAutocomplete))
			{
				result = new Autocomplete() as T;
			}
			else if (typeof(T) == typeof(IButton))
			{
				result = new Button() as T;
			}
			else if (typeof(T) == typeof(ICalendar))
			{
				result = new Calendar() as T;
			}
			else if (typeof(T) == typeof(ICheckBox))
			{
				result = new CheckBox() as T;
			}
			else if (typeof(T) == typeof(IHyperLink))
			{
				result = new HyperLink() as T;
			}
			else if (typeof(T) == typeof(IImage))
			{
				result = new Image() as T;
			}
			else if (typeof(T) == typeof(ILabel))
			{
				result = new Label() as T;
			}
			else if (typeof(T) == typeof(ILabelButton))
			{
				result = new LabelButton() as T;
			}
			else if (typeof(T) == typeof(IListPicker))
			{
				result = new ListPicker() as T;
			}
			else if (typeof(T) == typeof(IPasswordTextBox))
			{
				result = new PasswordTextBox() as T;
			}
			else if (typeof(T) == typeof(ITextArea))
			{
				result = new TextArea() as T;
			}
			else if (typeof(T) == typeof(ITextBox))
			{
				result = new TextBox() as T;
			}
			else if (typeof(T) == typeof(IGrid))
			{
				result = new Grid() as T;
			}
			else if (typeof(T) == typeof(IStack))
			{
				result = new Stack() as T;
			}

			OnControlCreated(result);

			return result;
		}

		public virtual Color Parse(global::Xamarin.Forms.Color color)
		{
			return new Color((int) color.A, (int) color.R, (int) color.G, (int) color.B);
		}

		public virtual global::Xamarin.Forms.Color Parse(Color color)
		{
			return global::Xamarin.Forms.Color.FromRgba(color.Alpha, color.Red, color.Green, color.Blue);
		}

		public virtual HorizontalAlignment Parse(global::Xamarin.Forms.LayoutAlignment horizontalAlignment)
		{
			switch (horizontalAlignment)
			{
				case global::Xamarin.Forms.LayoutAlignment.Start:
					return HorizontalAlignment.Left;

				case global::Xamarin.Forms.LayoutAlignment.Center:
					return HorizontalAlignment.Center;

				case global::Xamarin.Forms.LayoutAlignment.End:
					return HorizontalAlignment.Right;

				case global::Xamarin.Forms.LayoutAlignment.Fill:
					return HorizontalAlignment.Fill;
			}

			return HorizontalAlignment.Left;
		}

		public virtual global::Xamarin.Forms.LayoutAlignment Parse(HorizontalAlignment horizontalAlignment)
		{
			switch (horizontalAlignment)
			{
				case HorizontalAlignment.Left:
					return global::Xamarin.Forms.LayoutAlignment.Start;

				case HorizontalAlignment.Center:
					return global::Xamarin.Forms.LayoutAlignment.Center;

				case HorizontalAlignment.Right:
					return global::Xamarin.Forms.LayoutAlignment.End;

				case HorizontalAlignment.Fill:
					return global::Xamarin.Forms.LayoutAlignment.Fill;
			}

			throw new ArgumentOutOfRangeException("horizontalAlignment");
		}

		public virtual VerticalAlignment ParseVerticalAlignment(global::Xamarin.Forms.LayoutAlignment verticalAlignment)
		{
			switch (verticalAlignment)
			{
				case global::Xamarin.Forms.LayoutAlignment.Start:
					return VerticalAlignment.Top;

				case global::Xamarin.Forms.LayoutAlignment.Center:
					return VerticalAlignment.Center;

				case global::Xamarin.Forms.LayoutAlignment.End:
					return VerticalAlignment.Bottom;

				case global::Xamarin.Forms.LayoutAlignment.Fill:
					return VerticalAlignment.Fill;
			}

			return VerticalAlignment.Top;
		}

		public virtual global::Xamarin.Forms.LayoutAlignment Parse(VerticalAlignment verticalAlignment)
		{
			switch (verticalAlignment)
			{
				case VerticalAlignment.Top:
					return global::Xamarin.Forms.LayoutAlignment.Start;

				case VerticalAlignment.Center:
					return global::Xamarin.Forms.LayoutAlignment.Center;

				case VerticalAlignment.Bottom:
					return global::Xamarin.Forms.LayoutAlignment.End;

				case VerticalAlignment.Fill:
					return global::Xamarin.Forms.LayoutAlignment.Fill;
			}

			return global::Xamarin.Forms.LayoutAlignment.Start;
		}

		public HorizontalAlignment Parse(global::Xamarin.Forms.TextAlignment textAlignment)
		{
			switch (textAlignment)
			{
				case global::Xamarin.Forms.TextAlignment.Start:
					return HorizontalAlignment.Left;

				case global::Xamarin.Forms.TextAlignment.Center:
					return HorizontalAlignment.Center;

				case global::Xamarin.Forms.TextAlignment.End:
					return HorizontalAlignment.Right;
			}

			return HorizontalAlignment.Left;
		}

		public global::Xamarin.Forms.TextAlignment ParseTextAlignment(HorizontalAlignment alignment)
		{
			switch (alignment)
			{
				case HorizontalAlignment.Left:
					return global::Xamarin.Forms.TextAlignment.Start;

				case HorizontalAlignment.Center:
					return global::Xamarin.Forms.TextAlignment.Center;

				case HorizontalAlignment.Right:
					return global::Xamarin.Forms.TextAlignment.End;

				case HorizontalAlignment.Fill:
					return global::Xamarin.Forms.TextAlignment.Start;
			}

			return global::Xamarin.Forms.TextAlignment.Start;
		}

		public static new App Current
		{
			get
			{
				var app = (App) UI.App.Current;

				if (app == null)
				{
					app = new App();
					UI.App.Current = app;
				}

				return app;
			}
		}
	}
}