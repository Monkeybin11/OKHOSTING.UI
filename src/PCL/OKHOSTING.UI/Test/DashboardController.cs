using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using System;

namespace OKHOSTING.UI.Test
{
	public class DashboardController : Controller
	{
		public override void Start()
		{
			ILabel label = CurrentPage.Create<ILabel>();
			label.Text = "hola amigo!";

			CurrentPage.Title = "Escritorio";
			CurrentPage.Content = label;
		}
	}
}