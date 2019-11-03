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
			var button = CreateElement<IHtmlButtonElement>();
			button.TextContent = Text;
			button.Title = Text;

			return button.OuterHtml;
		}
	}
}
