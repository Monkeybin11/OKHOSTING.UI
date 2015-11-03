using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms
{
	public class Page : System.Web.UI.Page, IPage
	{
		public IControl Content
		{
			get
			{
				return (IControl) base.Controls[0];
			}
			set
			{
				Controls.Clear();
				Controls.Add((System.Web.UI.Control) value);
			}
		}

		public event EventHandler Loaded;

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (Loaded != null)
			{
				Loaded(this, e);
			}
		}
	}
}