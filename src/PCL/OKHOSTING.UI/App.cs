using System;
using System.Collections.Generic;

namespace OKHOSTING.UI
{
	/// <summary>
	/// Base class for platform independet apps, this is where it all begins
	/// </summary>
	public abstract class App
	{
		/// <summary>
		/// Name of the App
		/// </summary>
		public readonly string Name;

		/// <summary>
		/// Version of the App
		/// </summary>
		public readonly string Version;

		/// <summary>
		/// Copyright of the App
		/// </summary>
		public readonly string Copyright;

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
		public IPage Page { get; protected set; }

		/// <summary>
		/// Gets the Controller that is currently controlling the view, the "currently executing" controller wich is at the top of the stack
		/// </summary>
		public Controller Controller
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
		/// The stack where we will keep and organization of which controller is currently executing (at top) and which are in the background
		/// </summary>
		internal readonly Stack<Controller> ControllerStack = new Stack<Controller>();

		/// <summary>
		/// Will be executed when this App "executes" at first
		/// </summary>
		public virtual void Start()
		{
			//set the first current controller and start it here
		}

		/// <summary>
		/// Will be execeuted once the controller has done it's workd. Use this to dispose objects and release memory
		/// </summary>
		public virtual void Finish()
		{
			Controller.Finish();
		}

		/// <summary>
		/// Gets the currently executing App. In a web environment, an App instance is created for each user
		/// </summary>
		public static App Current
		{
			get
			{
				return (App) Session.Current[typeof(App).FullName];
			}
			protected set
			{
				Session.Current[typeof(App).FullName] = value;
			}
		}
	}
}