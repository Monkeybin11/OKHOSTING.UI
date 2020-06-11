namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// Defines methods that every webforms control must implement in order to handle state and postback values
	/// </summary>
	public interface IInputControl
	{
		/// <summary>
		/// Takes the value that was posted by the user and returns true if ValueChanged event should be raised
		/// </summary>
		/// <param name="value">Value posted by the user in the postback</param>
		/// <returns>True if the value has changed, false otherwise</returns>
		void HandlePostBack();
	}
}