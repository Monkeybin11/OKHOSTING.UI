using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using OKHOSTING.UI.Net4.WinForms.Controls;
using OKHOSTING.UI.Net4.WinForms.Controls.Layouts;
using System;

namespace OKHOSTING.UI.Net4.WinForms
{
	public class App : UI.App
	{
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

		public override void Start()
		{
			base.Start();

			Page = new Page();

            System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
			System.Windows.Forms.Application.Run((System.Windows.Forms.Form) Page);
		}

		public override void Finish()
		{
			base.Finish();
			System.Windows.Forms.Application.Exit();
		}

		#region Virtual

		public virtual Color Parse(System.Drawing.Color color)
		{
			return new Color(color.A, color.R, color.G, color.B);
		}

		public virtual System.Drawing.Color Parse(Color color)
		{
			return System.Drawing.Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue);
		}

		public virtual System.Windows.Forms.Padding Parse(Thickness thickness)
		{
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

		#endregion

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