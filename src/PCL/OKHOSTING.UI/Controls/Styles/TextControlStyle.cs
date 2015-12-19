namespace OKHOSTING.UI.Controls.Styles
{
	/// <summary>
	/// Represents a style that can be applied to multiple ITextControls
	/// </summary>
	public class TextControlStyle: ControlStyle
	{
		/// <summary>
		/// Name of the font
		/// </summary>
		public string FontFamily { get; set; }

		/// <summary>
		/// Color of the font
		/// </summary>
		public Color FontColor { get; set; }

		/// <summary>
		/// Size of the font, in DIP
		/// </summary>
		public double FontSize { get; set; }

		/// <summary>
		/// Wether the font is bold or not
		/// </summary>
		public bool Bold { get; set; }

		/// <summary>
		/// Wether the font is italic or not
		/// </summary>
		public bool Italic { get; set; }

		/// <summary>
		/// Wether the font is underscored or not
		/// </summary>
		public bool Underline { get; set; }

		/// <summary>
		/// Horizontal alignment of the text with respect to the control
		/// </summary>
		public HorizontalAlignment TextHorizontalAlignment { get; set; }

		/// <summary>
		/// Vertical alignment of the text with respect to the control
		/// </summary>
		public VerticalAlignment TextVerticalAlignment { get; set; }

		/// <summary>
		/// Space that this control will set between a it's border and it's text
		/// </summary>
		public Thickness TextPadding { get; set; }

		/// <summary>
		/// Applies this style tho the provided ITextControl
		/// </summary>
		public virtual void ApplyTo(ITextControl control)
		{
			base.ApplyTo(control);

			control.FontFamily = this.FontFamily;
			control.FontColor = this.FontColor;
			control.FontSize = this.FontSize;
			control.Bold = this.Bold;
			control.Italic = this.Italic;
			control.Underline = this.Underline;
			control.TextHorizontalAlignment = this.TextHorizontalAlignment;
			control.TextVerticalAlignment = this.TextVerticalAlignment;
			control.TextPadding = this.TextPadding;
		}

		public override void ApplyTo(IControl control)
		{
			if (control is ITextControl)
			{
				ApplyTo((ITextControl) control);
			}
			else
			{
				base.ApplyTo(control);
			}
		}
	}
}