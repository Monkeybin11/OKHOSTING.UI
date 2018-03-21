using OKHOSTING.UI.Test;
using System;

namespace OKHOSTING.UI.Net4.WebForms.Test
{
	public partial class Default : Page
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (Width == 0 && Height == 0)
			{
				return;
			}

			if (Platform.Current.Controller == null)
			{
                new IndexController().Start();
                //new TextBoxController().Start();
			}
		}
	}
}