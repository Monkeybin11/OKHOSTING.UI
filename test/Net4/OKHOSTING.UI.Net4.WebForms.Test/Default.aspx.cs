using OKHOSTING.UI.Test;
using System;

namespace OKHOSTING.UI.Net4.WebForms.Test
{
	public partial class Default : Page
	{
		protected override void OnInit(EventArgs e)
		{
			AjaxPostback = true;
			base.OnInit(e);
		}

		public override void OnAppStart()
		{
			new IndexController() { Page = this }.Start();
		}
	}
}