using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms
{
    public partial class Page : System.Web.UI.Page, IPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Platform.Current = new Platform(this);
            Platform.Current.Controller.Start();
        }

        public IControl Content
        {
            get
            {
                if (base.Form.Controls.Count == 0)
                {
                    return null;
                }

                return (IControl) base.Form.Controls[0];
            }
            set
            {
                Form.Controls.Clear();

                if (value != null)
                {
                    Form.Controls.Add((System.Web.UI.Control) value);
                }
            }
        }
    }
}