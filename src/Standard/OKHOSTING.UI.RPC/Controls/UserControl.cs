using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// An IPage that is also a Control, allowing you to add it as a control, but then assign a controller to it and let it work.
	/// The controller will believe this is the main Page and will work as espected, inside the UserControl.
	/// </summary>
	public class UserControl : Control, IUserControl
	{
		public App App
		{
			get
			{
				return (App) Get(nameof(App));
			}
			set
			{
				Set(nameof(App), value);
			}
		}

		public string Title
		{
			get
			{
				return (string) Get(nameof(Title));
			}
			set
			{
				Set(nameof(Title), value);
			}
		}

		public IControl Content
		{
			get
			{
				return (IControl) Get(nameof(Content));
			}
			set
			{
				Set(nameof(Content), value);
			}
		}

		public event EventHandler Resized
		{
			add
			{
				AddHybridEventHandler(nameof(Resized), value);
			}
			remove
			{
				RemoveHybridEventHandler(nameof(Resized), value);
			}
		}
	}
}