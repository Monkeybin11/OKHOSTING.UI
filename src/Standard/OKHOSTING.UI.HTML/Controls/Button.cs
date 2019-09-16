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

		public override void Dispose()
		{
		}

		public override string GenerateHtml()
		{
			var config = Configuration.Default;

			//Create a new context for evaluating webpages with the given config
			var context = BrowsingContext.New(config);

			//Parse the document from the content of a response to a virtual request
			var document = context.OpenNewAsync().Result;

			var button = document.CreateElement<IHtmlButtonElement>();
			button.TextContent = Text;
			button.Title = Text;

			return button.OuterHtml;
		}
	}
}
