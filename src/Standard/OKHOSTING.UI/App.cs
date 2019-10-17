using System;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI
{
	/// <summary>
	/// Base class for platform independet apps
	/// <para xml:lang="es">
	/// Clase base para aplicaciones independientes de plataforma 
	/// </para>
	/// </summary>
	public class App: IDisposable
	{
		public readonly Dictionary<IPage, Stack<PageState>> State = new Dictionary<IPage, Stack<PageState>>();

		/// <summary>
		/// Returns the current state for ths specified page, null if none
		/// </summary>
		public PageState this[IPage page]
		{
			get
			{
				if (State.ContainsKey(page) && State[page].Count > 0)
				{
					return State[page].Peek();
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Start the contoller specified
		/// <para xml:lang="es">Inicializa el control especificado.</para>
		/// </summary>
		/// <param name="controller">The controller to start
		/// <para xml:lang="es">
		/// El control que se va a inicializar
		/// </para>
		/// </param>
		public virtual void StartController(Controller controller)
		{
			if (controller.Page == null)
			{
				controller.Page = MainPage;
			}

			var eventArgs = new ControllerEventArgs(controller);
			ControllerStarting?.Invoke(this, eventArgs);

			if (eventArgs.Cancel)
			{
				return;
			}

			//init the state for this page, if necessary
			if (!State.ContainsKey(controller.Page))
			{
				State.Add(controller.Page, new Stack<PageState>());
			}

			//push the current state to stack
			PageState currentState = new PageState(controller);
			State[controller.Page].Push(currentState);

			//reset page
			controller.Page.Title = string.Empty;
			controller.Page.Content = null;

			controller.OnStart();

			//save state
			currentState.Title = controller.Page.Title;
			currentState.Content = controller.Page.Content;

			ControllerStarted?.Invoke(this, controller);
		}

		/// <summary>
		/// Removes the current controller from the page's stack and recreates the previous controler state, if any
		/// <para xml:lang="es">
		/// Elimina el controlador actual de la pila de la pagina, y recrea el estado del controlador anterior, si lo hay
		/// </para>
		/// </summary>
		public virtual void FinishController(IPage page)
		{
			PageState state = this[page];

			if (state == null)
			{
				throw new ArgumentException("The provided page has no state, maybe no controllers has run on it yet", nameof(page));
			}

			//raise event
			var eventArgs = new ControllerEventArgs(state.Controller);
			ControllerFinishing?.Invoke(this, eventArgs);

			if (eventArgs.Cancel)
			{
				return;
			}

			//finish controllers and pages ised in UserControls
			foreach (Controls.IControl children in GetAllChildren(state.Content))
			{
				//found a user control
				if (children is IPage)
				{
					//finish all controllers
					while (State[(IPage) children].Count > 0)
					{
						FinishController((IPage) children);
					}

					//remove page from state
					State.Remove((IPage) children);
				}
			}

			//remove controller and state from stacks
			State[page].Pop();

			//raise event
			ControllerFinished?.Invoke(this, state.Controller);

			state = this[page];

			//is there still a controller and a page state? recreate that state
			if (state != null)
			{
				state.Controller.Page.Title = state.Title;
				state.Controller.Page.Content = state.Content;
			}
		}

		/// <summary>
		/// Exits and closes the current app. Use this to dispose objects and release memory
		/// <para xml:lang="es">
		/// Se sale y cierra la aplicacion actual. Use esto para desechar objetos y liberar la memoria.
		/// </para>
		/// </summary>
		public virtual void Finish()
		{
			foreach (IPage page in State.Keys)
			{
				while (State[page].Count > 0)
				{
					FinishController(page);
				}
			}
		}

		public virtual void Dispose()
		{
			Finish();
			State.Clear();
		}

		public IPage MainPage
		{
			get
			{
				return State.Keys.Where(p => !(p is Controls.IUserControl)).FirstOrDefault();
			}
			set
			{
				if (!State.ContainsKey(value))
				{
					State.Add(value, new Stack<PageState>());
				}
			}
		}

		#region Events

		/// <summary>
		/// Raised when a controller is about to start
		/// </summary>
		public event EventHandler<ControllerEventArgs> ControllerStarting;

		/// <summary>
		/// Raised when a controller is about to finish
		/// </summary>
		public event EventHandler<ControllerEventArgs> ControllerFinishing;

		/// <summary>
		/// Raised after a controller has started
		/// </summary>
		public event EventHandler<Controller> ControllerStarted;

		/// <summary>
		/// Raised after a controller as finished
		/// </summary>
		public event EventHandler<Controller> ControllerFinished;
		
		#endregion

		/// <summary>
		/// Gets a list of controls and subcontrols in a recursive way
		/// </summary>
		public static IEnumerable<Controls.IControl> GetAllChildren(Controls.IControl control)
		{
			if (control == null)
			{
				throw new ArgumentNullException(nameof(control));
			}

			if (control is Controls.IUserControl)
			{
				var content = ((Controls.IUserControl) control).Content;

				if (content != null)
				{
					yield return content;
				}

				foreach (var subChildren in GetAllChildren(content))
				{
					yield return subChildren;
				}
			}

			if (!(control is Controls.IContainer))
			{
				yield break;
			}

			foreach (var child in ((Controls.IContainer) control).Children)
			{
				yield return child;

				foreach (var subChild in GetAllChildren(child))
				{
					yield return subChild;
				}
			}
		}

		/// <summary>
		/// Gets a list of controls and subcontrols in a recursive way
		/// </summary>
		public static IEnumerable<Controls.IControl> GetAllChildren(IEnumerable<Controls.IControl> controls)
		{
			if (controls == null)
			{
				throw new ArgumentNullException(nameof(controls));
			}

			foreach (var control in controls)
			{
				foreach (var child in GetAllChildren(control))
				{
					yield return child;
				}
			}
		}
	}
}