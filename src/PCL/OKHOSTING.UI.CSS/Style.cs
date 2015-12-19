using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using AngleSharp.Css.Values;
using AngleSharp.Dom.Css;
using AngleSharp.Parser.Css;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using OKHOSTING.UI.Controls.Styles;

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
		public static void Apply(string styleSheet)
		{
			CssParser parser = new CssParser();
			ICssStyleSheet cssStylesSheet = parser.ParseStylesheet(styleSheet);

			//get only the rules that are actually styles
			var rules = cssStylesSheet.Rules.Where(rule => rule.Type == CssRuleType.Style);

			//parse each rule, name it with the selector and add it to the list
			foreach (ICssStyleRule r in rules)
			{
				TextControlStyle style = ParseTextControl(r.Style);
				style.Name = r.SelectorText;

				ParsedStyles.Add(style);
			}

			//subscribe
			App.Current.ControlCreated += App_ControlCreated;
		}

		//protected

		/// <summary>
		/// A cache of parsed styles for better performance
		/// </summary>
		protected static readonly List<ControlStyle> ParsedStyles = new List<ControlStyle>();

		/// <summary>
		/// Applies the corresponding styles to a recently created control
		/// </summary>
		protected static void App_ControlCreated(object sender, IControl e)
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
			foreach (TextControlStyle style in ParsedStyles.Where(s => s.Name == selector))
			{
				style.ApplyTo(e);
			}
		}

		protected static Controls.Styles.ControlStyle Parse(ICssStyleDeclaration styleDeclaration)
		{
			return Parse(styleDeclaration, new Controls.Styles.ControlStyle());
		}

		protected static Controls.Styles.ControlStyle Parse(ICssStyleDeclaration styleDeclaration, Controls.Styles.ControlStyle style)
		{

			AngleSharp.Css.Values.Color color;
			Length lenght;
			bool parsed;

			//background and border colors

			color = AngleSharp.Css.Values.Color.FromHex(styleDeclaration.BackgroundColor);
			style.BackgroundColor = new Color(color.A, color.R, color.G, color.B);

			color = AngleSharp.Css.Values.Color.FromHex(styleDeclaration.BorderColor);
			style.BorderColor = new Color(color.A, color.R, color.G, color.B);

			//horizontal alignment http://www.w3schools.com/css/css_align.asp

			//horizontal alignment using float
			switch (styleDeclaration.Float)
			{
				case "left":
					style.HorizontalAlignment = HorizontalAlignment.Left;
					break;

				case "right":
					style.HorizontalAlignment = HorizontalAlignment.Right;
					break;
			}

			//horizontal alignment using position
			parsed = Length.TryParse(styleDeclaration.Left, out lenght);
			if (parsed && styleDeclaration.Position == "absolute" && lenght.ToPixel() == 0)
			{
				style.HorizontalAlignment = HorizontalAlignment.Left;
			}

			parsed = Length.TryParse(styleDeclaration.Right, out lenght);
			if (parsed && styleDeclaration.Position == "absolute" && lenght.ToPixel() == 0)
			{
				style.HorizontalAlignment = HorizontalAlignment.Right;
			}

			//horizontal alignment using margin
			if (styleDeclaration.Margin == "auto" || (styleDeclaration.MarginLeft == "auto" && styleDeclaration.MarginRight == "auto"))
			{
				style.HorizontalAlignment = HorizontalAlignment.Center;
			}

			//horizontal alignment using text align, online for inline elements
			if (styleDeclaration.Display == "inline")
			{
				switch (styleDeclaration.TextAlign)
				{
					case "left":
						style.HorizontalAlignment = HorizontalAlignment.Left;
						break;

					case "center":
						style.HorizontalAlignment = HorizontalAlignment.Center;
						break;

					case "right":
						style.HorizontalAlignment = HorizontalAlignment.Right;
						break;

					case "justify":
						style.HorizontalAlignment = HorizontalAlignment.Fill;
						break;
				}
			}

			//vertical alignment

			switch (styleDeclaration.VerticalAlign)
			{
				case "top":
					style.VerticalAlignment = VerticalAlignment.Top;
					break;

				case "middle":
					style.VerticalAlignment = VerticalAlignment.Center;
					break;

				case "bottom":
					style.VerticalAlignment = VerticalAlignment.Bottom;
					break;
			}


			//height and width

            if (Length.TryParse(styleDeclaration.Height, out lenght)) style.Height = lenght.ToPixel();
			if (Length.TryParse(styleDeclaration.Width, out lenght)) style.Width = lenght.ToPixel();

			//border

			Thickness borderWidth = new Thickness();
			Length.TryParse(styleDeclaration.BorderTopWidth, out lenght);
			borderWidth.Top = lenght.ToPixel();
			Length.TryParse(styleDeclaration.BorderRightWidth, out lenght);
			borderWidth.Right = lenght.ToPixel();
			Length.TryParse(styleDeclaration.BorderBottomWidth, out lenght);
			borderWidth.Bottom = lenght.ToPixel();
			Length.TryParse(styleDeclaration.BorderLeftWidth, out lenght);
			borderWidth.Left = lenght.ToPixel();
			style.BorderWidth = borderWidth;

			//margin

			Thickness margin = new Thickness();
			Length.TryParse(styleDeclaration.MarginTop, out lenght);
			margin.Top = lenght.ToPixel();
			Length.TryParse(styleDeclaration.MarginRight, out lenght);
			margin.Right = lenght.ToPixel();
			Length.TryParse(styleDeclaration.MarginBottom, out lenght);
			margin.Bottom = lenght.ToPixel();
			Length.TryParse(styleDeclaration.MarginLeft, out lenght);
			margin.Left = lenght.ToPixel();
			style.Margin = margin;

			//visibility

			style.Visible = styleDeclaration.Visibility != "none" && styleDeclaration.Visibility != "hidden";

			return style;
        }

		protected static Controls.Styles.TextControlStyle ParseTextControl(ICssStyleDeclaration styleDeclaration)
		{ 
			var style = new Controls.Styles.TextControlStyle();

			//first parse as IControl
			Parse(styleDeclaration, style);

			//now for ITextControl properties

			style.Bold = styleDeclaration.FontWeight == "bold";
			style.Italic = styleDeclaration.FontStyle == "italic";
			style.Underline = styleDeclaration.TextDecoration == "underline";

			AngleSharp.Css.Values.Color color = AngleSharp.Css.Values.Color.FromHex(styleDeclaration.Color);
			style.FontColor = new Color(color.A, color.R, color.G, color.B);

			style.FontFamily = styleDeclaration.FontFamily;

			Length lenght;
			if (Length.TryParse(styleDeclaration.FontSize, out lenght))
			{
				style.FontSize = lenght.ToPixel();
			}

			switch (styleDeclaration.TextAlign)
			{
				case "left":
					style.TextHorizontalAlignment = HorizontalAlignment.Left;
					break;

				case "center":
					style.TextHorizontalAlignment = HorizontalAlignment.Center;
					break;

				case "right":
					style.TextHorizontalAlignment = HorizontalAlignment.Right;
					break;

				case "justify":
					style.TextHorizontalAlignment = HorizontalAlignment.Fill;
					break;
			}

			//just grab the sabe vertical aligned parsed form the other mnethod
			style.TextVerticalAlignment = style.VerticalAlignment;

			return style;
		}
	}
}