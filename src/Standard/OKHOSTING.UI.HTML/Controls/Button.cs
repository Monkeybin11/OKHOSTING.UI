using AngleSharp;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using AngleSharp.Dom;

namespace OKHOSTING.UI.HTML.Controls
{
	public class Button : Control
	{
		public override string GenerateHtml()
		{
			var config = Configuration.Default;

			//Create a new context for evaluating webpages with the given config
			var context = BrowsingContext.New(config);

			//Parse the document from the content of a response to a virtual request
			var document = context.OpenNewAsync().Result;

			var button = document.CreateElement<IHtmlButtonElement>();
			button.Value = "https://okhosting.com";
			button.TextContent = "OK HOSTING";
			button.Title = "Lo mejor del mundo";

			return button.OuterHtml;
		}
	}
}
