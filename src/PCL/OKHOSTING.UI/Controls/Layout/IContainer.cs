using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Controls.Layouts
{
	public abstract class IContainer: IControl
	{
		public readonly List<IView> Children;
	}
}