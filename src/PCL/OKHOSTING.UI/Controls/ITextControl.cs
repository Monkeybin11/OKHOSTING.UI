using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A control that can contain text, therefore has font properties
	/// </summary>
	public interface ITextControl: IControl
	{
		string FontFamily { get; set; }
		Color FontColor { get; set; }
		double FontSize { get; set; }
	}
}