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
		/// <summary>
		/// Will be executed when this controller "executes" at first
		/// </summary>
		public virtual void Start()
		{
			App.Current.Page.Content = null;

			if (App.Current.Controller != this)
			{
				App.Current.ControllerStack.Push(this);
			}
		}

		/// <summary>
		/// Will be  executed when the window is resized, allowing the controller to re-arrange the page, therefore making it "responsive"
		/// </summary>
		public virtual void Resize()
		{
		}

		/// <summary>
		/// Will be execeuted once the controller has done it's workd. Use this to dispose objects and release memory
		/// </summary>
		public virtual void Finish()
		{
			App.Current.ControllerStack.Pop();

			if (App.Current.Page.Content != null)
			{
				App.Current.Page.Content.Dispose();
			}

			App.Current.Page.Content = null;
		}
	}
}