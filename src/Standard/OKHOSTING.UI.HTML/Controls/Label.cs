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
	}
}