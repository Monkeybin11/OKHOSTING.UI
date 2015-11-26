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
		int Width { get; set; }

		/// <summary>
		/// Height of the control, in density independent pixels
		/// </summary>
		int Height { get; set; }

		Color BackgroundColor { get; set; }

		string FontFamily { get; set; }
		Color FontColor { get; set; }
		int FontSize { get; set; }

		Color BorderColor { get; set; }
		Measure BorderSize { get; set; }
	}
}