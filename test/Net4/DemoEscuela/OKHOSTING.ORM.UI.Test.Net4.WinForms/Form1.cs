using DemoEscuela;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKHOSTING.ORM.UI.Test.Net4.WinForms
{
    public partial class Form1 : OKHOSTING.UI.Net4.WinForms.Page
	{
        public Form1()
        {
            InitializeComponent(); //esto esta vacio, chequen el ejemplo que hicimos
        }

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (App == null)
			{
				App = new App();
				App.MainPage = this;
				App.MainPage.App = App;
			}

			if (App.State[App.MainPage].Count == 0)
			{
				((App)App).Start();
			}
		}
	}
}
