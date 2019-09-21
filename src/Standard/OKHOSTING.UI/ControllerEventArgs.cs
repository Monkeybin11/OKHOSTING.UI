using System;

namespace OKHOSTING.UI
{
	/// <summary>
	/// Event arguments for controller events
	/// </summary>
	public class ControllerEventArgs: EventArgs
	{
		/// <summary>
		/// Controller that is raising the event
		/// </summary>
		public readonly Controller Controller;

		/// <summary>
		/// Set to true to cancel the current operations, false to continue normally
		/// </summary>
		public bool Cancel { get; set; } = false;

		public ControllerEventArgs(Controller controller)
		{
			Controller = controller;
		}
	}
}