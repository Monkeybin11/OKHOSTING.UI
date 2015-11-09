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
            ILabel label = Platform.Current.Create<ILabel>();
            label.Text = "hola amigo!";

            Platform.Current.Page.Title = "Escritorio";
            Platform.Current.Page.Content = label;
        }
    }
}