using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using OKHOSTING.UI.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OKHOSTING.UI.UWP
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Page : Windows.UI.Xaml.Controls.Page, IPage
	{
		public Page()
		{
			this.InitializeComponent();
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
				base.Content = value as Windows.UI.Xaml.UIElement;
			}
		}

		public string Title
		{
			get
			{
				//Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().TitleBar
				return null;
			}
			set
			{
				//throw new NotImplementedException();
			}
		}

		T IPage.Create<T>()
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
				return new Grid() as T;
			}

			throw new NotSupportedException();
		}
	}
}
