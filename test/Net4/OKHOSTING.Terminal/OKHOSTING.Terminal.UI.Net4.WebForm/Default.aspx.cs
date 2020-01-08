using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OKHOSTING.Terminal;

namespace OKHOSTING.Terminal.UI.Net4.WebForm
{
    public partial class Default : OKHOSTING.UI.Net4.WebForms.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Width == 0 && Height == 0)
            {
                return;
            }

            App app = (App)Session["App"];
            app.MainPage = this;
            this.App = app;

            if (app.State[app.MainPage].Count == 0)
            {
                app.Start();
            }
        }
    }
}