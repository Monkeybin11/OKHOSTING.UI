using System.Drawing;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace OKHOSTING.UI.HTML.Controls
{
	public abstract class Control: IControl
	{
		public abstract string GenerateHtml();

		protected virtual T CreateElement<T>() where T : IElement
		{
			if (Document == null)
			{
				var config = Configuration.Default;
				var context = BrowsingContext.New(config);
				Document = context.OpenNewAsync().Result;
			}

			//Parse the document from the content of a response to a virtual request
			return Document.CreateElement<T>();
		}

		public void Dispose()
		{
		}

		protected static IDocument Document { get; set; }

		public string Name { get; set; }
		public bool Visible { get; set; }
		public bool Enabled { get; set; }
		public double? Width { get; set; }
		public double? Height { get; set; }
		public Thickness Margin { get; set; }
		public Thickness Padding { get; set; }
		public Color BackgroundColor { get; set; }
		public Color BorderColor { get; set; }
		public Thickness BorderWidth { get; set; }
		public HorizontalAlignment HorizontalAlignment { get; set; }
		public VerticalAlignment VerticalAlignment { get; set; }
		public object Tag { get; set; }
		public string CssClass { get; set; }

		public IControl Parent { get; protected set; }

		bool IControl.Focus()
		{
			return false;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}

		public virtual void Parse(IHtmlElement htmlControl)
		{
			Visible = !htmlControl.IsHidden;
			Name = htmlControl.Id;

			var css = htmlControl.Attributes["style"].Value;
			CSS.Style style = new CSS.Style();
			var parsed = style.ParseDeclaration(css);
			CSS.Style.Apply(parsed, this);
		}
	}
}