using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.UI.Controls.Layout
{
	public interface ITree: IContainer
	{
		ICollection<IControl> Children { get; }
	}
}
