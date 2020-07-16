using System;

namespace OKHOSTING.UI.NetCore.Web.Syncfusion.Models
{
	public class ErrorViewModel
	{
		public string RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}
