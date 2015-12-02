using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A control that can contain text, therefore has font properties
	/// </summary>
	public interface ITextControl: IControl
	{
		/// <summary>
		/// Actual text that will be displayed and/or captured in the control
		/// </summary>
		string Text { get; set; }

		/// <summary>
		/// Name of the font
		/// </summary>
		string FontFamily { get; set; }

		/// <summary>
		/// Color of the font
		/// </summary>
		Color FontColor { get; set; }

		/// <summary>
		/// Size of the font, in DIP
		/// </summary>
		double FontSize { get; set; }

		/// <summary>
		/// Horizontal alignment of the text with respect to the control
		/// </summary>
		HorizontalAlignment TextHorizontalAlignment { get; set; }

		/// <summary>
		/// Vertical alignment of the text with respect to the control
		/// </summary>
		VerticalAlignment TextVerticalAlignment { get; set; }
	}
}