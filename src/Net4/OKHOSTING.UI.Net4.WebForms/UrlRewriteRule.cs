using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Net4.WebForms
{
	/// <summary>
	/// Allows you to specify friendly URLs that map to specific controllers, you can use the pattrern to store variables like
	/// </summary>
	public abstract class UrlRewriteRule
	{
		public Guid Id { get; set; }

		/// <summary>
		/// Url requests that matches this regex will be handled by this rule
		/// </summary>
		public string UrlRegexPattern { get; set; }

		/// <summary>
		/// Type of controller that this rule is linked to
		/// </summary>
		public Type ControllerType { get; set; }

		/// <summary>
		/// Returns the correct controller that should be runned on this URL
		/// </summary>
		/// <param name="requestedUri">The requested Uri</param>
		/// <returns>The controller that should be started</returns>
		public abstract Controller GetController(Uri requestedUri);

		/// <summary>
		/// Returns the correct controller that should be runned on this URL
		/// </summary>
		/// <param name="requestedUri">The requested Uri</param>
		/// <returns>The controller that should be started</returns>
		public abstract Uri GetUri(Controller controller);
	}
}