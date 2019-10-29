using AngleSharp;
using AngleSharp.Dom;

namespace OKHOSTING.UI.HTML.Controls
{
	public abstract class Control
	{
		public abstract string GenerateHtml();

		protected virtual IDocument CreateDocument()
		{
			var config = Configuration.Default;

			//Create a new context for evaluating webpages with the given config
			var context = BrowsingContext.New(config);

			//Parse the document from the content of a response to a virtual request
			return context.OpenNewAsync().Result;
		}
	}
}