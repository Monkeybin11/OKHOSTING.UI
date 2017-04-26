using System;
using System.Linq;

namespace OKHOSTING.UI.Net4.Console
{
	public class Platform : UI.Platform
	{
		protected readonly Random Random = new Random();

		public override T Create<T>()
		{
			T control = base.Create<T>();

			//give a default name to all controls to allow events to be correclty triggered
			if (string.IsNullOrWhiteSpace(control.Name))
			{
				control.Name = "ctr_" + Random.Next();
			}

			return control;
		}

		public override void Finish()
		{
			base.Finish();
			System.Web.Security.FormsAuthentication.SignOut();
		}

		//virtual

		public virtual Thickness Parse(ConsoleFramework.Core.Thickness thickness)
		{
			if (thickness == null)
			{
				return null;
			}

			return new Thickness(thickness.Left, thickness.Top, thickness.Right, thickness.Bottom);
		}

		public virtual ConsoleFramework.Core.Thickness Parse(Thickness thickness)
		{
			if (thickness == null)
			{
				return null;
			}

			return new ConsoleFramework.Core.Thickness((int) thickness.Left, (int) thickness.Top, (int) thickness.Right, (int) thickness.Bottom);
		}

		public virtual Color Parse(System.Drawing.Color color)
		{
			return new Color(color.A, color.R, color.G, color.B);
		}

		public virtual System.Drawing.Color Parse(Color color)
		{
			return System.Drawing.Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue);
		}

		public virtual ConsoleFramework.Controls.HorizontalAlignment Parse(HorizontalAlignment value)
		{
			switch (value)
			{
				case HorizontalAlignment.Center:
					return ConsoleFramework.Controls.HorizontalAlignment.Center;

				case HorizontalAlignment.Fill:
					return ConsoleFramework.Controls.HorizontalAlignment.Stretch;

				case HorizontalAlignment.Left:
					return ConsoleFramework.Controls.HorizontalAlignment.Left;

				case HorizontalAlignment.Right:
					return ConsoleFramework.Controls.HorizontalAlignment.Right;
			}

			throw new ArgumentOutOfRangeException(nameof(value));
		}

		public virtual ConsoleFramework.Controls.VerticalAlignment Parse(VerticalAlignment value)
		{
			switch (value)
			{
				case VerticalAlignment.Center:
					return ConsoleFramework.Controls.VerticalAlignment.Center;

				case VerticalAlignment.Fill:
					return ConsoleFramework.Controls.VerticalAlignment.Stretch;

				case VerticalAlignment.Top:
					return ConsoleFramework.Controls.VerticalAlignment.Top;

				case VerticalAlignment.Bottom:
					return ConsoleFramework.Controls.VerticalAlignment.Bottom;
			}

			throw new ArgumentOutOfRangeException(nameof(value));
		}

		public virtual HorizontalAlignment Parse(ConsoleFramework.Controls.HorizontalAlignment value)
		{
			switch (value)
			{
				case ConsoleFramework.Controls.HorizontalAlignment.Center:
					return HorizontalAlignment.Center;

				case ConsoleFramework.Controls.HorizontalAlignment.Stretch:
					return HorizontalAlignment.Fill;

				case ConsoleFramework.Controls.HorizontalAlignment.Left:
					return HorizontalAlignment.Left;

				case ConsoleFramework.Controls.HorizontalAlignment.Right:
					return HorizontalAlignment.Right;
			}

			throw new ArgumentOutOfRangeException(nameof(value));
		}

		public virtual VerticalAlignment Parse(ConsoleFramework.Controls.VerticalAlignment value)
		{
			switch (value)
			{
				case ConsoleFramework.Controls.VerticalAlignment.Center:
					return VerticalAlignment.Center;

				case ConsoleFramework.Controls.VerticalAlignment.Stretch:
					return VerticalAlignment.Fill;

				case ConsoleFramework.Controls.VerticalAlignment.Top:
					return VerticalAlignment.Top;

				case ConsoleFramework.Controls.VerticalAlignment.Bottom:
					return VerticalAlignment.Bottom;
			}

			throw new ArgumentOutOfRangeException(nameof(value));
		}

		public virtual void AddCssClass(System.Web.UI.WebControls.WebControl control, string className)
		{
			if (!control.CssClass.Contains(className))
			{
				control.CssClass = control.CssClass + " " + className;
			}
		}

		public virtual void RemoveCssClass(System.Web.UI.WebControls.WebControl control, string className)
		{
			control.CssClass = control.CssClass.Replace(className, string.Empty).Trim();
		}

		public virtual void RemoveCssClassesStartingWith(System.Web.UI.WebControls.WebControl control, string className)
		{
			var cssClasses = control.CssClass.Split().ToList();

			for (int i = 0; i < cssClasses.Count; i++)
			{
				if (cssClasses[i].StartsWith(className))
				{
					cssClasses.RemoveAt(i);
					i--;
				}
			}

			control.CssClass = control.CssClass.Replace(className, string.Empty).Trim();
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