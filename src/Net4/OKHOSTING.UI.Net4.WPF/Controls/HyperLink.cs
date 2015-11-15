using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class HyperLink : System.Windows.Documents.Hyperlink, IHyperLink
	{
		public string Text
		{
			get;
			set;
		}

		public Uri Uri
		{
			get
			{
				return base.NavigateUri;
			}
			set
			{
				base.NavigateUri = value;
			}
		}

		public bool Visible
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public void Dispose()
		{
		}
	}
}