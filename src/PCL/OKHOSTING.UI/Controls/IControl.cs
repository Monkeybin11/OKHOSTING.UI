using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	public interface IControl: IDisposable
	{
		string Name { get; set; }

		bool Visible { get; set; }
		bool Enabled { get; set; }

		/// <summary>
		/// Width of the control, in density independent pixels
		/// </summary>
		double Width { get; set; }

		/// <summary>
		/// Height of the control, in density independent pixels
		/// </summary>
		double Height { get; set; }

		Color BackgroundColor { get; set; }

		string FontFamily { get; set; }
		Color FontColor { get; set; }
		double FontSize { get; set; }

		Color BorderColor { get; set; }
		double BorderWidth { get; set; }
	}
}