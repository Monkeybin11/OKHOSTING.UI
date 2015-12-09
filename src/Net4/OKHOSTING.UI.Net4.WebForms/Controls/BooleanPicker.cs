using System;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class BooleanPicker : System.Web.UI.WebControls.CheckBox, IBooleanPicker
	{
		#region IControl

		string IControl.Name
		{
			get
			{
				return base.ID;
			}
			set
			{
				base.ID = value;
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return WebForms.Page.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = WebForms.Page.Parse(value);
			}
		}

		Color IControl.BorderColor
		{
			get
			{
				return WebForms.Page.Parse(base.BorderColor);
			}
			set
			{
				base.BorderColor = WebForms.Page.Parse(value);
			}
		}

		double? IControl.Width
		{
			get
			{
				if (base.Width.IsEmpty)
				{
					return null;
				}

				return base.Width.Value;
			}
			set
			{
				if (value.HasValue)
				{
					base.Width = new System.Web.UI.WebControls.Unit(value.Value, System.Web.UI.WebControls.UnitType.Pixel);
				}
				else
				{
					base.Width = new System.Web.UI.WebControls.Unit();
				}
			}
		}

		double? IControl.Height
		{
			get
			{
				if (base.Height.IsEmpty)
				{
					return null;
				}

				return base.Height.Value;
			}
			set
			{
				if (value.HasValue)
				{
					base.Height = new System.Web.UI.WebControls.Unit(value.Value, System.Web.UI.WebControls.UnitType.Pixel);
				}
				else
				{
					base.Height = new System.Web.UI.WebControls.Unit();
				}
			}
		}

		Thickness IControl.Margin
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(base.Style["margin-left"], out left)) thickness.Left = left;
				if (double.TryParse(base.Style["margin-top"], out top)) thickness.Top = top;
				if (double.TryParse(base.Style["margin-right"], out right)) thickness.Right = right;
				if (double.TryParse(base.Style["margin-bottom"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) base.Style["margin-left"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) base.Style["margin-top"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) base.Style["margin-right"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) base.Style["margin-bottom"] = string.Format("{0}px", value.Bottom);
			}
		}

		Thickness IControl.BorderWidth
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(base.Style["border-left-width"], out left)) thickness.Left = left;
				if (double.TryParse(base.Style["border-top-width"], out top)) thickness.Top = top;
				if (double.TryParse(base.Style["border-right-width"], out right)) thickness.Right = right;
				if (double.TryParse(base.Style["border-bottom-width"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) base.Style["border-left-width"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) base.Style["border-top-width"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) base.Style["border-right-width"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) base.Style["border-bottom-width"] = string.Format("{0}px", value.Bottom);
			}
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				string cssClass = base.CssClass.Split().Where(c => c.StartsWith("horizontal-alignment")).SingleOrDefault();

				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return HorizontalAlignment.Left;
				}

				if (cssClass.EndsWith("left"))
				{
					return HorizontalAlignment.Left;
				}
				else if (cssClass.EndsWith("right"))
				{
					return HorizontalAlignment.Right;
				}
				else if (cssClass.EndsWith("center"))
				{
					return HorizontalAlignment.Center;
				}
				else if (cssClass.EndsWith("fill"))
				{
					return HorizontalAlignment.Fill;
				}
				else
				{
					return HorizontalAlignment.Left;
				}
			}
			set
			{
				WebForms.Page.RemoveCssClassesStartingWith(this, "horizontal-alignment");
				WebForms.Page.AddCssClass(this, "horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				string cssClass = base.CssClass.Split().Where(c => c.StartsWith("vertical-alignment")).SingleOrDefault();

				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return VerticalAlignment.Top;
				}

				if (cssClass.EndsWith("top"))
				{
					return VerticalAlignment.Top;
				}
				else if (cssClass.EndsWith("bottom"))
				{
					return VerticalAlignment.Bottom;
				}
				else if (cssClass.EndsWith("center"))
				{
					return VerticalAlignment.Center;
				}
				else if (cssClass.EndsWith("fill"))
				{
					return VerticalAlignment.Fill;
				}
				else
				{
					return VerticalAlignment.Top;
				}
			}
			set
			{
				WebForms.Page.RemoveCssClassesStartingWith(this, "vertical-alignment");
				WebForms.Page.AddCssClass(this, "vertical-alignment-" + value.ToString().ToLower());
			}
		}

		#endregion

		#region ITextControl

		Color ITextControl.FontColor
		{
			get
			{
				return WebForms.Page.Parse(base.ForeColor);
			}
			set
			{
				base.ForeColor = WebForms.Page.Parse(value);
			}
		}

		string ITextControl.FontFamily
		{
			get
			{
				return base.Font.Name;
			}
			set
			{
				base.Font.Name = value;
			}
		}

		double ITextControl.FontSize
		{
			get
			{
				return base.Font.Size.Unit.Value;
			}
			set
			{
				base.Font.Size = new System.Web.UI.WebControls.FontUnit(value, System.Web.UI.WebControls.UnitType.Pixel);
			}
		}

		bool ITextControl.Bold
		{
			get
			{
				return base.Font.Bold;
			}
			set
			{
				base.Font.Bold = value;
			}
		}

		bool ITextControl.Italic
		{
			get
			{
				return base.Font.Italic;
			}
			set
			{
				base.Font.Italic = value;
			}
		}

		bool ITextControl.Underline
		{
			get
			{
				return base.Font.Underline;
			}
			set
			{
				base.Font.Underline = value;
			}
		}

		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{

			get
			{
				string cssClass = base.CssClass.Split().Where(c => c.StartsWith("text-horizontal-alignment")).SingleOrDefault();

				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return HorizontalAlignment.Left;
				}

				if (cssClass.EndsWith("left"))
				{
					return HorizontalAlignment.Left;
				}
				else if (cssClass.EndsWith("right"))
				{
					return HorizontalAlignment.Right;
				}
				else if (cssClass.EndsWith("center"))
				{
					return HorizontalAlignment.Center;
				}
				else if (cssClass.EndsWith("fill"))
				{
					return HorizontalAlignment.Fill;
				}
				else
				{
					return HorizontalAlignment.Left;
				}
			}
			set
			{
				WebForms.Page.RemoveCssClassesStartingWith(this, "text-horizontal-alignment");
				WebForms.Page.AddCssClass(this, "text-horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get
			{
				string cssClass = base.CssClass.Split().Where(c => c.StartsWith("text-vertical-alignment")).SingleOrDefault();

				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return VerticalAlignment.Top;
				}

				if (cssClass.EndsWith("top"))
				{
					return VerticalAlignment.Top;
				}
				else if (cssClass.EndsWith("bottom"))
				{
					return VerticalAlignment.Bottom;
				}
				else if (cssClass.EndsWith("center"))
				{
					return VerticalAlignment.Center;
				}
				else if (cssClass.EndsWith("fill"))
				{
					return VerticalAlignment.Fill;
				}
				else
				{
					return VerticalAlignment.Top;
				}
			}
			set
			{
				WebForms.Page.RemoveCssClassesStartingWith(this, "text-vertical-alignment");
				WebForms.Page.AddCssClass(this, "text-vertical-alignment-" + value.ToString().ToLower());
			}
		}

		Thickness ITextControl.TextPadding
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(base.Style["padding-left"], out left)) thickness.Left = left;
				if (double.TryParse(base.Style["padding-top"], out top)) thickness.Top = top;
				if (double.TryParse(base.Style["padding-right"], out right)) thickness.Right = right;
				if (double.TryParse(base.Style["padding-bottom"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) base.Style["padding-left"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) base.Style["padding-top"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) base.Style["padding-right"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) base.Style["padding-bottom"] = string.Format("{0}px", value.Bottom);
			}
		}

		#endregion

		public bool SelectedValue
		{
			get
			{
				return base.Checked;
			}
			set
			{
				base.Checked = value;
			}
		}

	}
}