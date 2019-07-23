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

			App app = (App) Session["App"];

			if (app.State.Count == 0)
			{
				//new IndexController().Start();
				//new TextBoxController().Start();
			}
		}
	}
}