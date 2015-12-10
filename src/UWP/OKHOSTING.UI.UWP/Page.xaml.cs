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
	}
}