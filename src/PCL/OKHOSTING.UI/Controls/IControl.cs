using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	public interface IControl: IDisposable
	{
		string Name { get; set; }

		bool Visible { get; set; }
		bool Enabled { get; set; }
		Color BackgroundColor { get; set; }
		Color ForegroundColor { get; set; }
		Distance Width { get; set; }
		Distance Height { get; set; }
	}
}