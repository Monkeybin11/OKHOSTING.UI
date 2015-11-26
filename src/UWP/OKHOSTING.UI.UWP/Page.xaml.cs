using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using OKHOSTING.UI.UWP.Controls;
using OKHOSTING.UI.UWP.Controls.Layouts;

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
				base.Content = (Windows.UI.Xaml.UIElement) value;
			}
		}

		public new double Height
		{
			get
			{
				return Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Height;
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

		public new double Width
		{
			get
			{
				return Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
			}
		}

		public T Create<T>() where T : class, IControl
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
