using System;

namespace OKHOSTING.UI.RPC
{
	public class Client
	{
		public OKHOSTING.RPC.ClientBase RPCClient { get; set; }

		public void Setup()
		{
			RPCClient = Core.BaitAndSwitch.Create<OKHOSTING.RPC.ClientBase>();
			
			Core.BaitAndSwitch.PlatformSpecificModifiers.Add(Tuple.Create<Type, Func<object, object>>(typeof(UI.Controls.IClickable), (control) => 
			{
				((UI.Controls.IClickable) control).Click += control_Click;
				return control;
			}));

			Core.BaitAndSwitch.PlatformSpecificModifiers.Add(Tuple.Create<Type, Func<object, object>>(typeof(UI.Controls.IInputControl<object>), (control) => 
			{
				((UI.Controls.IInputControl<object>) control).ValueChanged += inputControl_Object_ValueChanged;
				return control;
			}));

			Core.BaitAndSwitch.PlatformSpecificModifiers.Add(Tuple.Create<Type, Func<object, object>>(typeof(UI.Controls.IInputControl<string>), (control) =>
			{
				((UI.Controls.IInputControl<string>) control).ValueChanged += inputControl_String_ValueChanged;
				return control;
			}));

			Core.BaitAndSwitch.PlatformSpecificModifiers.Add(Tuple.Create<Type, Func<object, object>>(typeof(UI.Controls.IInputControl<decimal>), (control) =>
			{
				((UI.Controls.IInputControl<decimal>) control).ValueChanged += inputControl_Decimal_ValueChanged;
				return control;
			}));

			Core.BaitAndSwitch.PlatformSpecificModifiers.Add(Tuple.Create<Type, Func<object, object>>(typeof(UI.Controls.IInputControl<double>), (control) =>
			{
				((UI.Controls.IInputControl<double>) control).ValueChanged += inputControl_Double_ValueChanged;
				return control;
			}));

			Core.BaitAndSwitch.PlatformSpecificModifiers.Add(Tuple.Create<Type, Func<object, object>>(typeof(UI.Controls.IInputControl<DateTime?>), (control) =>
			{
				((UI.Controls.IInputControl<DateTime?>) control).ValueChanged += inputControl_DateTime_ValueChanged;
				return control;
			}));

			Core.BaitAndSwitch.PlatformSpecificModifiers.Add(Tuple.Create<Type, Func<object, object>>(typeof(UI.Controls.IInputControl<TimeSpan?>), (control) =>
			{
				((UI.Controls.IInputControl<TimeSpan?>) control).ValueChanged += inputControl_TimeSpan_ValueChanged;
				return control;
			}));

			Core.BaitAndSwitch.PlatformSpecificModifiers.Add(Tuple.Create<Type, Func<object, object>>(typeof(UI.Controls.IInputControl<bool>), (control) =>
			{
				((UI.Controls.IInputControl<bool>) control).ValueChanged += inputControl_Boolean_ValueChanged;
				return control;
			}));
		}

		private void inputControl_Object_ValueChanged(object sender, object e)
		{
		}

		private void inputControl_String_ValueChanged(object sender, string e)
		{
		}

		private void inputControl_Decimal_ValueChanged(object sender, decimal e)
		{
		}

		private void inputControl_Double_ValueChanged(object sender, double e)
		{
		}

		private void inputControl_DateTime_ValueChanged(object sender, DateTime? e)
		{
		}

		private void inputControl_TimeSpan_ValueChanged(object sender, TimeSpan? e)
		{
		}

		private void inputControl_Boolean_ValueChanged(object sender, bool e)
		{
		}

		private void control_Click(object sender, EventArgs e)
		{
			Controls.Control control = (Controls.Control) sender;
		}
	}
}