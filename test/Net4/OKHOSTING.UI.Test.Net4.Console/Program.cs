using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace OKHOSTING.UI.Test.Net4.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			//Use the default configuration for AngleSharp
			var config = Configuration.Default;

			//Create a new context for evaluating webpages with the given config
			var context = BrowsingContext.New(config);

			//Parse the document from the content of a response to a virtual request
			var document = context.OpenAsync(req => req.Content("<h1>Some example source</h1><p>This is a paragraph element")).Result;

			var anchor = document.CreateElement<IHtmlAnchorElement>();
			anchor.Href = "https://okhosting.com";
			anchor.TextContent = "OK HOSTING";
			anchor.Title = "Lo mejor del mundo";

			var s = anchor.OuterHtml;

			var button = document.CreateElement<IHtmlButtonElement>();
			button.Value = "https://okhosting.com";
			button.TextContent = "OK HOSTING";
			button.Title = "Lo mejor del mundo";
			s = button.OuterHtml;

			document.FindDescendant<IHtmlBodyElement>().AppendElement(anchor);
			document.FindDescendant<IHtmlBodyElement>().AppendElement(button);

			s = document.DocumentElement.OuterHtml;
		}
	}
}
