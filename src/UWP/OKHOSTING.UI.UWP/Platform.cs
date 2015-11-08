using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.UWP.Controls;

namespace OKHOSTING.UI.UWP
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

			throw new NotSupportedException();
		}
	}
}