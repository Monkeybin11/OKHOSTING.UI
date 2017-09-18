using System;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI.Net4.WebForms
{
	public class Platform : UI.Platform
	{
		protected int ControlCounter = 0;

		public readonly List<UrlRewriteRule> UriMap = new List<UrlRewriteRule>();

		public override T Create<T>()
		{
			T control = base.Create<T>();

			//give a default name to all controls to allow events to be correclty triggered
			if (string.IsNullOrWhiteSpace(control.Name))
			{
				control.Name = $"ctr_{control.GetType().Name}_{ControlCounter++}";
			}

			ControlCounter++;

			return control;
		}

		public override void Finish()
		{
			base.Finish();
			System.Web.Security.FormsAuthentication.SignOut();
		}

		//virtual

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

		public UrlRewriteRule GetUrlRewriteRuleFor(Uri uri)
		{
			foreach(var rule in UriMap)
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

		protected override void StartController(Controller controller)
		{
			ControlCounter = 0;

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

		//static

		static Platform()
		{
			SessionIdProvider.Setup();
		}

		public static new Platform Current
		{
			get
			{
				var platform = (Platform) UI.Platform.Current;

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