using OKHOSTING.UI.Controls;
using System;
using System.Linq;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class Autocomplete : System.Web.UI.WebControls.Panel, IAutocomplete
	{
		protected readonly TextBox InnerTextBox;
		protected readonly AjaxControlToolkit.AutoCompleteExtender InnerAutoCompleteExtender;
		protected readonly AjaxControlToolkit.TextBoxWatermarkExtender InnerWatermarkExtender;
		protected readonly string SessionId;

		public Autocomplete()
		{
			//set a default id so we ensure the extender's TargetControlID is set
			InnerTextBox = (TextBox) Platform.Current.Create<ITextBox>();
			InnerTextBox.ID = "Autocomplete_InnerTextBox_" + new Random().Next();
			base.Controls.Add(InnerTextBox);

			//ajax autocompleter
			InnerAutoCompleteExtender = new AjaxControlToolkit.AutoCompleteExtender();
			InnerAutoCompleteExtender.ID = base.UniqueID + "_AutoCompleteExtender";
			InnerAutoCompleteExtender.TargetControlID = InnerTextBox.ID;
			InnerAutoCompleteExtender.UseContextKey = true;
			InnerAutoCompleteExtender.ServiceMethod = "Search";
			InnerAutoCompleteExtender.ServicePath = "/Services/AutoCompleteService.asmx";
			//InnerAutoCompleteExtender.CompletionListCssClass = "AutoComplete_List";
			//InnerAutoCompleteExtender.CompletionListItemCssClass = "AutoComplete_ListItem";
			InnerAutoCompleteExtender.EnableCaching = false;
			base.Controls.Add(InnerAutoCompleteExtender);

			//ajax watermark
			InnerWatermarkExtender = new AjaxControlToolkit.TextBoxWatermarkExtender();
			InnerWatermarkExtender.WatermarkText = "Search";
			InnerWatermarkExtender.ID = base.UniqueID + "_TextBoxWatermarkExtender";
			InnerWatermarkExtender.TargetControlID = InnerTextBox.ID;
			//InnerWatermarkExtender.WatermarkCssClass = "AutoComplete_Watermark";
			base.Controls.Add(InnerWatermarkExtender);

			//add a unique id to session so we can invoke OnSearching from a ashx page
			SessionId = "Autocomplete_" + new Random().Next();
			OKHOSTING.UI.Session.Current[SessionId] = this;
			InnerAutoCompleteExtender.ContextKey = SessionId;
		}
		
		public event EventHandler<AutocompleteSearchEventArgs> Searching;

		AutocompleteSearchEventArgs IAutocomplete.OnSearching(string text)
		{
			AutocompleteSearchEventArgs e = new AutocompleteSearchEventArgs(text);

			if (Searching != null)
			{
				Searching(this, e);
			}

			return e;
		}

		protected override void OnPreRender(EventArgs e)
		{
			InnerTextBox.AutoPostBack = ValueChanged != null;
			base.OnPreRender(e);
		}

		#region IInputControl

		public event EventHandler<string> ValueChanged;

		string IInputControl<string>.Value
		{
			get
			{
				return InnerTextBox.Text;
			}
			set
			{
				InnerTextBox.Text = value;
			}
		}

		protected internal void RaiseValueChanged()
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, ((IInputControl<string>) this).Value);
			}
		}

		#endregion

		#region IControl

		string IControl.Name
		{
			get
			{
				return InnerTextBox.ID;
			}
			set
			{
				InnerTextBox.ID = value;
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return Platform.Current.Parse(InnerTextBox.BackColor);
			}
			set
			{
				InnerTextBox.BackColor = Platform.Current.Parse(value);
			}
		}

		Color IControl.BorderColor
		{
			get
			{
				return Platform.Current.Parse(InnerTextBox.BorderColor);
			}
			set
			{
				InnerTextBox.BorderColor = Platform.Current.Parse(value);
			}
		}

		double? IControl.Width
		{
			get
			{
				if (InnerTextBox.Width.IsEmpty)
				{
					return null;
				}

				return InnerTextBox.Width.Value;
			}
			set
			{
				if (value.HasValue)
				{
					InnerTextBox.Width = new System.Web.UI.WebControls.Unit(value.Value, System.Web.UI.WebControls.UnitType.Pixel);
				}
				else
				{
					InnerTextBox.Width = new System.Web.UI.WebControls.Unit();
				}
			}
		}

		double? IControl.Height
		{
			get
			{
				if (InnerTextBox.Height.IsEmpty)
				{
					return null;
				}

				return InnerTextBox.Height.Value;
			}
			set
			{
				if (value.HasValue)
				{
					InnerTextBox.Height = new System.Web.UI.WebControls.Unit(value.Value, System.Web.UI.WebControls.UnitType.Pixel);
				}
				else
				{
					InnerTextBox.Height = new System.Web.UI.WebControls.Unit();
				}
			}
		}

		Thickness IControl.Margin
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(InnerTextBox.Style["margin-left"], out left)) thickness.Left = left;
				if (double.TryParse(InnerTextBox.Style["margin-top"], out top)) thickness.Top = top;
				if (double.TryParse(InnerTextBox.Style["margin-right"], out right)) thickness.Right = right;
				if (double.TryParse(InnerTextBox.Style["margin-bottom"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) InnerTextBox.Style["margin-left"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) InnerTextBox.Style["margin-top"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) InnerTextBox.Style["margin-right"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) InnerTextBox.Style["margin-bottom"] = string.Format("{0}px", value.Bottom);
			}
		}

		Thickness IControl.BorderWidth
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(InnerTextBox.Style["border-left-width"], out left)) thickness.Left = left;
				if (double.TryParse(InnerTextBox.Style["border-top-width"], out top)) thickness.Top = top;
				if (double.TryParse(InnerTextBox.Style["border-right-width"], out right)) thickness.Right = right;
				if (double.TryParse(InnerTextBox.Style["border-bottom-width"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) InnerTextBox.Style["border-left-width"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) InnerTextBox.Style["border-top-width"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) InnerTextBox.Style["border-right-width"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) InnerTextBox.Style["border-bottom-width"] = string.Format("{0}px", value.Bottom);
			}
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				string cssClass = InnerTextBox.CssClass.Split().Where(c => c.StartsWith("horizontal-alignment")).SingleOrDefault();

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
				Platform.Current.RemoveCssClassesStartingWith(this, "horizontal-alignment");
				Platform.Current.AddCssClass(this, "horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				string cssClass = InnerTextBox.CssClass.Split().Where(c => c.StartsWith("vertical-alignment")).SingleOrDefault();

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
				Platform.Current.RemoveCssClassesStartingWith(this, "vertical-alignment");
				Platform.Current.AddCssClass(this, "vertical-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// </remmarks>
		object IControl.Tag
		{
			get; set;
		}

		#endregion

		#region ITextControl

		Color ITextControl.FontColor
		{
			get
			{
				return Platform.Current.Parse(InnerTextBox.ForeColor);
			}
			set
			{
				InnerTextBox.ForeColor = Platform.Current.Parse(value);
			}
		}

		string ITextControl.FontFamily
		{
			get
			{
				return InnerTextBox.Font.Name;
			}
			set
			{
				InnerTextBox.Font.Name = value;
			}
		}

		double ITextControl.FontSize
		{
			get
			{
				return InnerTextBox.Font.Size.Unit.Value;
			}
			set
			{
				InnerTextBox.Font.Size = new System.Web.UI.WebControls.FontUnit(value, System.Web.UI.WebControls.UnitType.Pixel);
			}
		}

		bool ITextControl.Bold
		{
			get
			{
				return InnerTextBox.Font.Bold;
			}
			set
			{
				InnerTextBox.Font.Bold = value;
			}
		}

		bool ITextControl.Italic
		{
			get
			{
				return InnerTextBox.Font.Italic;
			}
			set
			{
				InnerTextBox.Font.Italic = value;
			}
		}

		bool ITextControl.Underline
		{
			get
			{
				return InnerTextBox.Font.Underline;
			}
			set
			{
				InnerTextBox.Font.Underline = value;
			}
		}

		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{

			get
			{
				string cssClass = InnerTextBox.CssClass.Split().Where(c => c.StartsWith("text-horizontal-alignment")).SingleOrDefault();

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
				Platform.Current.RemoveCssClassesStartingWith(this, "text-horizontal-alignment");
				Platform.Current.AddCssClass(this, "text-horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get
			{
				string cssClass = InnerTextBox.CssClass.Split().Where(c => c.StartsWith("text-vertical-alignment")).SingleOrDefault();

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
				Platform.Current.RemoveCssClassesStartingWith(this, "text-vertical-alignment");
				Platform.Current.AddCssClass(this, "text-vertical-alignment-" + value.ToString().ToLower());
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

		private class EventArgs<T>
		{
			public EventArgs()
			{
			}
		}

		#endregion
	}
}