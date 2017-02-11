using System;
using AngleSharp;
using AngleSharp.Parser.Html;

namespace OKHOSTING.UI.Net4.Ajax
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			SessionIdProvider.Setup();
		}

		protected void Session_Start(object sender, EventArgs e)
		{
			//Create a (re-usable) parser front-end
			var parser = new HtmlParser();
			//Source to be pared
			var source = "<h1>Some example source</h1><p>This is a paragraph element";
			//Parse source to document
			var document = parser.Parse(source);
			
			//Do something with document like the following

			Console.WriteLine("Serializing the (original) document:");
			Console.WriteLine(document.DocumentElement.OuterHtml);

			var p = document.CreateElement("p");
			p.TextContent = "This is another paragraph.";

			Console.WriteLine("Inserting another element in the body ...");
			document.Body.AppendChild(p);

			Console.WriteLine("Serializing the document again:");
			Console.WriteLine(document.DocumentElement.OuterHtml);
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		void Application_PreRequestHandlerExecute(object sender, EventArgs e)
		{
			//var page = (Context.Handler as System.Web.UI.Page);
		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}