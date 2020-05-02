using System;
using System.Drawing;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test.Animation
{
	public class IndexController: Controller 
	{
		protected override void OnStart()
		{
			IStack stack = Core.BaitAndSwitch.Create<IStack>();

			ILabelButton lblControls = Core.BaitAndSwitch.Create<ILabelButton>();
			lblControls.Text = "Linear color animation";
			lblControls.Click += (object sender, EventArgs e) => new Linear() { Page = Page }.Start();
			stack.Children.Add(lblControls);
			
			// Establishes the content and title of the page.
			Page.Title = "Choose one feature to test";
			Page.Content = stack;
		}
	}
}