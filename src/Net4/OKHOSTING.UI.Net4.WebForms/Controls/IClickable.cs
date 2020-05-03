namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// Defines methods that every webforms control must implement in order to handle click events
	/// </summary>
	public interface IClickable : UI.Controls.IClickable
	{
		/// <summary>
		/// Raises the Click event, when necessary
		/// </summary>
		void RaiseClick();
	}
}