using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Dom;
using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.HTML.Controls
{
	public class Label : TextControl, ILabel
	{
		public string Text { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public override void Dispose()
		{
		}

		public override string GenerateHtml()
		{
			var document = CreateDocument();

			var label = document.CreateElement<IHtmlLabelElement>();
			label.TextContent = Text;

			return label.OuterHtml;
		}
	}
}