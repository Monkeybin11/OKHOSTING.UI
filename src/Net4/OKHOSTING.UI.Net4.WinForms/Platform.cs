using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Net4.WinForms.Controls;

namespace OKHOSTING.UI.Net4.WinForms
{
	public class Platform: UI.Platform
	{
		public Platform(IPage page) : base(page)
		{
		}

		public override T Create<T>()
		{
			if (typeof(T) == typeof(IButton))
			{
				return new Button() as T;
			}

			if (typeof(T) == typeof(ILabel))
			{
				return new Label() as T;
			}

			if (typeof(T) == typeof(ITextBox))
			{
				return new TextBox() as T;
			}

			throw new NotSupportedException();
		}
	}
}