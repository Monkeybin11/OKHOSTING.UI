using System;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI.Net4.WebForms
{
	public static class Platform
	{
		public static void Finish()
		{
			System.Web.Security.FormsAuthentication.SignOut();
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

		/// <summary>
		/// List of rules that define which controllers are attached to wich URI paths
		/// </summary>
		public static readonly List<UrlRewriteRule> UriMap = new List<UrlRewriteRule>();

		/// <summary>
		/// Enables friendly urls for the app
		/// </summary>
		public static void EnableUrlRewrite(App app)
		{
			app.ControllerStarted += App_ControllerStarted;
		}

		public static UrlRewriteRule GetUrlRewriteRuleFor(Uri uri)
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

		public static UrlRewriteRule GetUrlRewriteRuleFor(Type controllerType)
		{
			return UriMap.Where(r => r.ControllerType.Equals(controllerType) || r.ControllerType.IsSubclassOf(controllerType)).FirstOrDefault();
		}

		public static Page CurrentPage
		{
			get
			{
				return (Page) System.Web.HttpContext.Current.Session[$"{nameof(Platform)}.{nameof(CurrentPage)}"];
			}
			internal set
			{
				System.Web.HttpContext.Current.Session[$"{nameof(Platform)}.{nameof(CurrentPage)}"] = value;
			}
		}

		private static void App_ControllerStarted(object sender, Controller controller)
		{
			var rule = GetUrlRewriteRuleFor(controller.GetType());

			if (rule == null)
			{
				return;
			}

			//are we on the correct url?
			var uri = rule.GetUri(controller);

			if (uri != new Uri(System.Web.HttpContext.Current.Request.RawUrl, UriKind.Relative))
			{
				System.Web.HttpContext.Current.Response.Redirect(uri.ToString(), false);
			}
		}
	}
}