using AngleSharp.Dom.Css;
using AngleSharp.Parser.Css;
using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

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
		#region Public

		/// <summary>
		/// Parses CSS stylesheet and stores the rules internally
		/// <para xml:lang="es">
		/// Parsea una hoja de estilo CSS y guarda las reglas localmente
		/// </para>
		/// </summary>
		/// <param name="styleSheet">A CSS style sheet
		/// <para xml:lang="es">
		/// Una hoja de estilos CSS
		/// </para>
		/// </param>
		public void Parse(string styleSheet)
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
		/// Applies the corresponding styles to a recently created control
		/// <para xml:lang="es">
		/// Aplica los estilos correspondientes a un control creado recientemente.
		/// </para>
		/// </summary>
		public void Apply(IPage page)
		{
			var allControls = App.GetAllChildren(page.Content);

			foreach (var rule in ParsedStyleRules)
			{
				var selectedControls = SelectBy(allControls, rule.SelectorText);

				foreach (var control in selectedControls)
				{
					Apply(rule.Style, control);

					if (control is ITextControl)
					{
						Apply(rule.Style, (ITextControl) control);
					}
				}
			}
		}

		#endregion

		#region Protected

		protected string[] SplitBySpace(string singleSelectorText)
		{
			return singleSelectorText.Split(' ').Select(s => s.ToLower().Trim()).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
		}

		protected string[] SplitByCommas(string selectorText)
		{
			return selectorText.Split(',').Select(s => s.ToLower().Trim()).ToArray();
		}

		/// <summary>
		/// A cache of parsed styles for better performance
		/// <para xml:lang="es">
		/// Un cache de estilos analizados para una mejor rendimiento.
		/// </para>
		/// </summary>
		protected readonly List<ICssStyleRule> ParsedStyleRules = new List<ICssStyleRule>();

		/// <summary>
		/// Selects all controls that match the specified CSS selector
		/// </summary>
		/// <param name="controls">List of controls to filter</param>
		/// <param name="selector">CSS full selector, might include commas, pe: #mycontrolname, .myclass</param>
		/// <returns>List of controls that have the specified Id (Name)</returns>
		protected IEnumerable<IControl> SelectBy(IEnumerable<IControl> controls, string selector)
		{
			var allSelectors = SplitByCommas(selector);

			foreach (var s in allSelectors)
			{
				IEnumerable<IControl> selected = controls;
				var subSelectors = SplitBySpace(s);

				for (int i = 0; i < subSelectors.Length; i++)
				{
					var subSelector = subSelectors[i];

					//select all child when this is a "container" CSS selector like "p a, div img"
					if (i > 0)
					{
						selected = App.GetAllChildren(selected);
					}

					if (selector == "*")
					{
						//do not filter
					}
					else if (selector.StartsWith("#"))
					{
						selected = SelectById(selected, selector);
					}
					else if (selector.Contains("."))
					{
						selected = SelectByClass(selected, selector);
					}
					else if (selector.Contains("["))
					{
						selected = SelectByAttribute(selected, selector);
					}
					else if (selector[0].Category() == CharExtensions.CharCategory.Letter)
					{
						selected = SelectByElementType(selected, selector);
					}

					else throw new ArgumentOutOfRangeException(nameof(selector), "Argument is not a supported CSS selector");
				}

				foreach (var control in selected)
				{
					yield return control;
				}
			}
		}

		/// <summary>
		/// Selects all controls that have the specified CSS Id
		/// </summary>
		/// <param name="controls">List of controls to filter</param>
		/// <param name="selector">CSS id selector, pe: #mycontrolname</param>
		/// <returns>List of controls that have the specified Id (Name)</returns>
		protected IEnumerable<IControl> SelectById(IEnumerable<IControl> controls, string selector)
		{
			string id = selector.Substring(1);
			return controls.Where(c => c.Name == id);
		}

		/// <summary>
		/// Selects all controls that have the specified CSS class
		/// </summary>
		/// <param name="controls">List of controls to filter</param>
		/// <param name="selector">CSS class selector, pe: .myclass</param>
		/// <returns>List of controls that have the specified css class</returns>
		protected IEnumerable<IControl> SelectByClass(IEnumerable<IControl> controls, string selector)
		{
			//support .class1.class2 selector that means to select all items that have BOTH classes declared
			if (selector.IndexOf('.') != selector.LastIndexOf('.'))
			{
				var classes = selector.Split('.');
				//return controls.Where(c => c.CssClass != null && SplitBySpace(c.CssClass).ContainsAll(classes));
				return null;
			}

			string element = selector.Substring(0, selector.IndexOf('.'));
			string className = selector.Substring(selector.IndexOf('.') + 1);

			if (!string.IsNullOrWhiteSpace(element))
			{
				return SelectByElementType(controls, element).Where(c =>  c.CssClass != null && SplitBySpace(c.CssClass).Contains(className));
			}
			else
			{
				return controls.Where(c => c.CssClass != null && SplitBySpace(c.CssClass).Contains(className));
			}
		}

		/// <summary>
		/// Selects all controls that have the specified element type
		/// </summary>
		/// <param name="controls">List of controls to filter</param>
		/// <param name="selector">CSS element selector, pe: label, button, a, textbox</param>
		/// <returns>List of controls that have the specified css class</returns>
		protected IEnumerable<IControl> SelectByElementType(IEnumerable<IControl> controls, string selector)
		{
			return controls.Where(c => c.GetType().Name.Equals(selector, StringComparison.OrdinalIgnoreCase));
		}

		/// <summary>
		/// Selects all controls that matches the specified attribute selector
		/// </summary>
		/// <param name="controls">List of controls to filter</param>
		/// <param name="selector">CSS attribute selector, pe: [href], img[src='image.png'], a[href='okhosting']</param>
		/// <returns>List of controls that match the specified css attribute selector</returns>
		protected IEnumerable<IControl> SelectByAttribute(IEnumerable<IControl> controls, string selector)
		{
			string op = null;
			string element = selector.Substring(0, selector.IndexOf('['));

			if (selector.Contains("~="))
			{
				op = "~=";
			}
			else if (selector.Contains("|="))
			{
				op = "|=";
			}
			else if (selector.Contains("^="))
			{
				op = "^=";
			}
			else if (selector.Contains("$="))
			{
				op = "$=";
			}
			else if (selector.Contains("*="))
			{
				op = "*=";
			}
			else if (selector.Contains("="))
			{
				op = "=";
			}

			var opIndex = selector.IndexOf(op);
			string attName = selector.Substring(0, opIndex).TrimStart('[');
			string attValue = selector.Substring(opIndex + op.Length).TrimEnd(']');
			var elementControls = controls;

			if (!string.IsNullOrWhiteSpace(element))
			{
				elementControls = SelectByElementType(elementControls, element);
			}

			foreach (var c in elementControls)
			{
				var type = c.GetType();
				var member = type.GetMember(attName).Where(m => m is PropertyInfo || m is FieldInfo).FirstOrDefault();

				if (member == null)
				{
					continue;
				}

				var controlValue = Data.MemberExpression.GetValue(member, c);
				var convertedAttValue = Data.Convert.ChangeType(attValue, Data.MemberExpression.GetReturnType(member));

				switch (op)
				{
					//no operator means declaring the member is enough
					case null:
						yield return c;
						break;

					case "=":
						if (controlValue == convertedAttValue)
						{
							yield return c;
						}

						break;

					case "~=":
					case "*=":
						if (controlValue.ToString().Contains(convertedAttValue.ToString()))
						{
							yield return c;
						}

						break;

					case "|=":
						if (controlValue == convertedAttValue || controlValue.ToString() == convertedAttValue.ToString() + "-")
						{
							yield return c;
						}

						break;

					case "^=":
						if (controlValue.ToString().StartsWith(convertedAttValue.ToString()))
						{
							yield return c;
						}

						break;

					case "$=":
						if (controlValue.ToString().EndsWith(convertedAttValue.ToString()))
						{
							yield return c;
						}

						break;
				}
			}
		}
		
		#endregion

		#region Static

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
			if (!string.IsNullOrWhiteSpace(style.BackgroundColor))
			{
				color = AngleSharp.Css.Values.Color.FromHex(style.BackgroundColor);
				control.BackgroundColor = Color.FromArgb(color.A, color.R, color.G, color.B);
			}

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

			//padding
			Thickness padding = new Thickness();
			AngleSharp.Css.Values.Length.TryParse(style.MarginTop, out lenght);
			padding.Top = lenght.ToPixel();
			AngleSharp.Css.Values.Length.TryParse(style.MarginRight, out lenght);
			padding.Right = lenght.ToPixel();
			AngleSharp.Css.Values.Length.TryParse(style.MarginBottom, out lenght);
			padding.Bottom = lenght.ToPixel();
			AngleSharp.Css.Values.Length.TryParse(style.MarginLeft, out lenght);
			padding.Left = lenght.ToPixel();
			control.Padding = padding;

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

		static Style()
		{
			ElementTypeEquivalents = new Dictionary<string, Type>();

			ElementTypeEquivalents.Add("a", typeof(IHyperLink));
			ElementTypeEquivalents.Add("table", typeof(IGrid));
			ElementTypeEquivalents.Add("input[type=button]", typeof(IButton));
			ElementTypeEquivalents.Add("input[type=submit]", typeof(IButton));
			ElementTypeEquivalents.Add("input[type=check]", typeof(ICheckBox));
			ElementTypeEquivalents.Add("input[type=text]", typeof(ITextBox));
			ElementTypeEquivalents.Add("input[type=password]", typeof(IPasswordTextBox));
			ElementTypeEquivalents.Add("input[type=time]", typeof(ITimeOfDayPicker));
			ElementTypeEquivalents.Add("input[type=date]", typeof(IDatePicker));
			ElementTypeEquivalents.Add("input[type=datetime-local ]", typeof(IDatePicker));
			ElementTypeEquivalents.Add("input[type=email]", typeof(ITextBox));
			ElementTypeEquivalents.Add("input[type=month]", typeof(ITextBox));
			ElementTypeEquivalents.Add("input[type=number]", typeof(ITextBox));
			ElementTypeEquivalents.Add("input[type=range]", typeof(ITextBox));
			ElementTypeEquivalents.Add("input[type=search]", typeof(ITextBox));
			ElementTypeEquivalents.Add("input[type=tel]", typeof(ITextBox));
			ElementTypeEquivalents.Add("input[type=url]", typeof(ITextBox));
			ElementTypeEquivalents.Add("input[type=week]", typeof(ITextBox));
			ElementTypeEquivalents.Add("label", typeof(ILabel));
			ElementTypeEquivalents.Add("p", typeof(ILabel));
			ElementTypeEquivalents.Add("img", typeof(IImage));
			ElementTypeEquivalents.Add("select", typeof(IListPicker));
			ElementTypeEquivalents.Add("textarea", typeof(ITextArea));
			ElementTypeEquivalents.Add("frame", typeof(IWebView));
		}

		public static readonly Dictionary<string, Type> ElementTypeEquivalents;

		#endregion
	}
}