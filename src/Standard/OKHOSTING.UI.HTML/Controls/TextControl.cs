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
	}
}