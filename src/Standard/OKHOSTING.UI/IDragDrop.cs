using System;

namespace OKHOSTING.UI
{
	/// <summary>
	/// Enables drag and drop functionality
	/// </summary>
	public interface IDragDrop
	{
		/// <summary>
		/// Raised when a control has been dragged and dropped
		/// </summary>
		event EventHandler<IControl> ControlDropped;

		/// <summary>
		/// Allows a control to be dragged
		/// </summary>
		void AllowDrag(IControl control);

		/// <summary>
		/// Allows a control to receive controls that have been dragged into it
		/// </summary>
		void AllowDrop(IControl control);
	}
}