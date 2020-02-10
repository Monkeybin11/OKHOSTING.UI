using AngleSharp.Css.Dom;
using AngleSharp.Css.Parser;
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
		#region Protected

		/// <summary>
		/// A cache of parsed styles for better performance
		/// <para xml:lang="es">
		/// Un cache de estilos analizados para una mejor rendimiento.
		/// </para>
		/// </summary>
		protected readonly List<ICssRule> ParsedStyleRules = new List<ICssRule>();

		protected string[] SplitBySpace(string singleSelectorText)
		{
			return singleSelectorText.Split(' ').Select(s => s.Trim()).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
		}

		protected string[] SplitByCommas(string selectorText)
		{
			return selectorText.Split(',').Select(s => s.Trim()).ToArray();
		}

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

					if (subSelector == "*")
					{
						//do not filter
					}
					else if (subSelector.StartsWith("#"))
					{
						selected = SelectById(selected, subSelector);
					}
					else if (subSelector.Contains("."))
					{
						selected = SelectByClass(selected, subSelector);
					}
					else if (subSelector.Contains("["))
					{
						selected = SelectByAttribute(selected, subSelector);
					}
					else if (subSelector[0].Category() == CharExtensions.CharCategory.Letter)
					{
						selected = SelectByElementType(selected, subSelector);
					}

					else throw new ArgumentOutOfRangeException(nameof(subSelector), "Argument is not a supported CSS selector");
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
			return controls.Where(c => id.Equals(c.Name, StringComparison.InvariantCultureIgnoreCase));
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
			string className = selector.Substring(selector.IndexOf('.') + 1).ToLower();
			IEnumerable<IControl> result = controls;

			if (!string.IsNullOrWhiteSpace(element))
			{
				result = SelectByElementType(controls, element);
			}

			return result.Where(c => c.CssClass != null && SplitBySpace(c.CssClass.ToLower()).Contains(className));
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
		 
		/// <summary>
		/// This is a method for setter the width column with css grid
		/// </summary>
		/// <param name="control"></param>
		/// <param name="columns"></param>
		protected static void SetColumnWidth(IGrid grid, IEnumerable<Length> columns)
		{
			int frQuantility = 0;
			double columnsWidth = 0;
			int c = 0;

			foreach (var column in columns)
			{
				double lengthPixels = 0;

				if (column.Type == Length.Unit.Percent)
				{
					lengthPixels = column.Value / 100 * grid.Width.Value;
					columnsWidth += lengthPixels;
				}
				else if (column.Type == Length.Unit.Px)
				{
					lengthPixels = column.Value;
					columnsWidth += lengthPixels;
				}
				else if (column.Type == Length.Unit.Fr)
				{
					frQuantility++;
				}
				else if (column.IsAbsolute)
				{
					lengthPixels = column.ToPixel();
					columnsWidth += lengthPixels;
				}

				grid.SetHeight(c, lengthPixels);
				c++;
			}

			//Just for Fr
			c = 0;
			foreach (var column in columns)
			{
				double lengthPixels = 0;

				if (column.Type == Length.Unit.Fr)
				{
					lengthPixels = ((grid.Width.Value - columnsWidth) / frQuantility) * column.Value;
					grid.SetHeight(c, lengthPixels);
					c++;
				}
			}
		}

		/// <summary>
		/// This is a method for setter the height row height css grid
		/// </summary>
		/// <param name="control"></param>
		/// <param name="columns"></param>
		protected static void SetRowHeight(IGrid grid, IEnumerable<Length> rows)
		{
			int frQuantility = 0;
			double rowsWidth = 0;
			int r = 0;
			

			foreach (var row in rows)
			{
				double lengthPixels = 0;

					if (row.Type == Length.Unit.Percent)
					{
						lengthPixels = row.Value / 100 * grid.Width.Value;
						rowsWidth += lengthPixels;
					}
					else if (row.Type == Length.Unit.Px)
					{
						lengthPixels = row.Value;
						rowsWidth += lengthPixels;
					}
					else if (row.Type == Length.Unit.Fr)
					{
						frQuantility++;
					}
					else if (row.IsAbsolute)
					{
						lengthPixels = row.ToPixel();
						rowsWidth += lengthPixels;
					}

				grid.SetHeight(r, lengthPixels);
				r++;
			}

			//Just for Fr
			r = 0;
			foreach (var row in rows)
			{
				double lengthPixels = 0;

					if (row.Type == Length.Unit.Fr)
					{
						lengthPixels = ((grid.Width.Value - rowsWidth) / frQuantility) * row.Value;
					grid.SetHeight(r, lengthPixels);
					r++;
					}
			}
		}

		#endregion

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
			ICssStyleSheet cssStylesSheet = parser.ParseStyleSheet(styleSheet);
			
			//get only the rules that are actually styles
			foreach (var rule in cssStylesSheet.Rules)
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
			var allControls = App.GetParentAndAllChildren(page.Content);

			foreach (ICssRule rule in ParsedStyleRules)
			{
				if (rule is ICssStyleRule)
				{
					Apply((ICssStyleRule) rule);
				}
				else if (rule is ICssMediaRule)
				{
					var mediaRule = (ICssMediaRule) rule;
					bool mediaApplies = false;

					foreach (var media in mediaRule.Media)
					{
						if (media.Constraints.Contains("max-width"))
						{
							var maxWidth = media.Constraints.Trim('(', ')').Replace("max-width", null).Replace(":", null).Trim();

							if (Length.TryParse(maxWidth, out Length maxWidthLength))
							{
								if (maxWidthLength.ToPixel() > page.Width)
								{
									mediaApplies = true;
									break;
								}
							}
						}
					}

					if (mediaApplies)
					{
						foreach (ICssStyleRule rule2 in mediaRule.Rules.Where(r => r.Type == CssRuleType.Style))
						{
							Apply(rule2);
						}
					}
				}
			}

			void Apply(ICssStyleRule style)
			{
				var selectedControls = SelectBy(allControls, style.SelectorText);

				foreach (var control in selectedControls)
				{
					if (control is ITextControl)
					{
						Style.Apply(style.Style, (ITextControl) control);
					}
					else
					{
						Style.Apply(style.Style, control);
					}
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
			Length lenght;
			bool parsed;

			//this is a CSS grid
			if (style.GetDisplay() == "grid")
			{
				//Begin grid-template-columns
				var gridTemplateColumns = style.GetProperty("grid-template-columns");
				var grid = (IGrid)control;
				
				if (gridTemplateColumns != null)
				{
					var columns = ParseLengths(gridTemplateColumns.Value);
					SetColumnWidth(grid, columns);
				}
				//End grid-template-columns

				//Begin grid-template-rows
				var gridTemplateRows = style.GetProperty("grid-template-rows");

				if (gridTemplateRows != null)
				{
					var rows = ParseLengths(gridTemplateRows.Value);
					SetRowHeight(grid, rows);
				}
				//End grid-template-rows

				//Begin grid-template
				var gridTemplate = style.GetProperty("grid-template");

				if (gridTemplate != null)
				{
					var rowsColumns = gridTemplate.Value.Split('/');
					int count = 0;

					foreach (var rowcolumn in rowsColumns)
					{
						if (count == 0)
						{
							var rows = ParseLengths(rowcolumn);
							SetRowHeight(grid, rows);
						}
						else if (count == 1)
						{
							var columns = ParseLengths(rowcolumn);

							SetColumnWidth(grid, columns);

						}

						count++;
					}
				}
				//End grid-template

				//Begin grid-row-gap
				var gridRowGap = style.GetProperty("grid-row-gap");

				if (gridRowGap != null)
				{
					var rows = gridRowGap.Value.Split(' ');
					double lengthPixels = 0;

					if (Length.TryParse(rows[0], out Length length))
					{
						if (length.Type == Length.Unit.Percent)
						{
							lengthPixels = length.Value / 100 * control.Parent.Height.Value;
						}
						else if (length.Type == Length.Unit.Px)
						{
							lengthPixels = length.Value;

						}
						else if (length.IsAbsolute)
						{
							lengthPixels = length.ToPixel();
						}

						grid.CellMargin.Bottom = lengthPixels;
					}
				}
				//End grid-row-gap

				//Begin grid-column-gap
				var gridColumnGap = style.GetProperty("grid-column-gap");

				if (gridColumnGap != null)
				{
					double lengthPixels = 0;

					for (int i = 0; i < grid.ColumnCount; i++)
					{

						Length length = new Length();

						if (length.Type == Length.Unit.Percent)
						{
							lengthPixels = length.Value / 100 * control.Parent.Height.Value;
						}
						else if (length.Type == Length.Unit.Px)
						{
							lengthPixels = length.Value;

						}
						//else if (length.Type == Length.Unit.Fr)
						//{
						//	lengthPixels = (control.Parent.Width.Value - rowsWidth) / length.Value;
						//}
						else if (length.IsAbsolute)
						{
							lengthPixels = length.ToPixel();
						}

						grid.CellMargin.Right = lengthPixels;
					}
				}
				//End grid-column-gap

				//Begin grid-template-areas
				var gridTemplateAreas = style.GetProperty("grid-template-areas");

				if (gridTemplateAreas != null)
				{
					var rows = gridTemplateAreas.Value.Split('"').Where(x => !string.IsNullOrWhiteSpace(x));
					var rowsArray = rows.ToArray();
					int rowCounter = 0;
					var controlArray = App.GetParentAndAllChildren(control).ToArray();

					foreach (var row in rowsArray)
					{
						var columns = row.Split(' ');
						
						for (int column = 0; column < columns.Length; column ++)
						{
							//empty cell
							if (columns[column] == ".")
							{
								grid.SetContent(rowCounter, column, null);
								continue;
							}

							var controlToPosition = controlArray.Where(c => c.Name == columns[column]).SingleOrDefault();

							if (controlToPosition != null)
							{
								grid.SetContent(rowCounter, column, controlToPosition);
							}

							int colspan = 1;
							int currentColumn = column;

							for (; currentColumn < columns.Length; colspan++, currentColumn++)
							{
								if (columns[column + 1] != columns[column])
								{
									break;
								}
							}

							if (colspan > 1)
							{
								grid.SetColumnSpan(colspan, controlToPosition);
							}
						}

						rowCounter++;
					}
				}
				//end grid-template-areas

			}
			//End css grid




			//background and border colors
			if (!string.IsNullOrWhiteSpace(style.GetBackgroundColor()))
			{
				control.BackgroundColor = ParseColor(style.GetBackgroundColor());
			}

			if (!string.IsNullOrWhiteSpace(style.GetBorderColor()))
			{
				control.BorderColor = ParseColor(style.GetBorderColor());
			}
			
			//horizontal alignment http://www.w3schools.com/css/css_align.asp

			//horizontal alignment using float
			switch (style.GetFloat())
			{
				case "left":
					control.HorizontalAlignment = HorizontalAlignment.Left;
					break;

				case "right":
					control.HorizontalAlignment = HorizontalAlignment.Right;
					break;
			}

			//horizontal alignment using position
			if (!string.IsNullOrWhiteSpace(style.GetLeft()))
			{
				parsed = Length.TryParse(style.GetLeft(), out lenght);

				if (parsed && style.GetPosition() == "absolute" && lenght.ToPixel() == 0)
				{
					control.HorizontalAlignment = HorizontalAlignment.Left;
				}
			}

			if (!string.IsNullOrWhiteSpace(style.GetRight()))
			{
				parsed = Length.TryParse(style.GetRight(), out lenght);
				if (parsed && style.GetPosition() == "absolute" && lenght.ToPixel() == 0)
				{
					control.HorizontalAlignment = HorizontalAlignment.Right;
				}
			}

			//horizontal alignment using margin
			if (style.GetMargin() == "auto" || (style.GetMarginLeft() == "auto" && style.GetMarginRight() == "auto"))
			{
				control.HorizontalAlignment = HorizontalAlignment.Center;
			}

			//horizontal alignment using text align, online for inline elements
			if (style.GetDisplay() == "inline")
			{
				switch (style.GetTextAlign())
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
			switch (style.GetVerticalAlign())
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
			if (!string.IsNullOrWhiteSpace(style.GetHeight()))
			{
				if (Length.TryParse(style.GetHeight(), out lenght)) control.Height = lenght.ToPixel();
			}

			if (!string.IsNullOrWhiteSpace(style.GetWidth()))
			{
				if (Length.TryParse(style.GetWidth(), out lenght)) control.Width = lenght.ToPixel();
			}

			//border
			Thickness borderWidth = new Thickness();

			if (!string.IsNullOrWhiteSpace(style.GetBorderTopWidth()))
			{
				Length.TryParse(style.GetBorderTopWidth(), out lenght);
				borderWidth.Top = lenght.ToPixel();
			}

			if (!string.IsNullOrWhiteSpace(style.GetBorderRightWidth()))
			{
				Length.TryParse(style.GetBorderRightWidth(), out lenght);
				borderWidth.Right = lenght.ToPixel();
			}

			if (!string.IsNullOrWhiteSpace(style.GetBorderBottomWidth()))
			{
				Length.TryParse(style.GetBorderBottomWidth(), out lenght);
				borderWidth.Bottom = lenght.ToPixel();
			}

			if (!string.IsNullOrWhiteSpace(style.GetBorderLeftWidth()))
			{
				Length.TryParse(style.GetBorderLeftWidth(), out lenght);
				borderWidth.Left = lenght.ToPixel();
			}

			if (borderWidth.Top != null || borderWidth.Right != null || borderWidth.Bottom != null || borderWidth.Left != null)
			{
				control.BorderWidth = borderWidth;
			}

			//margin
			Thickness margin = new Thickness();
			if (!string.IsNullOrWhiteSpace(style.GetMarginTop()))
			{
				Length.TryParse(style.GetMarginTop(), out lenght);
				margin.Top = lenght.ToPixel();
			}

			if (!string.IsNullOrWhiteSpace(style.GetMarginRight()))
			{
				Length.TryParse(style.GetMarginRight(), out lenght);
				margin.Right = lenght.ToPixel();
			}

			if (!string.IsNullOrWhiteSpace(style.GetMarginBottom()))
			{
				Length.TryParse(style.GetMarginBottom(), out lenght);
				margin.Bottom = lenght.ToPixel();
			}

			if (!string.IsNullOrWhiteSpace(style.GetMarginLeft()))
			{
				Length.TryParse(style.GetMarginLeft(), out lenght);
				margin.Left = lenght.ToPixel();
			}

			if (margin.Top != null || margin.Right != null || margin.Bottom != null || margin.Left != null)
			{
				control.Margin = margin;
			}

			//padding
			Thickness padding = new Thickness();

			if (!string.IsNullOrWhiteSpace(style.GetPaddingTop()))
			{
				Length.TryParse(style.GetPaddingTop(), out lenght);
				padding.Top = lenght.ToPixel();
			}

			if (!string.IsNullOrWhiteSpace(style.GetPaddingRight()))
			{
				Length.TryParse(style.GetPaddingRight(), out lenght);
				padding.Right = lenght.ToPixel();
			}

			if (!string.IsNullOrWhiteSpace(style.GetPaddingBottom()))
			{
				Length.TryParse(style.GetPaddingBottom(), out lenght);
				padding.Bottom = lenght.ToPixel();
			}

			if (!string.IsNullOrWhiteSpace(style.GetPaddingLeft()))
			{
				Length.TryParse(style.GetPaddingLeft(), out lenght);
				padding.Left = lenght.ToPixel();
			}

			if (padding.Top != null || padding.Right != null || padding.Bottom != null || padding.Left != null)
			{
				control.Padding = padding;
			}

			//visibility
			if (!string.IsNullOrWhiteSpace(style.GetVisibility()))
			{
				control.Visible = style.GetVisibility() != "none" && style.GetVisibility() != "hidden";
			}
		}

		/// <summary>
		/// Applies a CSS style ato a ITextControl including font style
		/// <para xml:lang="es">
		/// Aplica un estilo CSS a un control de texto incluyendo el estilo del texto.
		/// </para>
		/// </summary>
		public static void Apply(ICssStyleDeclaration style, ITextControl control)
		{
			Apply(style, (IControl) control);

			//now for ITextControl properties
			control.Bold = style.GetFontWeight() == "bold";
			control.Italic = style.GetFontStyle() == "italic";
			control.Underline = style.GetTextDecoration() == "underline";

			if (!string.IsNullOrWhiteSpace(style.GetColor()))
			{
				control.FontColor = ParseColor(style.GetColor());
			}

			if (!string.IsNullOrWhiteSpace(style.GetFontFamily()))
			{
				control.FontFamily = style.GetFontFamily();
			}

			Length lenght;

			if (!string.IsNullOrWhiteSpace(style.GetFontSize()))
			{
				if (Length.TryParse(style.GetFontSize(), out lenght))
				{
					control.FontSize = lenght.ToPixel();
				}
			}

			switch (style.GetTextAlign())
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

		public static Color ParseColor(string rgbColor)
		{
			rgbColor = rgbColor.Replace("rgba(", null);
			rgbColor = rgbColor.Replace(")", null);
			var colors = rgbColor.Split(',');
			int a = int.Parse(colors[0]);
			int r = int.Parse(colors[1]);
			int g = int.Parse(colors[2]);
			int b = int.Parse(colors[3]);

			return Color.FromArgb(a, r, g, b);
		}

		public static IEnumerable<Length> ParseLengths(string lenghts)
		{
			foreach (var l in lenghts.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)))
			{
				Length parsed;
				
				if (Length.TryParse(l, out parsed))
				{
					yield return parsed;
				}
			}
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