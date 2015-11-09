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
			Platform.Current = new Platform(this);
			Platform.Current.Controller.Start();
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
	}
}
