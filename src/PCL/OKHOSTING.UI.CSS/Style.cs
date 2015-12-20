using System;
using System.Linq;
using System.Collections.Generic;
using AngleSharp.Css.Values;
using AngleSharp.Dom.Css;
using AngleSharp.Parser.Css;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.CSS
{
	/// <summary>
	/// Reads a CSS file and generates a Style from them
	/// </summary>
	public class Style
	{
		/// <summary>
		/// Applies a CSS stylesheet to the current App
		/// </summary>
		/// <param name="styleSheet">A list of css rules to be applied to the current running App</param>
		public static IEnumerable<ICssStyleRule> ParseStyleRules(string styleSheet)
		{
			CssParser parser = new CssParser();
			ICssStyleSheet cssStylesSheet = parser.ParseStylesheet(styleSheet);

			//get only the rules that are actually styles
			foreach (ICssStyleRule rule in cssStylesSheet.Rules.Where(rule => rule.Type == CssRuleType.Style))
			{
				yield return rule;
			}
		}

		//protected

		/// <summary>
		/// A cache of parsed styles for better performance
		/// </summary>
		public static readonly List<ICssStyleRule> ParsedStyleRules = new List<ICssStyleRule>();

		/// <summary>
		/// Applies the corresponding styles to a recently created control
		/// </summary>
		public static void App_ControlCreated(object sender, IControl e)
		{
			string selector = null;

			if (e is IButton)
			{
				selector = "input[type=submit]";
			}
			else if (e is ICheckBox)
			{
				selector = "input[type=checkbox]";
			}
			else if (e is IHyperLink)
			{
				selector = "a";
			}
			else if (e is IImage)
			{
				selector = "img";
			}
			else if (e is ILabel)
			{
				selector = "span";
			}
			else if (e is IListPicker)
			{
				selector = "select";
			}
			else if (e is IPasswordTextBox)
			{
				selector = "input[type=password]";
			}
			else if (e is ITextArea)
			{
				selector = "textarea";
			}
			else if (e is ITextBox)
			{
				selector = "input[type=text]";
			}
			else if (e is IGrid || e is IStack)
			{
				selector = "table";
			}

			//select the correct styles using the selector, and apply
			foreach (ICssStyleDeclaration style in ParsedStyleRules.Where(s => s.SelectorText == selector))
			{
				Apply(style, e);
			}
		}



		/// <summary>
		/// Applies a CSS style to a IControl
		/// </summary>
		public static void Apply(ICssStyleDeclaration style, IControl control)
		{

			AngleSharp.Css.Values.Color color;
			Length lenght;
			bool parsed;

			//background and border colors

			color = AngleSharp.Css.Values.Color.FromHex(style.BackgroundColor);
			control.BackgroundColor = new Color(color.A, color.R, color.G, color.B);

			color = AngleSharp.Css.Values.Color.FromHex(style.BorderColor);
			control.BorderColor = new Color(color.A, color.R, color.G, color.B);

			//horizontal alignment http://www.w3schools.com/css/css_align.asp

			//horizontal alignment using float
			switch (style.Float)
			{
				case "left":
					control.HorizontalAlignment = HorizontalAlignment.Left;
					break;

				case "right":
					control.HorizontalAlignment = HorizontalAlignment.Right;
					break;
			}

			//horizontal alignment using position
			parsed = Length.TryParse(style.Left, out lenght);
			if (parsed && style.Position == "absolute" && lenght.ToPixel() == 0)
			{
				control.HorizontalAlignment = HorizontalAlignment.Left;
			}

			parsed = Length.TryParse(style.Right, out lenght);
			if (parsed && style.Position == "absolute" && lenght.ToPixel() == 0)
			{
				control.HorizontalAlignment = HorizontalAlignment.Right;
			}

			//horizontal alignment using margin
			if (style.Margin == "auto" || (style.MarginLeft == "auto" && style.MarginRight == "auto"))
			{
				control.HorizontalAlignment = HorizontalAlignment.Center;
			}

			//horizontal alignment using text align, online for inline elements
			if (style.Display == "inline")
			{
				switch (style.TextAlign)
				{
					case "left":
						control.HorizontalAlignment = HorizontalAlignment.Left;
						break;

					case "center":
						control.HorizontalAlignment = HorizontalAlignment.Center;
						break;

					case "right":
						control.HorizontalAlignment = HorizontalAlignment.Right;
						break;

					case "justify":
						control.HorizontalAlignment = HorizontalAlignment.Fill;
						break;
				}
			}

			//vertical alignment

			switch (style.VerticalAlign)
			{
				case "top":
					control.VerticalAlignment = VerticalAlignment.Top;
					break;

				case "middle":
					control.VerticalAlignment = VerticalAlignment.Center;
					break;

				case "bottom":
					control.VerticalAlignment = VerticalAlignment.Bottom;
					break;
			}


			//height and width

            if (Length.TryParse(style.Height, out lenght)) control.Height = lenght.ToPixel();
			if (Length.TryParse(style.Width, out lenght)) control.Width = lenght.ToPixel();

			//border

			Thickness borderWidth = new Thickness();
			Length.TryParse(style.BorderTopWidth, out lenght);
			borderWidth.Top = lenght.ToPixel();
			Length.TryParse(style.BorderRightWidth, out lenght);
			borderWidth.Right = lenght.ToPixel();
			Length.TryParse(style.BorderBottomWidth, out lenght);
			borderWidth.Bottom = lenght.ToPixel();
			Length.TryParse(style.BorderLeftWidth, out lenght);
			borderWidth.Left = lenght.ToPixel();
			control.BorderWidth = borderWidth;

			//margin

			Thickness margin = new Thickness();
			Length.TryParse(style.MarginTop, out lenght);
			margin.Top = lenght.ToPixel();
			Length.TryParse(style.MarginRight, out lenght);
			margin.Right = lenght.ToPixel();
			Length.TryParse(style.MarginBottom, out lenght);
			margin.Bottom = lenght.ToPixel();
			Length.TryParse(style.MarginLeft, out lenght);
			margin.Left = lenght.ToPixel();
			control.Margin = margin;

			//visibility

			control.Visible = style.Visibility != "none" && style.Visibility != "hidden";
        }

		/// <summary>
		/// Applies a CSS style ato a ITextControl including font style
		/// </summary>
		public static void Apply(ICssStyleDeclaration styleDeclaration, ITextControl control)
		{
			//first parse as IControl
			Apply(styleDeclaration, (IControl) control);

			//now for ITextControl properties

			control.Bold = styleDeclaration.FontWeight == "bold";
			control.Italic = styleDeclaration.FontStyle == "italic";
			control.Underline = styleDeclaration.TextDecoration == "underline";

			AngleSharp.Css.Values.Color color = AngleSharp.Css.Values.Color.FromHex(styleDeclaration.Color);
			control.FontColor = new Color(color.A, color.R, color.G, color.B);

			control.FontFamily = styleDeclaration.FontFamily;

			Length lenght;
			if (Length.TryParse(styleDeclaration.FontSize, out lenght))
			{
				control.FontSize = lenght.ToPixel();
			}

			switch (styleDeclaration.TextAlign)
			{
				case "left":
					control.TextHorizontalAlignment = HorizontalAlignment.Left;
					break;

				case "center":
					control.TextHorizontalAlignment = HorizontalAlignment.Center;
					break;

				case "right":
					control.TextHorizontalAlignment = HorizontalAlignment.Right;
					break;

				case "justify":
					control.TextHorizontalAlignment = HorizontalAlignment.Fill;
					break;
			}

			//just grab the sabe vertical aligned parsed form the other mnethod
			control.TextVerticalAlignment = control.VerticalAlignment;
		}
	}
}