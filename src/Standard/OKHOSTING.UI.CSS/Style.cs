using System.Linq;
using System.Collections.Generic;
using AngleSharp.Dom.Css;
using AngleSharp.Parser.Css;
using OKHOSTING.UI.Controls;
using System.Drawing;

namespace OKHOSTING.UI.CSS
{
	/// <summary>
	/// Reads a CSS file and generates a Style from them.
	/// <para xml:lang="es">
	/// Lee un archivo css y genera un estilo de ellos.
	/// </para>
	/// </summary>
	public class Style
	{
		/// <summary>
		/// Applies a CSS stylesheet to the current App
		/// <para xml:lang="es">
		/// Aplica una hoja de estilo css para la aplicacion actual.
		/// </para>
		/// </summary>
		/// <param name="styleSheet">A list of css rules to be applied to the current running App
		/// <para xml:lang="es">Una lista de reglas css que se aplicaran a la aplicacion actual en ejecucion.</para>
		/// </param>
		public static void ParseStyleRules(string styleSheet)
		{
			CssParser parser = new CssParser();
			ICssStyleSheet cssStylesSheet = parser.ParseStylesheet(styleSheet);

			//get only the rules that are actually styles
			foreach (ICssStyleRule rule in cssStylesSheet.Rules.Where(rule => rule.Type == CssRuleType.Style))
			{
				ParsedStyleRules.Add(rule);
			}
		}

		/// <summary>
		/// A cache of parsed styles for better performance
		/// <para xml:lang="es">
		/// Un cache de estilos analizados para una mejor rendimiento.
		/// </para>
		/// </summary>
		public static readonly List<ICssStyleRule> ParsedStyleRules = new List<ICssStyleRule>();

		/// <summary>
		/// Applies the corresponding styles to a recently created control
		/// <para xml:lang="es">
		/// Aplica los estilos correspondientes a un control creado recientemente.
		/// </para>
		/// </summary>
		public static void Apply(IControl e)
		{
			string selector = "." + e.GetType().Name;

			//select the correct styles using the selector, and apply
			foreach (ICssStyleDeclaration style in ParsedStyleRules.Where(s => s.SelectorText == selector))
			{
				Apply(style, e);
			}
		}

		/// <summary>
		/// Applies a CSS style to a IControl
		/// <para xml:lang="es">
		/// Aplica un estilo CSS a un Control.
		/// </para>
		/// </summary>
		public static void Apply(ICssStyleDeclaration style, IControl control)
		{
			AngleSharp.Css.Values.Color color;
			AngleSharp.Css.Values.Length lenght;
			bool parsed;

			//background and border colors

			color = AngleSharp.Css.Values.Color.FromHex(style.BackgroundColor);
			control.BackgroundColor = Color.FromArgb(color.A, color.R, color.G, color.B);

			color = AngleSharp.Css.Values.Color.FromHex(style.BorderColor);
			control.BorderColor = Color.FromArgb(color.A, color.R, color.G, color.B);

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
			parsed = AngleSharp.Css.Values.Length.TryParse(style.Left, out lenght);
			if (parsed && style.Position == "absolute" && lenght.ToPixel() == 0)
			{
				control.HorizontalAlignment = HorizontalAlignment.Left;
			}

			parsed = AngleSharp.Css.Values.Length.TryParse(style.Right, out lenght);
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

			if (AngleSharp.Css.Values.Length.TryParse(style.Height, out lenght)) control.Height = lenght.ToPixel();
			if (AngleSharp.Css.Values.Length.TryParse(style.Width, out lenght)) control.Width = lenght.ToPixel();

			//border

			Thickness borderWidth = new Thickness();
			AngleSharp.Css.Values.Length.TryParse(style.BorderTopWidth, out lenght);
			borderWidth.Top = lenght.ToPixel();
			AngleSharp.Css.Values.Length.TryParse(style.BorderRightWidth, out lenght);
			borderWidth.Right = lenght.ToPixel();
			AngleSharp.Css.Values.Length.TryParse(style.BorderBottomWidth, out lenght);
			borderWidth.Bottom = lenght.ToPixel();
			AngleSharp.Css.Values.Length.TryParse(style.BorderLeftWidth, out lenght);
			borderWidth.Left = lenght.ToPixel();
			control.BorderWidth = borderWidth;

			//margin

			Thickness margin = new Thickness();
			AngleSharp.Css.Values.Length.TryParse(style.MarginTop, out lenght);
			margin.Top = lenght.ToPixel();
			AngleSharp.Css.Values.Length.TryParse(style.MarginRight, out lenght);
			margin.Right = lenght.ToPixel();
			AngleSharp.Css.Values.Length.TryParse(style.MarginBottom, out lenght);
			margin.Bottom = lenght.ToPixel();
			AngleSharp.Css.Values.Length.TryParse(style.MarginLeft, out lenght);
			margin.Left = lenght.ToPixel();
			control.Margin = margin;

			//visibility

			control.Visible = style.Visibility != "none" && style.Visibility != "hidden";
		}

		/// <summary>
		/// Applies a CSS style ato a ITextControl including font style
		/// <para xml:lang="es">
		/// Aplica un estilo CSS a un control de texto incluyendo el estilo del texto.
		/// </para>
		/// </summary>
		public static void Apply(ICssStyleDeclaration style, ITextControl control)
		{
			//first parse as IControl
			Apply(style, (IControl) control);

			//now for ITextControl properties
			control.Bold = style.FontWeight == "bold";
			control.Italic = style.FontStyle == "italic";
			control.Underline = style.TextDecoration == "underline";

			AngleSharp.Css.Values.Color color = AngleSharp.Css.Values.Color.FromHex(style.Color);
			control.FontColor = Color.FromArgb(color.A, color.R, color.G, color.B);

			control.FontFamily = style.FontFamily;

			AngleSharp.Css.Values.Length lenght;

			if (AngleSharp.Css.Values.Length.TryParse(style.FontSize, out lenght))
			{
				control.FontSize = lenght.ToPixel();
			}

			switch (style.TextAlign)
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