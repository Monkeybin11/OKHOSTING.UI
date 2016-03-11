using OKHOSTING.UI.Test;
using System;

namespace OKHOSTING.UI.Net4.WebForms.Test
{
	public partial class Default : OKHOSTING.UI.Net4.WebForms.Page
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			//page size is yet to be determined, since this is the first load
			if (!IsPostBack && Width == 0 && Height == 0)
			{
				return;
			}

			if (Platform.Current.Controller == null)
			{
				new IndexController().Start();
			}
		}
	}
}