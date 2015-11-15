using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class Button : System.Web.UI.WebControls.Button, IButton
	{
		public string Name
		{
			get
			{
				return base.ID;
			}

			set
			{
				base.ID = value;
			}
		}
	}
}