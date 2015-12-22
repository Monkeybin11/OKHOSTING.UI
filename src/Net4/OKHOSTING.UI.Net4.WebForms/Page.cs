using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms
{
	public partial class Page : System.Web.UI.Page, IPage
	{
		protected System.Web.UI.WebControls.PlaceHolder ContentHolder;

		protected override void OnInit(EventArgs e)
		{
			if (ContentHolder == null)
			{
				ContentHolder = new System.Web.UI.WebControls.PlaceHolder();
				ContentHolder.ID = "pcContent";
				base.Form.Controls.Clear();
				base.Form.Controls.Add(ContentHolder);
			}

			//restore state
			if (IsPostBack)
			{
                Content = (IControl) Session["Content"];
			}

			base.OnInit(e);
		}

		public IControl Content
		{
			get
			{
				if (ContentHolder.Controls.Count == 0)
				{
					return null;
				}

				return (IControl) ContentHolder.Controls[0];
			}
			set
			{
				ContentHolder.Controls.Clear();

				if (value != null)
				{
					ContentHolder.Controls.Add((System.Web.UI.Control) value);
				}
			}
		}

		public double Width
		{
			get
			{
				return (double) OKHOSTING.UI.Session.Current[typeof(Page) + ".Width"];
			}
		}

		public double Height
		{
			get
			{
				return (double) OKHOSTING.UI.Session.Current[typeof(Page) + ".Height"];
			}
		}

		protected override void OnPreRenderComplete(EventArgs e)
		{
			base.OnPreRenderComplete(e);

			//save state
			Session["Content"] = Content;
		}
	}
}