using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKHOSTING.Cine.UI.Net4.WinForms
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
