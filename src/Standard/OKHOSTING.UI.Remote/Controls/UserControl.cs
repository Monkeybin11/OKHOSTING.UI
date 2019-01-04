using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Remote.Controls
{
	/// <summary>
	/// An IPage that is also a Control, allowing you to add it as a control, but then assign a controller to it and let it work.
	/// The controller will believe this is the main Page and will work as espected, inside the UserControl.
	/// </summary>
	public class UserControl : Control, IUserControl
	{
		public App App { get; set; }
		public string Title { get; set; }
		public IControl Content { get; set; }

		public event EventHandler Resized;
	}
}