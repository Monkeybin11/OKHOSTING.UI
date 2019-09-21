using System;

namespace OKHOSTING.UI.Net4.WebForms
{
	/// <summary>
	/// Creates simple rules to show a controller using the controller's full name as the url
	/// </summary>
	public class UrlRewriteBasicRule : UrlRewriteRule
	{
		/// <summary>
		/// Returns the correct controller that should be runned on this URL
		/// </summary>
		/// <param name="requestedUri">The requested Uri</param>
		/// <returns>The controller that should be started</returns>
		public override Controller GetController(Uri requestedUri)
		{
			Type controllerType = Type.GetType(requestedUri.PathAndQuery);

			return (Controller) Core.BaitAndSwitch.Create(controllerType);
		}

		/// <summary>
		/// Returns the correct controller that should be runned on this URL
		/// </summary>
		/// <param name="requestedUri">The requested Uri</param>
		/// <returns>The controller that should be started</returns>
		public override Uri GetUri(Controller controller)
		{
			return new Uri(controller.GetType().FullName);
		}
	}
}