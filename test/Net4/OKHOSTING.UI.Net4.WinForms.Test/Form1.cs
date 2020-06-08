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

			App = new App();
			App.MainPage = this;
			
			var index = new UI.Test.IndexController(this);
			index.Start();
		}
	}
}
