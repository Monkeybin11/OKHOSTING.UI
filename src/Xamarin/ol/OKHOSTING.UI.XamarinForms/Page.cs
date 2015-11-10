using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OKHOSTING.UI.Controls;
using Xamarin.Forms;

namespace OKHOSTING.UI.XamarinForms
{
    public class Page : ContentPage, IPage
	{
		public Page()
		{
		}

        IControl IPage.Content
        {
            get
            {
                return (IControl) base.Content;
            }
            set
            {
                base.Content = (Xamarin.Forms.View) value;
            }
        }
    }
}
