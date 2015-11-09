using System;
using System.Collections.Generic;
using System.Linq;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Net4.WPF.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Net4.WPF
{
	public class Platform : UI.Platform
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

            if (typeof(T) == typeof(IPasswordTextBox))
            {
                return new PasswordTextBox() as T;
            }

            if (typeof(T) == typeof(IGrid))
            {
                return new Controls.Layouts.Grid() as T;
            }

            throw new NotSupportedException();
		}
	}
}