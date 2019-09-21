using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.RPC.Controls
{
	public class WebView: Control, IWebView
	{
		public System.Uri Source
		{
			get
			{
				return (System.Uri) Get(nameof(Source));
			}
			set
			{
				Set(nameof(Source), value);
			}
		}
	}
}