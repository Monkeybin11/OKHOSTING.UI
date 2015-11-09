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
            Platform.Current.Page.Content = null;
            Platform.Current.ControllerStack.Push(this);
        }

        public virtual void Finish()
        {
            Platform.Current.ControllerStack.Pop();

            if (Platform.Current.Page.Content != null)
            {
                Platform.Current.Page.Content.Dispose();
            }

            Platform.Current.Page.Content = null;
        }
    }
}