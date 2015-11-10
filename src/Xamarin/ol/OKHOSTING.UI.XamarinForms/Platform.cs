using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.XamarinForms
{
	public class Platform: OKHOSTING.UI.Platform
	{
		public Platform (IPage page): base(page)
		{
		}

		public override T Create<T>()
		{
			if (typeof(T) == typeof(IButton))
			{
				return new Button(global::Android.Content.conte) as T;
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
