using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Dom;
using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.HTML.Controls
{
	public class Button : TextControl, IButton
	{
		public string Text { get; set; }

		public event EventHandler Click;

		public override string GenerateHtml()
		{
			var button = CreateElement<IHtmlButtonElement>();
			button.TextContent = Text;
			button.Title = Text;

			return button.OuterHtml;
		}

		public void Parse(IHtmlButtonElement htmlControl)
		{
			Text = htmlControl.TextContent;
			Visible = !htmlControl.IsHidden;
			Name = htmlControl.Id ?? htmlControl.Name;
			
			var css = htmlControl.Attributes["style"].Value;
			CSS.Style style = new CSS.Style();
			var parsed = style.ParseDeclaration(css);
			CSS.Style.Apply(parsed, this);
		}
	}
}
