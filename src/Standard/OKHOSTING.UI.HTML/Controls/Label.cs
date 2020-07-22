using AngleSharp.Html.Dom;
using AngleSharp.Dom;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.HTML.Controls
{
	public class Label : TextControl, ILabel
	{
		public string Text { get; set; }

		public override string GenerateHtml()
		{
			var label = CreateElement<IHtmlLabelElement>();
			label.TextContent = Text;

			return label.OuterHtml;
		}

		public void Parse(IHtmlLabelElement htmlControl)
		{
			Text = htmlControl.TextContent;
			Name = htmlControl.Id;
			var css = htmlControl.Attributes["style"].Value;
			CSS.Style style = new CSS.Style();
			var parsed = style.ParseDeclaration(css);
			CSS.Style.Apply(parsed, this);
		}
	}
}