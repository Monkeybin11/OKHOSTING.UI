using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class HyperLink : System.Web.UI.WebControls.HyperLink, IHyperLink
	{
		public string Name
		{
			get
			{
				return base.ID;
			}
			set
			{
				base.ID = value;
			}
		}

		public Uri Uri
		{
			get
			{
				return new Uri(base.NavigateUrl);
			}
			set
			{
				base.NavigateUrl = value.ToString();
			}
		}
	}
}