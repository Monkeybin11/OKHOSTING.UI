using System;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI.Net4.WebForms
{
	public static class ControlExtensions
	{
		public static void AddCssClass(this System.Web.UI.WebControls.WebControl control, string className)
		{
			if (!control.CssClass.Contains(className))
			{
				control.CssClass = control.CssClass + " " + className;
			}
		}

		public static void RemoveCssClass(this System.Web.UI.WebControls.WebControl control, string className)
		{
			control.CssClass = control.CssClass.Replace(className, string.Empty).Trim();
		}

		public static void RemoveCssClassesStartingWith(this System.Web.UI.WebControls.WebControl control, string className)
		{
			var cssClasses = control.CssClass.Split(' ').ToList();

			for (int i = 0; i < cssClasses.Count; i++)
			{
				if (cssClasses[i].StartsWith(className))
				{
					cssClasses.RemoveAt(i);
					i--;
				}
			}

			control.CssClass = string.Join(" ", cssClasses);
		}

		public static Thickness GetMargin(this System.Web.UI.WebControls.WebControl control)
		{
			double left, top, right, bottom;
			Thickness thickness = new Thickness();

			if (double.TryParse(control.Style["margin-left"]?.Replace("px", null), out left)) thickness.Left = left;
			if (double.TryParse(control.Style["margin-top"]?.Replace("px", null), out top)) thickness.Top = top;
			if (double.TryParse(control.Style["margin-right"]?.Replace("px", null), out right)) thickness.Right = right;
			if (double.TryParse(control.Style["margin-bottom"]?.Replace("px", null), out bottom)) thickness.Bottom = bottom;

			return new Thickness(left, top, right, bottom);
		}

		public static void SetMargin(this System.Web.UI.WebControls.WebControl control, Thickness value)
		{
			control.Style["margin-left"] = string.Format("{0}px", value.Left);
			control.Style["margin-top"] = string.Format("{0}px", value.Top);
			control.Style["margin-right"] = string.Format("{0}px", value.Right);
			control.Style["margin-bottom"] = string.Format("{0}px", value.Bottom);
		}

		public static Thickness GetPadding(this System.Web.UI.WebControls.WebControl control)
		{
			double left, top, right, bottom;
			Thickness thickness = new Thickness();

			if (double.TryParse(control.Style["padding-left"]?.Replace("px", null), out left)) thickness.Left = left;
			if (double.TryParse(control.Style["padding-top"]?.Replace("px", null), out top)) thickness.Top = top;
			if (double.TryParse(control.Style["padding-right"]?.Replace("px", null), out right)) thickness.Right = right;
			if (double.TryParse(control.Style["padding-bottom"]?.Replace("px", null), out bottom)) thickness.Bottom = bottom;

			return new Thickness(left, top, right, bottom);
		}

		public static void SetPadding(this System.Web.UI.WebControls.WebControl control, Thickness value)
		{
			control.Style["padding-left"] = string.Format("{0}px", value.Left);
			control.Style["padding-top"] = string.Format("{0}px", value.Top);
			control.Style["padding-right"] = string.Format("{0}px", value.Right);
			control.Style["padding-bottom"] = string.Format("{0}px", value.Bottom);
		}

		public static Thickness GetBorderWidth(this System.Web.UI.WebControls.WebControl control)
		{
			double left, top, right, bottom;
			Thickness thickness = new Thickness();

			if (double.TryParse(control.Style["border-left-width"]?.Replace("px", null), out left)) thickness.Left = left;
			if (double.TryParse(control.Style["border-top-width"]?.Replace("px", null), out top)) thickness.Top = top;
			if (double.TryParse(control.Style["border-right-width"]?.Replace("px", null), out right)) thickness.Right = right;
			if (double.TryParse(control.Style["border-bottom-width"]?.Replace("px", null), out bottom)) thickness.Bottom = bottom;

			return new Thickness(left, top, right, bottom);
		}

		public static void SetBorderWidth(this System.Web.UI.WebControls.WebControl control, Thickness value)
		{
			control.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
			control.Style["border-left-width"] = string.Format("{0}px", value.Left);
			control.Style["border-top-width"] = string.Format("{0}px", value.Top);
			control.Style["border-right-width"] = string.Format("{0}px", value.Right);
			control.Style["border-bottom-width"] = string.Format("{0}px", value.Bottom);
		}
	}
}