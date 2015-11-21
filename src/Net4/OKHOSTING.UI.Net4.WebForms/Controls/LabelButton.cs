using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class LabelButton : System.Web.UI.WebControls.LinkButton, ILabelButton
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
	}
}