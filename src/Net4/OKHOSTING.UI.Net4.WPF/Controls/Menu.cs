using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class Menu: System.Windows.Controls.Menu, IMenu
	{
		public Menu()
		{
			var x = (System.Windows.Controls.MenuItem)base.Items[0];
			
		}
	}
}