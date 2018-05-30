using System;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI.Net4.WebForms
{
	public class Platform : UI.Platform
	{
		//protected int ControlCounter = 0;

		public readonly List<UrlRewriteRule> UriMap = new List<UrlRewriteRule>();

		protected override void StartController(Controller controller)
		{
			//ControlCounter = 0;

			base.StartController(controller);

			var rule = GetUrlRewriteRuleFor(controller.GetType());

			if (rule == null)
			{
				return;
			}

			//we are on the corect url
			var uri = rule.GetUri(controller);

			if (uri != new Uri(System.Web.HttpContext.Current.Request.RawUrl, UriKind.Relative))
			{
				System.Web.HttpContext.Current.Response.Redirect(uri.ToString(), false);
			}
		}

		public override void Finish()
		{
			base.Finish();
			System.Web.Security.FormsAuthentication.SignOut();
		}

		public UrlRewriteRule GetUrlRewriteRuleFor(Uri uri)
		{
			foreach (var rule in UriMap)
			{
				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(rule.UrlRegexPattern);

				if (uri.IsAbsoluteUri)
				{
					uri = new Uri(uri.PathAndQuery, UriKind.Relative);
				}

				if (regex.IsMatch(uri.ToString()))
				{
					return rule;
				}
			}

			return null;
		}

		public UrlRewriteRule GetUrlRewriteRuleFor(Type controllerType)
		{
			return UriMap.Where(r => r.ControllerType.Equals(controllerType) || r.ControllerType.IsSubclassOf(controllerType)).FirstOrDefault();
		}

		//static

		protected static readonly Random Random = new Random();

		public static new T Create<T>() where T : class, UI.Controls.IControl
		{
			T control = UI.Platform.Create<T>();

			//give a default name to all controls to allow events to be correclty triggered
			if (string.IsNullOrWhiteSpace(control.Name))
			{
				control.Name = $"ctr_{control.GetType().Name}_{Random.Next()}";
				//control.Name = $"ctr_{control.GetType().Name}_{ControlCounter++}";
			}

			//ControlCounter++;

			return control;
		}

		public static Color Parse(System.Drawing.Color color)
		{
			return new Color(color.A, color.R, color.G, color.B);
		}

		public static System.Drawing.Color Parse(Color color)
		{
			return System.Drawing.Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue);
		}

		public static string Parse(HorizontalAlignment value)
		{
			switch (value)
			{
				case HorizontalAlignment.Center:
					return "horizontal-alignment-center";

				case HorizontalAlignment.Fill:
					return "horizontal-alignment-fill";

				case HorizontalAlignment.Left:
					return "horizontal-alignment-left";

				case HorizontalAlignment.Right:
					return "horizontal-alignment-right";
			}

			throw new ArgumentOutOfRangeException("value");
		}

		public static string Parse(VerticalAlignment value)
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

		public static void AddCssClass(System.Web.UI.WebControls.WebControl control, string className)
		{
			if (!control.CssClass.Contains(className))
			{
				control.CssClass = control.CssClass + " " + className;
			}
		}

		public static void RemoveCssClass(System.Web.UI.WebControls.WebControl control, string className)
		{
			control.CssClass = control.CssClass.Replace(className, string.Empty).Trim();
		}

		public static void RemoveCssClassesStartingWith(System.Web.UI.WebControls.WebControl control, string className)
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

		/// <summary>
		/// Returns all the contained controls, recursively
		/// </summary>
		public static IEnumerable<System.Web.UI.Control> GetAllControls(System.Web.UI.Control control)
		{
			foreach (System.Web.UI.Control ctr in control.Controls)
			{
				yield return ctr;

				foreach(System.Web.UI.Control ctr2 in GetAllControls(ctr))
				{
					yield return ctr2;
				}
			}
		}
	}
}