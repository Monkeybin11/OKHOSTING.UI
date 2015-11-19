using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using OKHOSTING.UI.Xamarin.Forms.Controls;
using OKHOSTING.UI.Xamarin.Forms.Controls.Layouts;

namespace OKHOSTING.UI.Xamarin.Forms
{
	public class Page : global::Xamarin.Forms.ContentPage, IPage
	{
		public Page()
		{
			Controller.CurrentPage = this;
			Controller.CurrentController.Start();
		}

		public new IControl Content
		{
			get
			{
				return (IControl) base.Content;
			}
			set
			{
				base.Content = (global::Xamarin.Forms.View) value;
			}
		}

		public T Create<T>() where T : class, IControl
		{
			if (typeof(T) == typeof(IButton))
			{
				return (T)(IButton) new Button();
			}

			if (typeof(T) == typeof(ILabel))
			{
				return (T)(ILabel) new Label();
			}

			if (typeof(T) == typeof(ITextBox))
			{
				return (T)(ITextBox) new TextBox();
			}

			if (typeof(T) == typeof(IPasswordTextBox))
			{
				return (T)(IPasswordTextBox) new PasswordTextBox();
			}

			if (typeof(T) == typeof(IGrid))
			{
				return (T)(IGrid) new Grid();
			}

			throw new NotSupportedException();
		}
	}
}