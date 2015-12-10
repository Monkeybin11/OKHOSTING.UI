using System;
using System.Linq;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using OKHOSTING.UI.Net4.WebForms.Controls;
using OKHOSTING.UI.Net4.WebForms.Controls.Layouts;

namespace OKHOSTING.UI.Net4.WebForms
{
	public partial class Page : System.Web.UI.Page, IPage
	{
		protected override void OnLoad(EventArgs e)
		{
            Controller.CurrentPage = this;

			if (Controller.CurrentController == null)
			{
				new Test.LoginController().Start();
			}
			else
			{
				Controller.CurrentController.Start();
			}

			base.OnLoad(e);
		}

		public IControl Content
		{
			get
			{
				if (phContent.Controls.Count == 0)
				{
					return null;
				}

				return (IControl) phContent.Controls[0];
			}
			set
			{
				phContent.Controls.Clear();

				if (value != null)
				{
					phContent.Controls.Add((System.Web.UI.Control) value);
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
	}
}