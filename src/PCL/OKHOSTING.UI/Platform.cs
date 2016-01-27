using System;
using System.Collections.Generic;

namespace OKHOSTING.UI
{
	/// <summary>
	/// Base class for platform independet apps, child classes should implement native platforms like WinForms, WebForms, XamarinForms, etc
	/// </summary>
	public abstract class Platform
	{
		//protected & internal

		/// <summary>
		/// The stack where we will keep and organization of which controller is currently executing (at top) and which are in the background
		/// </summary>
		protected readonly Stack<Controller> ControllerStack = new Stack<Controller>();

		/// <summary>
		/// Stores that state of a page between postbacks or between controller starts and finish
		/// </summary>
		protected readonly Stack<PageState> PageStateStack = new Stack<PageState>();

		protected internal virtual void StartController(Controller controller)
		{
			//save page state, if any
			if (PageState != null)
			{
				PageState.Title = Page.Title;
				PageState.Content = Page.Content;
			}

			//push controller and an empty state to stack
			PageStateStack.Push(new PageState());
			ControllerStack.Push(controller);

			//reset page
			Page.Title = string.Empty;
			Page.Content = null;
		}

		/// <summary>
		/// Remoes the current controller from the stack and recreates the previous controler state, if any
		/// </summary>
		protected internal virtual void FinishController()
		{
			//remove controller and state from stacks
			ControllerStack.Pop();
			PageStateStack.Pop();

			//is there still a controller and a page state? recreate that state
			if (PageState != null)
			{
				Page.Title = PageState.Title;
				Page.Content = PageState.Content;

				//refresh controller
				Controller.Refresh();
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
		/// Gets the Page that is currently being displayed to the user
		/// </summary>
		public virtual IPage Page
		{
			get; set;
		}

		/// <summary>
		/// Gets the Controller that is currently controlling the Page, the "currently executing" controller wich is at the top of the stack
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

		public virtual PageState PageState
		{
			get
			{
				if (PageStateStack.Count == 0)
				{
					return null;
				}

				return PageStateStack.Peek();
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