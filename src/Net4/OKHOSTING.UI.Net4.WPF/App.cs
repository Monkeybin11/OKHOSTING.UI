using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using OKHOSTING.UI.Net4.WPF.Controls;
using OKHOSTING.UI.Net4.WPF.Controls.Layouts;
using System;
using System.Windows;

namespace OKHOSTING.UI.Net4.WPF
{
	public class App : UI.App
	{
		public override T Create<T>()
		{
			if (typeof(T) == typeof(IButton))
			{
				return new Button() as T;
			}

			if (typeof(T) == typeof(ILabel))
			{
				return new Label() as T;
			}

			if (typeof(T) == typeof(ITextBox))
			{
				return new TextBox() as T;
			}

			if (typeof(T) == typeof(IAutocomplete))
			{
				//return new Autocomplete() as T;
			}

			if (typeof(T) == typeof(IListPicker))
			{
				return new ListPicker() as T;
			}

			if (typeof(T) == typeof(IHyperLink))
			{
				return new HyperLink() as T;
			}

			if (typeof(T) == typeof(ITextArea))
			{
				return new TextArea() as T;
			}

			if (typeof(T) == typeof(IBooleanPicker))
			{
				return new BooleanPicker() as T;
			}

			if (typeof(T) == typeof(IImage))
			{
				return new Image() as T;
			}

			if (typeof(T) == typeof(IPasswordTextBox))
			{
				return new PasswordTextBox() as T;
			}

			if (typeof(T) == typeof(IStack))
			{
				return new Stack() as T;
			}

			if (typeof(T) == typeof(IGrid))
			{
				return new Grid() as T;
			}

			throw new NotSupportedException();
		}

		public override void Finish()
		{
			base.Finish();
			System.Windows.Application.Current.Shutdown();
		}

		internal virtual void SetPage(Page page)
		{
			this.Page = page;
		}

		public virtual Color Parse(System.Windows.Media.Color color)
		{
			return new Color(color.A, color.R, color.G, color.B);
		}

		public virtual System.Windows.Media.Color Parse(Color color)
		{
			return System.Windows.Media.Color.FromArgb((byte)color.Alpha, (byte)color.Red, (byte)color.Green, (byte)color.Blue);
		}

		public virtual System.Windows.Thickness Parse(Thickness thickness)
		{
			System.Windows.Thickness nativeThickness = new System.Windows.Thickness();

			if (thickness.Left.HasValue) nativeThickness.Left = (int)thickness.Left;
			if (thickness.Top.HasValue) nativeThickness.Top = (int)thickness.Top;
			if (thickness.Right.HasValue) nativeThickness.Right = (int)thickness.Right;
			if (thickness.Bottom.HasValue) nativeThickness.Bottom = (int)thickness.Bottom;

			return nativeThickness;
		}

		public virtual Thickness Parse(System.Windows.Thickness nativeThickness)
		{
			return new Thickness(nativeThickness.Left, nativeThickness.Top, nativeThickness.Right, nativeThickness.Bottom);
		}

		public virtual HorizontalAlignment Parse(System.Windows.HorizontalAlignment horizontalAlignment)
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

		public virtual System.Windows.HorizontalAlignment Parse(HorizontalAlignment horizontalAlignment)
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

		public virtual VerticalAlignment Parse(System.Windows.VerticalAlignment verticalAlignment)
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

		public virtual System.Windows.VerticalAlignment Parse(VerticalAlignment verticalAlignment)
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