using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms
{
	public class Page : System.Web.UI.Page, IPage
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Platform.Current = new Platform(this);
			Platform.Current.Controller.Run();
		}

		public IControl Content
		{
			get
			{
				return (IControl) base.Controls[0];
			}
			set
			{
				Controls.Clear();

				if (value != null)
				{
					Controls.Add((System.Web.UI.Control)value);
				}
            }
		}
	}
}