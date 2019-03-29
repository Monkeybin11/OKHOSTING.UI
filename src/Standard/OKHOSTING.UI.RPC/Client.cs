using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.UI.RPC
{
	public class Client
	{
		public void Setup()
		{
			Core.BaitAndSwitch.PlatformSpecificModifiers.Add(Tuple.Create<Type, Func<object, object>>(typeof(UI.Controls.IClickable), (control) => 
			{
				((UI.Controls.IClickable) control).Click += Client_Click;
				return control;
			}));

			Core.BaitAndSwitch.PlatformSpecificModifiers.Add(Tuple.Create<Type, Func<object, object>>(typeof(UI.Controls.IInputControl<object>), (control) => 
			{
				((UI.Controls.IClickable) control).Click += Client_Click;
				return control;
			}));
		}

		private void Client_Click(object sender, EventArgs e)
		{
			//send click to server
		}
	}
}