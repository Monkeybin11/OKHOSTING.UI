using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Net4.WebForms
{
	public static class AppInterpreter
	{
		public static System.Web.UI.WebControls.WebControl Create(IView view)
		{
			if (view is UI.Button)
			{
				return new Button((UI.Button) view);
			}

			return null;
		}
	}
}