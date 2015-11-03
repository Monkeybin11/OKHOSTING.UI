using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	public interface IControl
	{
		string Name { get; set; }

		/// <summary>
		/// Page that contains this control (directly or as a through another container)
		/// </summary>
		IPage Page { get; }

		bool Visible { get; set; }
	}
}