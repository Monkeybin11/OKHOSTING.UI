using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using OKHOSTING.UI.Net4.WinForms.Controls;
using OKHOSTING.UI.Net4.WinForms.Controls.Layouts;

namespace OKHOSTING.UI.Net4.WinForms
{
	public partial class Page : System.Windows.Forms.Form, IPage
	{
		public Page()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Controller.CurrentPage = this;
			Controller.CurrentController.Start();
		}

		public IControl Content
		{
			get
			{
				if (base.Controls.Count == 0)
				{
					return null;
				}

				return (IControl) Controls[0];
			}

			set
			{
				Controls.Clear();

				if (value != null)
				{
					Controls.Add((System.Windows.Forms.Control) value);
				}
			}
		}

		public string Title
		{
			get
			{
				return base.Text;
			}

			set
			{
				base.Text = value;
			}
		}

		double IPage.Width
		{
			get
			{
				return base.Width;
			}
		}

		double IPage.Height
		{
			get
			{
				return base.Height;
			}
		}

		public T Create<T>() where T : class, IControl
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

			if (typeof(T) == typeof(IPasswordTextBox))
			{
				return new PasswordTextBox() as T;
			}

			if (typeof(T) == typeof(IGrid))
			{
				return new Grid() as T;
			}

			throw new NotSupportedException();
		}

		protected override void OnResize(EventArgs e)
		{
			//Controller.CurrentPage = this;
			//make responsive
			Controller.CurrentController.Start();

			base.OnResize(e);
		}

		#region Static 

		public static Color Parse(System.Drawing.Color color)
		{
			return new Color(color.A, color.R, color.G, color.B);
		}

		public static System.Drawing.Color Parse(Color color)
		{
			return System.Drawing.Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue);
		}

		public static System.Windows.Forms.Padding Parse(Thickness thickness)
		{
			System.Windows.Forms.Padding padding = new System.Windows.Forms.Padding();

			if (thickness.Left.HasValue) padding.Left = (int) thickness.Left;
			if (thickness.Top.HasValue) padding.Top = (int) thickness.Top;
			if (thickness.Right.HasValue) padding.Right = (int) thickness.Right;
			if (thickness.Bottom.HasValue) padding.Bottom = (int) thickness.Bottom;

			return padding;
        }

		public static Thickness Parse(System.Windows.Forms.Padding margin)
		{
			return new Thickness(margin.Left, margin.Top, margin.Right, margin.Bottom);
		}

		public static HorizontalAlignment GetHorizontalAlignment(System.Drawing.ContentAlignment alignment)
		{
			switch (alignment)
			{
				case System.Drawing.ContentAlignment.BottomCenter:
				case System.Drawing.ContentAlignment.MiddleCenter:
				case System.Drawing.ContentAlignment.TopCenter:
					return HorizontalAlignment.Center;

				case System.Drawing.ContentAlignment.BottomLeft:
				case System.Drawing.ContentAlignment.MiddleLeft:
				case System.Drawing.ContentAlignment.TopLeft:
					return HorizontalAlignment.Left;

				case System.Drawing.ContentAlignment.BottomRight:
				case System.Drawing.ContentAlignment.MiddleRight:
				case System.Drawing.ContentAlignment.TopRight:
					return HorizontalAlignment.Right;
			}

			throw new ArgumentOutOfRangeException("alignment");
		}

		public static VerticalAlignment GetVerticalAlignment(System.Drawing.ContentAlignment alignment)
		{
			switch (alignment)
			{
				case System.Drawing.ContentAlignment.BottomCenter:
				case System.Drawing.ContentAlignment.BottomLeft:
				case System.Drawing.ContentAlignment.BottomRight:
					return VerticalAlignment.Bottom;

				case System.Drawing.ContentAlignment.MiddleCenter:
				case System.Drawing.ContentAlignment.MiddleLeft:
				case System.Drawing.ContentAlignment.MiddleRight:
					return VerticalAlignment.Center;

				case System.Drawing.ContentAlignment.TopLeft:
				case System.Drawing.ContentAlignment.TopCenter:
				case System.Drawing.ContentAlignment.TopRight:
					return VerticalAlignment.Top;
			}

			throw new ArgumentOutOfRangeException("alignment");
		}

		public static System.Drawing.ContentAlignment GetContentAlignment(HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment)
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

		#endregion
	}
}
