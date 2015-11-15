using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class HyperLink : System.Windows.Forms.LinkLabel, IHyperLink
	{
		public IPage Page
		{
			get
			{
				return (Page)base.FindForm();
			}
		}

		public Uri Uri
		{
			get
			{
				return new Uri(base.Text);
			}
			set
			{
				base.Text = value.ToString();
			}
		}
	}
}