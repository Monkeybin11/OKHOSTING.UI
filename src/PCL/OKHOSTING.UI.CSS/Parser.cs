using System;
using System.Reflection;
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
	public class Parser
	{
		/// <summary>
		/// Applies a CSS stylesheet to a list of controls
		/// </summary>
		/// <param name="styleSheet">A list of css rules</param>
		/// <param name="controls">List of controls to wich the corresponding rules will be applied</param>
		public static void Apply(string styleSheet, IEnumerable<IControl> controls)
		{
			CssParser parser = new CssParser();
			ICssStyleSheet cssStylesSheet = parser.ParseStylesheet(styleSheet);

			var rules = cssStylesSheet.Rules.Where(rule => rule.Type == CssRuleType.Style);

			//analize rule by rule
			foreach (ICssStyleRule r in rules)
			{
				var style = Parser.ParseTextControl(r.Style);
				Type controlType = null;

				switch (r.SelectorText)
				{
					case "input[type=text]":
						controlType = typeof(ITextBox);
						break;

					case "input[type=checkbox]":
						controlType = typeof(ICheckBox);
						break;

					case "input[type=password]":
						controlType = typeof(IPasswordTextBox);
						break;

					case "textarea":
						controlType = typeof(ITextArea);
						break;

					case "select":
						controlType = typeof(IListPicker);
						break;

					case "table":
						controlType = typeof(IGrid);
						break;

					case "span":
						controlType = typeof(ILabel);
						break;

					case "a":
						controlType = typeof(IHyperLink);
						break;

					case "img":
						controlType = typeof(IImage);
						break;

					default:
						continue;

				}

				//we will apply this style to the controls that are of this type
				foreach (IControl control in controls.Where(c => c.GetType().GetTypeInfo().ImplementedInterfaces.Contains(controlType)))
				{
					style.ApplyTo(control);
				}
			}

		}

		public static Controls.Styles.ControlStyle Parse(ICssStyleDeclaration cssStyle)
		{
			return Parse(cssStyle, new Controls.Styles.ControlStyle());
		}

		public static Controls.Styles.ControlStyle Parse(ICssStyleDeclaration cssStyle, Controls.Styles.ControlStyle style)
		{

			AngleSharp.Css.Values.Color color;
			Length lenght;
			bool parsed;

			//background and border colors

			color = AngleSharp.Css.Values.Color.FromHex(cssStyle.BackgroundColor);
			style.BackgroundColor = new Color(color.A, color.R, color.G, color.B);

			color = AngleSharp.Css.Values.Color.FromHex(cssStyle.BorderColor);
			style.BorderColor = new Color(color.A, color.R, color.G, color.B);

			//horizontal alignment http://www.w3schools.com/css/css_align.asp

			//horizontal alignment using float
			switch (cssStyle.Float)
			{
				case "left":
					style.HorizontalAlignment = HorizontalAlignment.Left;
					break;

				case "right":
					style.HorizontalAlignment = HorizontalAlignment.Right;
					break;
			}

			//horizontal alignment using position
			parsed = Length.TryParse(cssStyle.Left, out lenght);
			if (parsed && cssStyle.Position == "absolute" && lenght.ToPixel() == 0)
			{
				style.HorizontalAlignment = HorizontalAlignment.Left;
			}

			parsed = Length.TryParse(cssStyle.Right, out lenght);
			if (parsed && cssStyle.Position == "absolute" && lenght.ToPixel() == 0)
			{
				style.HorizontalAlignment = HorizontalAlignment.Right;
			}

			//horizontal alignment using margin
			if (cssStyle.Margin == "auto" || (cssStyle.MarginLeft == "auto" && cssStyle.MarginRight == "auto"))
			{
				style.HorizontalAlignment = HorizontalAlignment.Center;
			}

			//horizontal alignment using text align, online for inline elements
			if (cssStyle.Display == "inline")
			{
				switch (cssStyle.TextAlign)
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

			switch (cssStyle.VerticalAlign)
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

				case "left":
					style.VerticalAlignment = VerticalAlignment.Left;
					break;

			}


			//height and width

            if (Length.TryParse(cssStyle.Height, out lenght)) style.Height = lenght.ToPixel();
			if (Length.TryParse(cssStyle.Width, out lenght)) style.Width = lenght.ToPixel();

			//border

			Thickness borderWidth = new Thickness();
			Length.TryParse(cssStyle.BorderTopWidth, out lenght);
			borderWidth.Top = lenght.ToPixel();
			Length.TryParse(cssStyle.BorderRightWidth, out lenght);
			borderWidth.Right = lenght.ToPixel();
			Length.TryParse(cssStyle.BorderBottomWidth, out lenght);
			borderWidth.Bottom = lenght.ToPixel();
			Length.TryParse(cssStyle.BorderLeftWidth, out lenght);
			borderWidth.Left = lenght.ToPixel();
			style.BorderWidth = borderWidth;

			//margin

			Thickness margin = new Thickness();
			Length.TryParse(cssStyle.MarginTop, out lenght);
			margin.Top = lenght.ToPixel();
			Length.TryParse(cssStyle.MarginRight, out lenght);
			margin.Right = lenght.ToPixel();
			Length.TryParse(cssStyle.MarginBottom, out lenght);
			margin.Bottom = lenght.ToPixel();
			Length.TryParse(cssStyle.MarginLeft, out lenght);
			margin.Left = lenght.ToPixel();
			style.Margin = margin;

			//visibility

			style.Visible = cssStyle.Visibility != "none" && cssStyle.Visibility != "hidden";

			return style;
        }

		public static Controls.Styles.TextControlStyle ParseTextControl(ICssStyleDeclaration cssStyle)
		{ 
			var style = new Controls.Styles.TextControlStyle();

			//first parse as IControl
			Parse(cssStyle, style);

			//now for ITextControl properties

			style.Bold = cssStyle.FontWeight == "bold";
			style.Italic = cssStyle.FontStyle == "italic";
			style.Underline = cssStyle.TextDecoration == "underline";

			AngleSharp.Css.Values.Color color = AngleSharp.Css.Values.Color.FromHex(cssStyle.Color);
			style.FontColor = new Color(color.A, color.R, color.G, color.B);

			style.FontFamily = cssStyle.FontFamily;

			Length lenght;
			if (Length.TryParse(cssStyle.FontSize, out lenght))
			{
				style.FontSize = lenght.ToPixel();
			}

			switch (cssStyle.TextAlign)
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