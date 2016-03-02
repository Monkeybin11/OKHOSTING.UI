using OKHOSTING.UI.Test;
using System;

namespace OKHOSTING.UI.Net4.WinForms.Test
{
	public partial class Form1 : OKHOSTING.UI.Net4.WinForms.Page
	{
		public Form1()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (Platform.Current.Controller == null)
			{
                Platform.Current.Page = this;
				new IndexController().Start();
			}
		}
	}
}
