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
		/// Wether the font is bold or not
		/// </summary>
		bool Bold { get; set; }

		/// <summary>
		/// Wether the font is italic or not
		/// </summary>
		bool Italic { get; set; }

		/// <summary>
		/// Wether the font is underscored or not
		/// </summary>
		bool Underline { get; set; }

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