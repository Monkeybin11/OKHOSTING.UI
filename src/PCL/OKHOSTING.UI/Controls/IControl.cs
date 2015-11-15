using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	public interface IControl: IDisposable
	{
		string Name { get; set; }

		bool Visible { get; set; }
	}
}