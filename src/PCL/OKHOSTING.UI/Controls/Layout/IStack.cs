using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Controls.Layout
{
	public interface IStack: IControl
	{
		IList<IControl> Children { get; }
	}
}