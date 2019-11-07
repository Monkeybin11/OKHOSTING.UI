using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Dom;
using OKHOSTING.UI.Controls;
using System;
using System.Drawing;

namespace OKHOSTING.UI.HTML.Controls
{
	public class TextBox : TextControl, ITextBox
	{
		public ITextBoxInputType InputType { get; set; }
		public int MaxLength { get; set; }
		public string Placeholder { get; set; }
		public Color PlaceholderColor { get; set; }
		public string Value { get; set; }

		public event EventHandler<string> ValueChanged;

		public override string GenerateHtml()
		{
			var input = CreateElement<IHtmlInputElement>();
			input.TextContent = Value;
			input.Type = InputType.ToString().ToLower();
			input.MaxLength = MaxLength;
			
			return input.OuterHtml;
		}
	}
}