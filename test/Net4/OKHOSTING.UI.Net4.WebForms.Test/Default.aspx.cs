using OKHOSTING.UI.Test;
using System;

namespace OKHOSTING.UI.Net4.WebForms.Test
{
	public partial class Default : Page
	{
		public override void OnAppStart()
		{
			AjaxPostback = true;
			new IndexController() { Page = this }.Start();
		}
	}
}