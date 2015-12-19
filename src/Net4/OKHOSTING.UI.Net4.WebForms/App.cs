using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using OKHOSTING.UI.Net4.WebForms.Controls;
using OKHOSTING.UI.Net4.WebForms.Controls.Layouts;
using System;
using System.Linq;

namespace OKHOSTING.UI.Net4.WebForms
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

		#region Virtual

		internal virtual void SetPage(Page page)
		{
			this.Page = page;
		}

		public virtual Color Parse(System.Drawing.Color color)
		{
			return new Color(color.A, color.R, color.G, color.B);
		}

		public virtual System.Drawing.Color Parse(Color color)
		{
			return System.Drawing.Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue);
		}

		public virtual string Parse(HorizontalAlignment value)
		{
			switch (value)
			{
				case HorizontalAlignment.Center:
					return "hotizontal-alignment-center";

				case HorizontalAlignment.Fill:
					return "hotizontal-alignment-fill";

				case HorizontalAlignment.Left:
					return "hotizontal-alignment-left";

				case HorizontalAlignment.Right:
					return "hotizontal-alignment-right";
			}

			throw new ArgumentOutOfRangeException("value");
		}

		public virtual string Parse(VerticalAlignment value)
		{
			switch (value)
			{
				case VerticalAlignment.Center:
					return "vertical-alignment-center";

				case VerticalAlignment.Fill:
					return "vertical-alignment-fill";

				case VerticalAlignment.Top:
					return "vertical-alignment-top";

				case VerticalAlignment.Bottom:
					return "vertical-alignment-bottom";
			}

			throw new ArgumentOutOfRangeException("value");
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