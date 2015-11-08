using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI
{
	/// <summary>
	/// Creates instances of controls and actually creates all UI for the user. 
	/// Inherited classes should create platform-specific controls and implement page navigation
	/// </summary>
	public abstract class Platform
	{
		public Platform(IPage page)
		{
			if (page == null)
			{
				throw new ArgumentNullException("page");
			}

			Page = page;
		}

		/// <summary>
		/// Gets the Page that is currently being displayed to the user
		/// </summary>
		public readonly IPage Page;

		/// <summary>
		/// Create a platform-specific UI control
		/// </summary>
		/// <typeparam name="T">Type of the control. Control must implement IControl</typeparam>
		/// <returns>
		/// An instance of T
		/// </returns>
		public abstract T Create<T>() where T : class, IControl;
		
		protected readonly Stack<Controller> ControllerStack = new Stack<Controller>();

		public virtual void Run(Controller controller)
		{
			Page.Content = null;
			ControllerStack.Push(controller);
		}

		public virtual void FinishController()
		{
			Page.Content = null;
			ControllerStack.Pop();
		}

		/// <summary>
		/// Gets the controller currently at the top of the stack (meaning it currently has control)
		/// </summary>
		public virtual Controller Controller
		{
			get
			{
				return ControllerStack.Peek();
			}
		}

		#region Static

		/// <summary>
		/// Current activator that will be used to create all controls. Set this at the very beginning of your app,
		/// and set a platform-specific Activator
		/// </summary>
		public static Platform Current
		{
			get
			{
				return (Platform) Session.Current["Platform"];
			}
			set
			{
				Session.Current["Platform"] = value;
			}
		}

		#endregion
	}
}