using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.UI.CSS;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.UI.Test.Css
{
	public class BackgroundImageController : Controller
	{
		public BackgroundImageController(IPage page) : base(page)
		{
		}

		protected override void OnStart()
		{
			var css =
				@"
					button
					{
						background-image: url(file:///C:/Users/david/Downloads/octopus-1.jpg);
					}
				";

			var stack = BaitAndSwitch.Create<IStack>();
			var text = BaitAndSwitch.Create<ILabel>();
			text.Text = "this is a button with a css background-image: \n" + css;
			
			var button = BaitAndSwitch.Create<IButton>();
			button.Text = "i'm a button";

			stack.Children.Add(text);
			stack.Children.Add(button);
			stack.Width = Page.Width;
			stack.Height = Page.Height;

			button.Width = Page.Width - 100;
			button.Height = Page.Height - 200;

			Page.Content = stack;
			Page.Title = "Background image";

			Style style = new Style();
			style.Parse(css);
			style.Apply(Page);
		}
	}
}