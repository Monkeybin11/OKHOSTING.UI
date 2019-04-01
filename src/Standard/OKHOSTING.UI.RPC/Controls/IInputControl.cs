namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// Defines methods that every webforms control must implement in order to handle state and postback values
	/// </summary>
	public interface IInputControl
	{
		/// <summary>
		/// Raises the ValueChanged event
		/// </summary>
		void RaiseValueChanged();
	}
}