using OKHOSTING.UI.Controls;
using System.Drawing;

namespace OKHOSTING.UI.HTML.Controls
{
	public abstract class TextControl : Control, ITextControl
	{
		public string FontFamily { get; set; }
		public Color FontColor { get; set; }
		public double FontSize { get; set; }
		public bool Bold { get; set; }
		public bool Italic { get; set; }
		public bool Underline { get; set; }
		public HorizontalAlignment TextHorizontalAlignment { get; set; }
		public VerticalAlignment TextVerticalAlignment { get; set; }
		public Thickness TextPadding { get; set; }
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

		public abstract void Dispose();
	}
}