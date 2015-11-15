using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI
{
	/// <summary>
	/// This is the class that controlls all the UI. Inherit from Controller and create your app specific controllers.
	/// Each controller can have many methods 
	/// </summary>
	public abstract class Controller
	{
		public virtual void Start()
		{
			CurrentPage.Content = null;
			Stack.Push(this);
		}

		public virtual void Finish()
		{
			Stack.Pop();

			if (CurrentPage.Content != null)
			{
				CurrentPage.Content.Dispose();
			}

			CurrentPage.Content = null;
		}

		#region Static

		static Controller()
		{
			Stack.Push(new Test.LoginController());
		}

		protected static readonly string SessionName = typeof(Controller).FullName + ".Stack";

		protected static Stack<Controller> Stack
		{
			get
			{
				if (!Session.Current.ContainsKey(SessionName))
				{
					Session.Current.Add(SessionName, new Stack<Controller>());
				}

				return (Stack<Controller>) Session.Current[SessionName];
			}
		}
		
		/// <summary>
		/// Gets the controller currently at the top of the stack (meaning it currently has control)
		/// </summary>
		public static Controller CurrentController
		{
			get
			{
				return Stack.Peek();
			}
		}

		/// <summary>
		/// Gets the Page that is currently being displayed to the user
		/// </summary>
		public static IPage CurrentPage
		{
			get
			{
				return (IPage) Session.Current[typeof(IPage).FullName];
			}
			set
			{
				Session.Current[typeof(IPage).FullName] = value;
            }
		}

		#endregion
	}
}