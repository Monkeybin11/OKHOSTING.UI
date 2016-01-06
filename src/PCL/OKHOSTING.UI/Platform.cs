using System;
using System.Collections.Generic;

namespace OKHOSTING.UI
{
	/// <summary>
	/// Base class for platform independet apps, this is where it all begins
	/// </summary>
	public abstract class Platform
	{
		//protected & internal

		/// <summary>
		/// The stack where we will keep and organization of which controller is currently executing (at top) and which are in the background
		/// </summary>
		protected readonly Stack<Controller> ControllerStack = new Stack<Controller>();

		protected internal virtual void StartController(Controller controller)
		{
			if (Controller != controller)
			{
				ControllerStack.Push(controller);
			}
		}

		protected internal virtual void FinishController()
		{
			Controller current = ControllerStack.Pop();

			if (current.Page != null)
			{
				//current.Page.Dispose();
			}
		}

		//public

		/// <summary>
		/// Create a platform-specific UI control
		/// </summary>
		/// <typeparam name="T">Type of the control. Control must implement IControl</typeparam>
		/// <returns>
		/// An instance of control T
		/// </returns>
		public abstract T Create<T>() where T : class, Controls.IControl;

		/// <summary>
		/// Gets the Controller that is currently controlling the view, the "currently executing" controller wich is at the top of the stack
		/// </summary>
		public virtual Controller Controller
		{
			get
			{
				if (ControllerStack.Count == 0)
				{
					return null;
				}

				return ControllerStack.Peek();
			}
		}

		/// <summary>
		/// Exits and closes the current app. Use this to dispose objects and release memory
		/// </summary>
		public virtual void Finish()
		{
			Controller.Finish();
		}

		//static

		/// <summary>
		/// Gets the currently executing App. In a web environment, an App instance is created for each user
		/// </summary>
		public static Platform Current
		{
			get
			{
				if (Session.Current.ContainsKey(typeof(Platform).FullName))
				{
					return (Platform) Session.Current[typeof(Platform).FullName];
				}
				else
				{
					return null;
				}
			}
			protected set
			{
				Session.Current[typeof(Platform).FullName] = value;
			}
		}
	}
}