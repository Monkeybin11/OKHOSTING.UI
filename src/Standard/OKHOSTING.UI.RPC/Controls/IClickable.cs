namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// Defines methods that every webforms control must implement in order to handle click events
	/// </summary>
	public interface IClickable
	{
		/// <summary>
		/// Raises the Click event, when necessary
		/// </summary>
		void RaiseClick();
	}
}