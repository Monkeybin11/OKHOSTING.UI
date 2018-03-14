namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// Defines methods that every webforms control must implement in order to handle click events
	/// </summary>
	public interface IWebClickableControl
	{
		/// <summary>
		/// Raises the Click event
		/// </summary>
		void RaiseClick();
	}
}