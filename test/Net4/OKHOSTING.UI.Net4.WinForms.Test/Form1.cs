using OKHOSTING.UI.Test;
using System;

namespace OKHOSTING.UI.Net4.WinForms.Test
{
	public partial class Form1 : Page
	{
		public Form1()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (App == null)
			{
				App = new App();
				App.MainPage = this;
			}

			if (App.State[App.MainPage].Count == 0)
			{
				var index = new IndexController();
				index.Page = this;
				index.Start();
			}
		}
	}
}
