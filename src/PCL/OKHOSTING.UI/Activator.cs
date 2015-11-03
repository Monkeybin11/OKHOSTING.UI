using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI
{
	public abstract class Activator
	{
		public abstract IControl Create<T>() where T : IControl;

		public static Activator Current { get; set; }
	}
}