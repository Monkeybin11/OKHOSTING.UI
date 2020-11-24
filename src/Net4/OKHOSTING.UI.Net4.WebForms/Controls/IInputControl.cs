namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// Defines methods that every webforms control must implement in order to handle state and postback values
	/// </summary>
	internal interface IInputControl
	{
		/// <summary>
		/// Takes the value that was posted by the user and returns true if HandlePostBack method should be called
		/// </summary>
		/// <returns>True if the value has changed, false otherwise</returns>
		bool CheckPostBack();

		/// <summary>
		/// Takes the value that was posted by the user and returns true if ValueChanged event should be raised
		/// </summary>
		void HandlePostBack();
	}
}